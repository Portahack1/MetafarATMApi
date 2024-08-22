using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Metafar.ATM.Application.DataBase.Transaction.Queries.GetAllTransactionsByCardNumber
{
    internal class GetAllTransactionsByCardNumberQueryHandler : IRequestHandler<GetAllTransactionsByCardNumberQuery, Response<List<GetAllTransactionsByCardNumberQueryModel>>>
    {
        private readonly IDataBaseService _dataBaseService;

        public GetAllTransactionsByCardNumberQueryHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<Response<List<GetAllTransactionsByCardNumberQueryModel>>> Handle(GetAllTransactionsByCardNumberQuery request, CancellationToken cancellationToken)
        {
            int page = request.Page ?? 1;
            page = page <= 0 ? 1 : page;
            int pageSize = request.PageSize ?? 10;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            var data = await (from account in _dataBaseService.Account
                              join transactions in _dataBaseService.Transaction
                              on account.AccountNumber equals transactions.AccountNumber
                              where account.CardNumber == request.CardNumber
                              orderby transactions.TransactionDate descending
                              select new GetAllTransactionsByCardNumberQueryModel()
                              {
                                  AccountNumber = account.AccountNumber,
                                  Amount = transactions.Amount,
                                  TransactionDate = transactions.TransactionDate.ToString(Common.Constants.DateFormat, CultureInfo.InvariantCulture),
                                  TransactionType = transactions.TransactionType.TransactionType
                              })
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync(cancellationToken);

            return ResponseService<List<GetAllTransactionsByCardNumberQueryModel>>.GetResponseOk(data);
        }
    }
}
