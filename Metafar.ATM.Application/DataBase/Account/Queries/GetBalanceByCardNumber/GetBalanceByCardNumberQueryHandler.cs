using AutoMapper;
using MediatR;
using Metafar.ATM.Application.DataBase.User.Commands.CreateTransaction;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber
{
    public class GetBalanceByCardNumberQueryHandler : IRequestHandler<GetBalanceByCardNumberQuery, Response<GetBalanceByCardNumberModel>>
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public GetBalanceByCardNumberQueryHandler(IDataBaseService databaseService, IMapper mapper, ISender sender)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task<Response<GetBalanceByCardNumberModel>> Handle(GetBalanceByCardNumberQuery request, CancellationToken cancellationToken)
        {
            var account = await _databaseService.Account.Include(x => x.User).FirstOrDefaultAsync(x => x.CardNumber == request.CardNumber, cancellationToken);

            if (account == null)
            {
                return ResponseService<GetBalanceByCardNumberModel>.GetResponseSingleError(Common.Constants.AccountMessageError, true);
            }

            DateTime transactionTime = DateTime.Now;
            CreateTransactionCommand createTransactionCommand = new(account.AccountNumber, 0, transactionTime, Common.Constants.Check);
            var createTransactionResponse = await _sender.Send(createTransactionCommand, cancellationToken);

            if (!createTransactionResponse.Success)
            {
                return ResponseService<GetBalanceByCardNumberModel>.GetResponseMultipleErrors(createTransactionResponse.Messages);
            }

            var getBalanceByCardNumberModel = _mapper.Map<GetBalanceByCardNumberModel>(account);
            getBalanceByCardNumberModel.CheckDateTime = transactionTime.ToString(Common.Constants.DateFormat, CultureInfo.InvariantCulture);

            var lastWithdrawal = await _databaseService.Transaction
                .Where(x => x.AccountNumber == account.AccountNumber && x.TransactionType.TransactionType == Common.Constants.Withdraw)
                .MaxAsync(x => x.TransactionDate, cancellationToken);

            getBalanceByCardNumberModel.LastWithdrawal = lastWithdrawal.ToString(Common.Constants.DateFormat, CultureInfo.InvariantCulture);

            return ResponseService<GetBalanceByCardNumberModel>.GetResponseOk(getBalanceByCardNumberModel);
        }
    }
}
