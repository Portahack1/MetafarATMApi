using Metafar.ATM.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Persistence.Configuration
{
    public class TransactionTypeConfiguration
    {
        public TransactionTypeConfiguration(EntityTypeBuilder<TransactionTypeEntity> entityBuilder)
        {
            entityBuilder.ToTable("TransactionType");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.TransactionType).IsRequired();

            entityBuilder.HasData(
                new TransactionTypeEntity()
                {
                    Id = new Guid("F79CA38A-D81E-4C51-9B5F-741626A6BA18"),
                    TransactionType = "CHECKBALANCE"
                },
                new TransactionTypeEntity()
                {
                    Id = new Guid("9EC43875-4446-4F52-8DAA-967C2D938C7B"),
                    TransactionType = "WITHDRAW"
                },
                new TransactionTypeEntity()
                {
                    Id = new Guid("4142DE52-7053-478B-804B-B6BFA4217F1E"),
                    TransactionType = "DEPOSIT"
                }
                );
        }
    }
}
