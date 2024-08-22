using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.Transaction.Queries.GetAllTransactionsByCardNumber;

public sealed record GetAllTransactionsByCardNumberQuery(string CardNumber, int? PageSize, int? Page) : IRequest<Response<List<GetAllTransactionsByCardNumberQueryModel>>>;
