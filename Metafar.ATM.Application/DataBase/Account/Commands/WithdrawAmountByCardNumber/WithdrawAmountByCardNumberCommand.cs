using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.Account.Commands.WithdrawAmountByCardNumber;

public sealed record WithdrawAmountByCardNumberCommand(string CardNumber, decimal Amount) : IRequest<Response<WithdrawAmountByCardNumberModel>>;
