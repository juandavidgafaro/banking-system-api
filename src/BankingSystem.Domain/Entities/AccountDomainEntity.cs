namespace BankingSystem.Domain.Entities;
public class AccountDomainEntity
{
    public int Id { get; set; }
    public long Number { get; set; }
    public double Balance { get; set; }
    public DateTime OriginDate { get; set; }
    public DateTime? CancellationDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public DateTime DateLastModification { get; set; }

    public AccountDomainEntity(int id, long number, double balance)
    {
        Id = id;
        Number = number;
        Balance = balance;
    }
    public AccountDomainEntity(long number, double balance)
    {
        Number = number;
        Balance = balance;
    }

    public AccountDomainEntity(long number, double balance, DateTime maturityDate)
    {
        Number = number;
        Balance = balance;
        MaturityDate = maturityDate;
    }
}
