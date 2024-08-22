using AutoMapper;
using Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber;
using Metafar.ATM.Domain.Entities.Account;

namespace Metafar.ATM.Application.Configuration
{
    public class UserNameCustomResolver : IValueResolver<AccountEntity, GetBalanceByCardNumberModel, string>
    {
        public string Resolve(AccountEntity source, GetBalanceByCardNumberModel destination, string destMember, ResolutionContext context)
        {
            return source.User.UserName;
        }
    }
}
