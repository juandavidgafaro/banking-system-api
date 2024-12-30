namespace BankingSystem.Api.Application.Factories.Implementations;
public class CheckingAccount : IAccount
{
    private long _NUMBER;

    public CheckingAccount(long number, double initialBalance)
    {
        _NUMBER = number;
        Balance = initialBalance;
    }

    public double Balance { get; private set; }
    public long Number => _NUMBER;
    public long GetNumber() => Number;
    public double GetBalance() => Balance;
}