namespace BankingSystem.Infrastructure.Entities;
public class AccountEntity
{
    public int Id { get; set; }
    public long Number { get; set; }
    public double Balance { get; set; }
    public DateTime OriginDate { get; set; }
    public DateTime CancellationDate { get; set; }
    public DateTime MaturityDate { get; set; }
    public DateTime DateLastModification { get; set; }

    public static implicit operator AccountDomainEntity(AccountEntity entity)
    {
        AccountDomainEntity accountDomainEntity = default;

        if (entity != default)
        {
            accountDomainEntity = new(
                entity.Id,
                entity.Number,
                entity.Balance
            );
        }

        return accountDomainEntity;
    }
}
