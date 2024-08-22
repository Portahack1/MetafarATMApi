using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber;

public sealed record GetBalanceByCardNumberQuery(string CardNumber) : IRequest<Response<GetBalanceByCardNumberModel>>;
