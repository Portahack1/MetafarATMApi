using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.Account.Commands.UpdateAccountFailedAttempts;

public sealed record UpdateAccountFailedAttemptsCommand(string AccountNumber) : IRequest<Response<UpdateAccountFailedAttemptsModel>>;

