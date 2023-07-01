using BankUsersApp.Infrastructure.DB;
using BankUsersApp.Infrastructure.Models;
using BankUsersApp.Interfaces;

namespace BankUsersApp.Repositories
{
    public class UserBankDetailRepo : GenericRepository<UserBankDetail>, IUserBankDetailRepo
    {
        public UserBankDetailRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}