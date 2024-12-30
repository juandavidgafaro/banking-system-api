namespace BankingSystem.Api.Application.Factories.Implementations;
public class CDT : IAccount
{
    private int _NUMBER;
    public CDT(int number, double balance)
    {
        _NUMBER = number;
        Balance = balance;
    }

    public double Balance { get; private set; }
    public int Number => _NUMBER;
    public int GetNumber() => Number;
    public double GetBalance() => Balance;
}
