namespace BankUsersApp.Utilities.Request
{
    public class WithdrawalRequest
    {
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
    }
}
