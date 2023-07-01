using System.ComponentModel.DataAnnotations;

namespace BankUsersApp.Infrastructure.Models
{
    public class Users
    {
        [Key]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "The ID number must contain only numeric digits.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "The ID number must be exactly 13 digits.")]
        public string IdNumber { get; set; }
        public string ResidentialAddress { get; set; }

        [RegularExpression(@"^\+271\d{9}$", ErrorMessage = "Invalid mobile number format. It should be in the format +271XXXXXXXXX.")]
        public string MobileNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
