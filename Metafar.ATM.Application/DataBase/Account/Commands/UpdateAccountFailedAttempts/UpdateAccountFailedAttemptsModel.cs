namespace Metafar.ATM.Application.DataBase.Account.Commands.UpdateAccountFailedAttempts;

public class UpdateAccountFailedAttemptsModel
{
    public required string AccountNumber { get; set; }
    public byte MaxLoginAttempts { get; set; }
    public byte FailedLoginAttempts { get; set; }
    public bool Blocked { get; set; }
}
