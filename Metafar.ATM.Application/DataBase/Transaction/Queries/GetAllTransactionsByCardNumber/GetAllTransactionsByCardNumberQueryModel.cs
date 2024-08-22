namespace Metafar.ATM.Application.DataBase.Transaction.Queries.GetAllTransactionsByCardNumber;

public class GetAllTransactionsByCardNumberQueryModel
{
    public string AccountNumber { get; set; } = string.Empty;
    public string TransactionDate { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string TransactionType { get; set; } = string.Empty;
}
