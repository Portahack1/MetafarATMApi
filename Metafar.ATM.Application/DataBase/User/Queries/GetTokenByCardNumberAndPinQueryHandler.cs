using MediatR;
using Metafar.ATM.Application.DataBase.Account.Commands.ResetAccountFailedAttempts;
using Metafar.ATM.Application.DataBase.Account.Commands.UpdateAccountFailedAttempts;
using Metafar.ATM.Application.External;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Application.DataBase.User.Queries
{
    public class GetTokenByCardNumberAndPinQueryHandler : IRequestHandler<GetTokenByCardNumberAndPinQuery, Response<string>>
    {
        private readonly ISender _sender;
        private readonly IGetTokenJwtService _getTokenJwtService;
        private readonly IDataBaseService _databaseService;

        public GetTokenByCardNumberAndPinQueryHandler(IDataBaseService databaseService, IGetTokenJwtService getTokenJwtService, ISender sender)
        {
            _getTokenJwtService = getTokenJwtService;
            _sender = sender;
            _databaseService = databaseService;
        }

        public async Task<Response<string>> Handle(GetTokenByCardNumberAndPinQuery request, CancellationToken cancellationToken)
        {
            var account = await _databaseService.Account.FirstOrDefaultAsync(x => x.CardNumber == request.CardNumber, cancellationToken);

            if (account is null)
            {
                return ResponseService<string>.GetResponseSingleError(Common.Constants.AccountMessageError, true);
            }

            if (account.Blocked)
            {
                return ResponseService<string>.GetResponseSingleError("The account is blocked.");
            }

            if (account.Pin != request.Pin)
            {
                UpdateAccountFailedAttemptsCommand updateAccountFailedAttempsCommand = new(account.AccountNumber);
                var accountUpdated = await _sender.Send(updateAccountFailedAttempsCommand, cancellationToken);

                if (accountUpdated is null || accountUpdated.Data is null)
                {
                    return ResponseService<string>.GetResponseSingleError(Common.Constants.GenericMessageError);
                }

                if (!accountUpdated.Success)
                {
                    return ResponseService<string>.GetResponseMultipleErrors(accountUpdated.Messages);
                }

                if (accountUpdated.Data.Blocked)
                {
                    return ResponseService<string>.GetResponseSingleError("The user has reached the maximum number of attempts. The account has been blocked.");
                }

                string pinDoesntMatchMessage = $"The pin entered is not valid, current attempts {account.FailedLoginAttempts} / {account.MaxLoginAttempts}";
                return ResponseService<string>.GetResponseSingleError(pinDoesntMatchMessage);
            }

            if (account.FailedLoginAttempts > 0)
            { 
                ResetAccountFailedAttemptsCommand resetAccountFailedAttemptsCommand = new(account.AccountNumber);
                var resetAccountFailedAttemptsResp = await _sender.Send(resetAccountFailedAttemptsCommand, cancellationToken);

                if (resetAccountFailedAttemptsResp is null)
                {
                    return ResponseService<string>.GetResponseSingleError("Ocurred a problem procesing the request, please try later.");
                }

                if (!resetAccountFailedAttemptsResp.Success)
                {
                    return ResponseService<string>.GetResponseMultipleErrors(resetAccountFailedAttemptsResp.Messages);
                }
            }

            var jwtToken = _getTokenJwtService.Execute(account.CardNumber);

            return ResponseService<string>.GetResponseOk(jwtToken);
        }
    }
}
