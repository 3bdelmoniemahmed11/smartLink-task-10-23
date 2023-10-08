using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using smartLinkTask.DAL.Models.UserProfileEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace smartLinkTask.BAL.Services.Auth.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UserProfile user, List<string>? Roles)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email??""),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
           
        };
           
            foreach (var role in Roles)
            { 
                claims.Add(new Claim (ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
