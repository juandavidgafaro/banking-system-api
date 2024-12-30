namespace BankingSystem.Domain.Entities;
public class TransactionDomainEntity
{
    public int Id { get; set; }
    public DateTime OriginDate { get; set; }
    public TransactionType Type { get; set; }
    public int ProductId { get; set; }
    public Guid Serial { get; set; }
}
