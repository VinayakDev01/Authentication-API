using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users = new List<User>
        {
            //Hardcoded(static) user details has been created
            new User { Username = "player1", Password = "password1", Role = "player", Regions = new List<string> { "b_game" } },
            new User { Username = "vipUser", Password = "password2", Role = "player", Regions = new List<string> { "b_game", "vip_character_personalize" } },
            new User { Username = "adminUser", Password = "password3", Role = "admin", Regions = new List<string> { "b_game" } }
        };

        private readonly string _key;

        public AuthService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
        }

        // Method for authentication of user credentials: username and password
        public string Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // If user is not found, return null
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Regions", string.Join(",", user.Regions))
                }),
                //Set the token expiry for to avoid security breaches and vulnerabilities
                Expires = DateTime.UtcNow.AddHours(1), // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Return the JWT token
        }
    }
}
