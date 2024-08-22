using FluentValidation;
using Metafar.ATM.Application.DataBase.User.Queries;

namespace Metafar.ATM.Application.Validators.User
{
    public class GetTokenByCardNumberAndPinQueryValidator : AbstractValidator<GetTokenByCardNumberAndPinQuery>
    {
        public GetTokenByCardNumberAndPinQueryValidator()
        {
            RuleFor(x => x.CardNumber).NotEmpty().Length(16);
            RuleFor(x => x.Pin).NotEmpty().Length(4);
        }
    }
}
