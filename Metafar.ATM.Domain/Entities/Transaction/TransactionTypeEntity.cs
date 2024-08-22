using System.ComponentModel.DataAnnotations;

namespace Metafar.ATM.Domain.Entities.Transaction;

public class TransactionTypeEntity
{
    [Key]
    public  Guid Id { get; set; }
    public string TransactionType { get; set; } = string.Empty;
}
