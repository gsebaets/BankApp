using System.ComponentModel.DataAnnotations;

namespace BankUsersApp.Infrastructure.Models
{
    public class UserBankDetail
    {
        [Key]
        public long UserBankDetailId { get; set; }
        public long UserId { get; set; }
        public long BankId { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public bool Status { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
