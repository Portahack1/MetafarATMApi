using Metafar.ATM.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Persistence.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<AccountEntity> entityBuilder)
        {
            entityBuilder.ToTable("Account");
            entityBuilder.HasKey(x => x.AccountNumber);
            entityBuilder.Property(x => x.CardNumber).IsRequired();
            entityBuilder.Property(x => x.Balance).IsRequired();
            entityBuilder.Property(x => x.Pin).IsRequired();
            
            entityBuilder.Property(x => x.MaxLoginAttempts).IsRequired();
            entityBuilder.Property(x => x.FailedLoginAttempts).IsRequired();
            entityBuilder.Property(x => x.Blocked).IsRequired();

            entityBuilder
                .HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);

            entityBuilder.HasData(
                new AccountEntity()
                {
                    AccountNumber = "33294946862678791686",
                    CardNumber = "3716774812566768",
                    Pin = "1111",
                    Balance = 1000,
                    MaxLoginAttempts = 4,
                    FailedLoginAttempts = 0,
                    Blocked = false,
                    UserId = new Guid("B3B6F399-4993-42DE-8772-9AE8A732504D")
                },
                new AccountEntity()
                {
                    AccountNumber = "57580242539941657006",
                    CardNumber = "3716745896852693",
                    Pin = "5555",
                    Balance = 50000,
                    MaxLoginAttempts = 4,
                    FailedLoginAttempts = 0,
                    Blocked = false,
                    UserId = new Guid("774B7FA6-50FD-4ABC-80F7-B2000B349C23")
                },
                new AccountEntity()
                {
                    AccountNumber = "68983408175964235159",
                    CardNumber = "3716485698515478",
                    Pin = "9999",
                    Balance = 100000,
                    MaxLoginAttempts = 4,
                    FailedLoginAttempts = 0,
                    Blocked = false,
                    UserId = new Guid("4C7C5B69-D92E-44C4-8524-ABE0A229779A")
                });
        }
    }
}
