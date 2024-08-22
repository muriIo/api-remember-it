using api_remember_it.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_remember_it.Utils
{
    public class JwtTokenUtil
    {
        public static string GetToken(User user)
        {
            string tokenSecret = Environment.GetEnvironmentVariable("TOKEN_SECRET")!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));

            int minutesExpiry = Convert.ToInt32(Environment.GetEnvironmentVariable("TOKEN_EXPIRY_MINUTES"));
            TimeSpan tokeLifeTime = TimeSpan.FromMinutes(minutesExpiry);

            string tokenIssuer = Environment.GetEnvironmentVariable("TOKEN_ISSUER")!;

            string tokenAudience = Environment.GetEnvironmentVariable("TOKEN_AUDIENCE")!;

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Email, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(tokeLifeTime),
                Issuer = tokenIssuer,
                Audience = tokenAudience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
