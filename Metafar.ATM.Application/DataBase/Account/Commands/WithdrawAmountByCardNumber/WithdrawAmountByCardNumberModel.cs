namespace Metafar.ATM.Application.DataBase.Account.Commands.WithdrawAmountByCardNumber;

public sealed class WithdrawAmountByCardNumberModel
{
    public string TransactionDate { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public decimal BalanceBeforeWithdraw { get; set; }
    public decimal BalanceAfterWithdraw { get; set; }
    public decimal AmountWithdrawed { get; set; }
}
