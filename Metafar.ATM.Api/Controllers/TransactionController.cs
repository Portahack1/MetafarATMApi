using MediatR;
using Metafar.ATM.Application.DataBase.Transaction.Queries.GetAllTransactionsByCardNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Metafar.ATM.Api.Controllers
{
    [Authorize]
    [Route("api/v1/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISender _sender;

        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("get-all-transactions")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] int? pageSize, [FromQuery] int? page, [FromHeader] string authorization)
        {
            string cardNumber = JwtTokenDecoder.GetCardNumberFromJwtToken(authorization);

            GetAllTransactionsByCardNumberQuery query = new(cardNumber, pageSize, page);

            var response = await _sender.Send(query);

            if (response.Success) return Ok(response);
            if (response.DataNotFound) return NotFound(response);
            return BadRequest(response);
        }
    }
}
