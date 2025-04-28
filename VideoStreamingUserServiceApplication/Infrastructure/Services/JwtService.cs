using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.Entities;

namespace VideoStreamingUserServiceApplication.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;
        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim> { 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
            var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Ïssuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
