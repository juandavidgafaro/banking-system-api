namespace BankingSystem.Api.Application.Factories.Implementations;
public class CDT : IAccount
{
    private long _NUMBER;
    public CDT(long number, double balance)
    {
        _NUMBER = number;
        Balance = balance;
    }

    public double Balance { get; private set; }
    public long Number => _NUMBER;
    public long GetNumber() => Number;
    public double GetBalance() => Balance;
}
