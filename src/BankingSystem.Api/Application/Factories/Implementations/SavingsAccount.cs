namespace BankingSystem.Api.Application.Factories.Implementations;
public class SavingsAccount : IAccount
{
    private long _NUMBER;

    public SavingsAccount(long number, double initialBalance)
    {
        _NUMBER = number;
        Balance = initialBalance;
    }

    public long Number => _NUMBER;
    public double Balance { get; private set; }
    public long GetNumber() => Number;
    public double GetBalance() => Balance;
}