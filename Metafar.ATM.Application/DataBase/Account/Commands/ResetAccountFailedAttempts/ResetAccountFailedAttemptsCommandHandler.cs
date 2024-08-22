using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Application.DataBase.Account.Commands.ResetAccountFailedAttempts
{
    public class ResetAccountFailedAttemptscommandHandler : IRequestHandler<ResetAccountFailedAttemptsCommand, Response<bool>>
    {
        private readonly IDataBaseService _databaseService;

        public ResetAccountFailedAttemptscommandHandler(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<Response<bool>> Handle(ResetAccountFailedAttemptsCommand request, CancellationToken cancellationToken)
        {
            var account = await _databaseService.Account.FirstOrDefaultAsync(x => x.AccountNumber == request.AccountNumber, cancellationToken);

            if (account is null)
            {
                return ResponseService<bool>.GetResponseSingleError(Common.Constants.AccountMessageError, true);
            }

            account.FailedLoginAttempts = 0;
            await _databaseService.SaveAsync();

            return ResponseService<bool>.GetResponseOk();
        }

    }
}
