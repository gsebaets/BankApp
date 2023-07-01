using BankUsersApp.Utilities.Request;
using BankUsersApp.Utilities.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankUsersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("generate-token")]
        public IActionResult GenerateToken(CredentialsRequest credentials)
        {
            // Retrieve the credentials from appsettings
            var appCredentials = GetCredentialsFromAppSettings();

            // Validate the provided credentials
            if (credentials.Username == appCredentials.Username && credentials.Password == appCredentials.Password)
            {
                // Generate token
                var token = GenerateJwtToken(credentials.Username);
                return Ok(new { token });
            }
            return Unauthorized("Invalid Username or Password");
        }

        private CredentialsRequest GetCredentialsFromAppSettings()
        {
            var username = _configuration.GetSection("Credentials:Username").Value;
            var password = _configuration.GetSection("Credentials:Password").Value;
            return new CredentialsRequest { Username = username, Password = password };
        }

        private TokenResponse GenerateJwtToken(string username)
        {
            var secretKey = _configuration.GetSection("AppSettings:SecretKey").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                Token = tokenString,
                Expiry = expiry
            };
        }
    }
}
