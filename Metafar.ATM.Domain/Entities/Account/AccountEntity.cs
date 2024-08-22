using Metafar.ATM.Domain.Entities.Transaction;
using Metafar.ATM.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metafar.ATM.Domain.Entities.Account;

public class AccountEntity
{
    [Key]
    public string AccountNumber { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string Pin { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public byte MaxLoginAttempts { get; set; }
    public byte FailedLoginAttempts { get; set; }
    public bool Blocked { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public UserEntity User { get; set; }
    public ICollection<TransactionEntity> Transactions { get; set; }
}
