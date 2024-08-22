using Metafar.ATM.Application.External;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Metafar.ATM.External.GetTokenJwt
{
    internal class GetTokenJwtService(IConfiguration configuration) : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration = configuration;

        public string Execute(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["SecretKeyJwt"] ?? string.Empty;
            SymmetricSecurityKey signinKey = new(Encoding.UTF8.GetBytes(key));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new (ClaimTypes.NameIdentifier, id)
                    new ("CardNumber", id)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"],
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
