using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace Metafar.ATM.Api
{
    public static class JwtTokenDecoder
    {
        public static string GetCardNumberFromJwtToken(string authorization)
        {
            string cardNumber = string.Empty;
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var parameter = headerValue.Parameter;
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(parameter);
                cardNumber = jwtSecurityToken.Claims.First(claim => claim.Type == "CardNumber").Value.ToString();
            }

            return cardNumber;
        }
    }
}
