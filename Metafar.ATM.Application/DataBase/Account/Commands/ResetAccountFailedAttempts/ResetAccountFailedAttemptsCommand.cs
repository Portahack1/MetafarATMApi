using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.Account.Commands.ResetAccountFailedAttempts;

public sealed record ResetAccountFailedAttemptsCommand(string AccountNumber) : IRequest<Response<bool>>;
