namespace Metafar.ATM.Application.DataBase.Account.Queries.GetBalanceByCardNumber;

public sealed class GetBalanceByCardNumberModel
{
    public string UserName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string CheckDateTime { get; set; } = string.Empty;
    public string? LastWithdrawal { get; set; }
}
