using Metafar.ATM.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metafar.ATM.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.ToTable("User");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserName).IsRequired();

            entityBuilder
                .HasMany(x => x.Accounts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            entityBuilder.HasData(
                new UserEntity()
                {
                    Id = new Guid("B3B6F399-4993-42DE-8772-9AE8A732504D"),
                    UserName = "John Smith"
                },
                new UserEntity()
                {
                    Id = new Guid("4C7C5B69-D92E-44C4-8524-ABE0A229779A"),
                    UserName = "Denzel Washington"
                },
                new UserEntity()
                {
                    Id = new Guid("774B7FA6-50FD-4ABC-80F7-B2000B349C23"),
                    UserName = "Johnny Depp"
                }
                );
        }
    }
}
