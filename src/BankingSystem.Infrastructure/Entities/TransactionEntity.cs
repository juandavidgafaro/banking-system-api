namespace BankingSystem.Infrastructure.Entities;
public class TransactionEntity
{
    public int Id { get; set; }
    public DateTime OriginDate { get; set; }
    public string Type { get; set; }
    public Guid Serial { get; set; }
    public int ProductId { get; set; }
}
