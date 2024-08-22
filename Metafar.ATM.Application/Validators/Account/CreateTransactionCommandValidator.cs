using FluentValidation;
using Metafar.ATM.Application.DataBase.User.Commands.CreateTransaction;

namespace Metafar.ATM.Application.Validators.Account
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator() 
        {
            RuleFor(x => x.AccountNumber).NotEmpty();
            RuleFor(x => x.TransactionType).NotEmpty();
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
