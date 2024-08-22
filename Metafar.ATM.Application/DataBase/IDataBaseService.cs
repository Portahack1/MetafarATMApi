using Metafar.ATM.Domain.Entities.Account;
using Metafar.ATM.Domain.Entities.Transaction;
using Metafar.ATM.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<TransactionTypeEntity> TransactionType { get; set; }
        DbSet<TransactionEntity> Transaction { get; set; }
        DbSet<AccountEntity> Account { get; set; }

        Task<bool> SaveAsync();
    }
}
