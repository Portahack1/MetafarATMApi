using MediatR;
using Metafar.ATM.Application.DataBase.Account.Commands.WithdrawAmountByCardNumber;
using Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metafar.ATM.Api.Controllers
{
    [Authorize]
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("get-balance")]
        public async Task<IActionResult> GetBalance([FromHeader] string authorization)
        {
            string cardNumber = JwtTokenDecoder.GetCardNumberFromJwtToken(authorization);
            GetBalanceByCardNumberQuery query = new(cardNumber);
            var response = await _sender.Send(query);

            if (response.Success) return Ok(response);
            if (response.DataNotFound) return NotFound(response);
            return BadRequest(response);
        }

        [HttpPost("withdraw-amount/{amount}")]
        public async Task<IActionResult> WithdrawAmount(decimal amount, [FromHeader] string authorization)
        {
            string cardNumber = JwtTokenDecoder.GetCardNumberFromJwtToken(authorization);
            WithdrawAmountByCardNumberCommand withdrawAmountByCardNumberCommand = new(cardNumber, amount);
            var response = await _sender.Send(withdrawAmountByCardNumberCommand);

            if (response.Success) return Ok(response);
            if (response.DataNotFound) return NotFound(response);
            return BadRequest(response);
        }
    }
}
