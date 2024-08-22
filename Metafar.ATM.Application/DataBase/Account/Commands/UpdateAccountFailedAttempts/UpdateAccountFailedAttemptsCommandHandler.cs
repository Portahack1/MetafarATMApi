using AutoMapper;
using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Application.DataBase.Account.Commands.UpdateAccountFailedAttempts
{
    public class UpdateAccountFailedAttemptsCommandHandler : IRequestHandler<UpdateAccountFailedAttemptsCommand, Response<UpdateAccountFailedAttemptsModel>>
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateAccountFailedAttemptsCommandHandler(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<Response<UpdateAccountFailedAttemptsModel>> Handle(UpdateAccountFailedAttemptsCommand request, CancellationToken cancellationToken)
        {
            var account = await _databaseService.Account.FirstOrDefaultAsync(x => x.AccountNumber == request.AccountNumber);

            if (account is null)
            {
                return ResponseService<UpdateAccountFailedAttemptsModel>.GetResponseSingleError(Common.Constants.AccountMessageError, true);
            }


            account.FailedLoginAttempts++;
            account.Blocked = (account.FailedLoginAttempts >= account.MaxLoginAttempts);

            await _databaseService.SaveAsync();

            return ResponseService<UpdateAccountFailedAttemptsModel>.GetResponseOk(_mapper.Map<UpdateAccountFailedAttemptsModel>(account));
        }
    }
}
