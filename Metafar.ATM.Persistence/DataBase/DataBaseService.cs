using Metafar.ATM.Application.DataBase;
using Metafar.ATM.Domain.Entities.Account;
using Metafar.ATM.Domain.Entities.Transaction;
using Metafar.ATM.Domain.Entities.User;
using Metafar.ATM.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Metafar.ATM.Persistence.DataBase
{
    public class DataBaseService(DbContextOptions options) : DbContext(options), IDataBaseService
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TransactionTypeEntity> TransactionType { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }
        public DbSet<AccountEntity> Account { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            _ = new UserConfiguration(modelBuilder.Entity<UserEntity>());
            _ = new AccountConfiguration(modelBuilder.Entity<AccountEntity>());
            _ = new TransactionConfiguration(modelBuilder.Entity<TransactionEntity>());
            _ = new TransactionTypeConfiguration(modelBuilder.Entity<TransactionTypeEntity>());
        }
    }
}
