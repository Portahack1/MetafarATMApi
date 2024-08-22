using MediatR;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.DataBase.User.Commands.CreateTransaction;

public sealed record CreateTransactionCommand(string AccountNumber, decimal Amount, DateTime TransactionDate, string TransactionType) : IRequest<Response<bool>>;
