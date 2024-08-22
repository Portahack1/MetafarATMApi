using AutoMapper;
using Metafar.ATM.Application.DataBase.Account.Commands.UpdateAccountFailedAttempts;
using Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber;
using Metafar.ATM.Domain.Entities.Account;

namespace Metafar.ATM.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<AccountEntity, GetBalanceByCardNumberModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom<UserNameCustomResolver>());

            CreateMap<AccountEntity, UpdateAccountFailedAttemptsModel>().ReverseMap();
        }
    }
}
