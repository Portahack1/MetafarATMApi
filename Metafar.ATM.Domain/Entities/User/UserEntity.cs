using Metafar.ATM.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations;

namespace Metafar.ATM.Domain.Entities.User;

public class UserEntity
{
    [Key]
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public ICollection<AccountEntity> Accounts { get; set; }
}
