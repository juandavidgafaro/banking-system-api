namespace BankingSystem.Api.Application.Factories.Implementations;
public class CheckingAccount : IAccount
{
    private int _NUMBER;

    public CheckingAccount(int number, double initialBalance)
    {
        _NUMBER = number;
        Balance = initialBalance;
    }

    public double Balance { get; private set; }
    public int Number => _NUMBER;
    public int GetNumber() => Number;
    public double GetBalance() => Balance;
}