using MediatR;
using Metafar.ATM.Application.DataBase.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Metafar.ATM.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("login/{cardNumber}/{pin}")]
        public async Task<IActionResult> Login(string cardNumber, string pin)
        {
            GetTokenByCardNumberAndPinQuery query = new(cardNumber, pin);
            var jwtTokenResponse = await _sender.Send(query);

            if (jwtTokenResponse.Success) return Ok(jwtTokenResponse);
            if (jwtTokenResponse.DataNotFound) return NotFound(jwtTokenResponse);
            return BadRequest(jwtTokenResponse);
        }
    }
}
