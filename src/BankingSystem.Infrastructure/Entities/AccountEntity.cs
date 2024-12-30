namespace BankingSystem.Infrastructure.Entities;
public class AccountEntity
{
    public int Id { get; set; }
    public int Number { get; set; }
    public double Balance { get; set; }
    public DateTime OriginDate { get; set; }
    public DateTime CancellationDate { get; set; }
    public DateTime MaturityDate { get; set; }
    public DateTime DateLastModification { get; set; }
}
