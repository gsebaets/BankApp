using System.Security.Claims;

namespace BankUsersApp.Utilities.Response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
