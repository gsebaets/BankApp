using System.ComponentModel.DataAnnotations;

namespace BankUsersApp.Infrastructure.Models
{
    public class Banks
    {
        [Key]
        public long BankId { get; set; }
        public string BankName { get; set; }
        public bool Status { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
