namespace BankingSystem.Api.Application.Factories.Implementations;
public class SavingsAccount : IAccount
{
    private int _NUMBER;

    public SavingsAccount(int number, double initialBalance)
    {
        _NUMBER = number;
        Balance = initialBalance;
    }

    public int Number => _NUMBER;
    public double Balance { get; private set; }
    public int GetNumber() => Number;
    public double GetBalance() => Balance;
}