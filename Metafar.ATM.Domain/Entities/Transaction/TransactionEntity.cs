
using Metafar.ATM.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metafar.ATM.Domain.Entities.Transaction;

public class TransactionEntity
{
    [Key]
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public Guid TransactionTypeId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    [ForeignKey("AccountNumber")]
    public AccountEntity Account { get; set; }
    [ForeignKey("TransactionTypeId")]

    public TransactionTypeEntity TransactionType { get; set; }
}
