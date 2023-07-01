using BankUsersApp.Interfaces;
using BankUsersApp.Utilities;
using BankUsersApp.Utilities.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankUsersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public BankUserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("get-all-bank-users")]
        public async Task<IActionResult> GetAllBankUsers()
        {
            // Get all bank users details
            var data = _unitOfWork.UserBankRepository.GetAll()
                        .Join(_unitOfWork.UserRepository.GetAll(),
                            ub => ub.UserId,
                            u => u.UserId,
                            (ub, u) => new { UserBankDetail = ub, User = u })
                        .Join(_unitOfWork.BankRepository.GetAll(),
                            ubu => ubu.UserBankDetail.BankId,
                            b => b.BankId,
                            (ubu, b) => new
                            {
                                UserName = ubu.User.FirstName + " " + ubu.User.LastName,
                                ubu.UserBankDetail.AccountNumber,
                                ubu.UserBankDetail.AccountType,
                                b.Status,
                                ubu.UserBankDetail.AvailableBalance
                            });
            return Ok(data);
        }

        [HttpGet]
        [Route("get-bank-user")]
        public async Task<IActionResult> GetBankUser(string accountNumber)
        {
            // Get specific bank user detail based on account number
            var data = _unitOfWork.UserBankRepository.GetAll()
                        .Join(_unitOfWork.UserRepository.GetAll(),
                            ub => ub.UserId,
                            u => u.UserId,
                            (ub, u) => new { UserBankDetail = ub, User = u })
                        .Join(_unitOfWork.BankRepository.GetAll(),
                            ubu => ubu.UserBankDetail.BankId,
                            b => b.BankId,
                            (ubu, b) => new
                            {
                                UserName = ubu.User.FirstName + " " + ubu.User.LastName,
                                ubu.UserBankDetail.AccountNumber,
                                ubu.UserBankDetail.AccountType,
                                ubu.UserBankDetail.Status,
                                ubu.UserBankDetail.AvailableBalance
                            }).FirstOrDefault(ubu => ubu.AccountNumber == accountNumber);

            if (data == null)
            {
                return NotFound("Account number not found"); // Account number not found
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("cash-withdraw")]
        public async Task<IActionResult> CashWithdraw(WithdrawalRequest request)
        {
            // Find the user bank detail based on the account number
            var userBankDetail = _unitOfWork.UserBankRepository.GetAll()
                .FirstOrDefault(ub => ub.AccountNumber == request.AccountNumber);

            if (userBankDetail == null)
            {
                return NotFound("Account number not found"); // Account number not found
            }

            // Check if the bank account is active
            if (!userBankDetail.Status)
            {
                return BadRequest("Withdrawals are not allowed on inactive bank accounts.");
            }

            // Check if the withdrawal amount is valid
            if (request.Amount <= 0)
            {
                return BadRequest("The withdrawal amount must be greater than 0.");
            }

            // Check if the withdrawal amount exceeds the available balance
            if (request.Amount > userBankDetail.AvailableBalance)
            {
                return BadRequest("The withdrawal amount exceeds the available balance.");
            }

            // Check if it's a Fixed Deposit account and the withdrawal amount is 100%
            if (!userBankDetail.AccountType.Equals(AccountType.FixedDeposit) && request.Amount == Convert.ToInt32(userBankDetail.AvailableBalance))
            {
                return BadRequest("Only 100% withdrawal is allowed on a Fixed Deposit account.");
            }

            // Perform the withdrawal operation
            userBankDetail.AvailableBalance -= request.Amount;
            _unitOfWork.UserBankRepository.Update(userBankDetail);
            _unitOfWork.Complete();
            return Ok("Withdrawal Successful. Remaining amount is: " + userBankDetail.AvailableBalance);
        }
    }
}
