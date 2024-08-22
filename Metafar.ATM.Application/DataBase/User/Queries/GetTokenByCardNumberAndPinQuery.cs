using MediatR;

namespace Metafar.ATM.Application.DataBase.User.Queries;

public sealed record GetTokenByCardNumberAndPinQuery(string CardNumber, string Pin) : IRequest<Domain.Models.Response<string>>;
