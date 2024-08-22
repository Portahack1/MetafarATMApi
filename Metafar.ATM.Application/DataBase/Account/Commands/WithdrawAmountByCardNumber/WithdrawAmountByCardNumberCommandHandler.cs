using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Entities.Transaction;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Metafar.ATM.Application.DataBase.Account.Commands.WithdrawAmountByCardNumber
{
    public class WithdrawAmountByCardNumberCommandHandler : IRequestHandler<WithdrawAmountByCardNumberCommand, Response<WithdrawAmountByCardNumberModel>>
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly ISender _sender;

        public WithdrawAmountByCardNumberCommandHandler(IDataBaseService dataBaseService, ISender sender)
        {
            _dataBaseService = dataBaseService;
            _sender = sender;
        }

        public async Task<Response<WithdrawAmountByCardNumberModel>> Handle(WithdrawAmountByCardNumberCommand request, CancellationToken cancellationToken)
        {
            var account = await _dataBaseService.Account.FirstOrDefaultAsync(x => x.CardNumber == request.CardNumber, cancellationToken);

            if (account == null)
            {
                return ResponseService<WithdrawAmountByCardNumberModel>.GetResponseSingleError(Common.Constants.AccountMessageError, true);
            }

            if (request.Amount > account.Balance)
            {
                return ResponseService<WithdrawAmountByCardNumberModel>.GetResponseSingleError("Insufficient balance.");
            }

            DateTime transactionDateTime = DateTime.Now;

            var transactionType = await _dataBaseService.TransactionType
                .FirstOrDefaultAsync(x => x.TransactionType == Common.Constants.Withdraw, cancellationToken);

            if (transactionType is null)
            {
                return ResponseService<WithdrawAmountByCardNumberModel>.GetResponseSingleError(Common.Constants.GenericMessageError);
            }

            TransactionEntity transactionEntity = new()
            {
                AccountNumber = account.AccountNumber,
                Amount = request.Amount,
                TransactionDate = transactionDateTime,
                TransactionTypeId = transactionType.Id
            };

            WithdrawAmountByCardNumberModel withdrawTransaction = new()
            {
                AccountNumber = account.AccountNumber,
                BalanceBeforeWithdraw = account.Balance,
                TransactionDate = transactionDateTime.ToString(Common.Constants.DateFormat, CultureInfo.InvariantCulture),
                CardNumber = request.CardNumber,
                AmountWithdrawed = request.Amount,
            };

            account.Balance -= request.Amount;
            withdrawTransaction.BalanceAfterWithdraw = account.Balance;
            await _dataBaseService.Transaction.AddAsync(transactionEntity, cancellationToken);
            await _dataBaseService.SaveAsync();

            return ResponseService<WithdrawAmountByCardNumberModel>.GetResponseOk(withdrawTransaction);
        }
    }
}
