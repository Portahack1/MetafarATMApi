using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Entities.Transaction;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Application.DataBase.User.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<bool>>
    {
        private readonly IDataBaseService _dataBaseService;

        public CreateTransactionCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<Response<bool>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionType = await _dataBaseService.TransactionType
                .FirstOrDefaultAsync(x => x.TransactionType == request.TransactionType, cancellationToken);

            if (transactionType is null)
            {
                return ResponseService<bool>.GetResponseSingleError(Common.Constants.GenericMessageError);
            }

            TransactionEntity transactionEntity = new()
            {
                AccountNumber = request.AccountNumber,
                Amount = request.Amount,
                TransactionDate = request.TransactionDate,
                TransactionTypeId = transactionType.Id
            };

            await _dataBaseService.Transaction.AddAsync(transactionEntity, cancellationToken);
            await _dataBaseService.SaveAsync();

            return ResponseService<bool>.GetResponseOk();
        }
    }
}
