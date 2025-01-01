namespace BankingSystem.Infrastructure.Entities;
public class ProductEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public long AccountNumber { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public int TermMonths { get; set; }
    public int AccountBalance { get; set; }
    public int ClientId { get; set; }
    public int AccountId { get; set; }

    public static implicit operator ProductDomainEntity(ProductEntity entity)
    {
        ProductDomainEntity productDomainEntity = default;

        if (entity != default)
        {
            productDomainEntity = new(
               entity.Id,
               ProductType.FromName(entity.Type),
               ProductStatus.FromName(entity.Status),
               new AccountDomainEntity(
                   entity.AccountId,
                   entity.AccountNumber,
                   entity.AccountBalance
               )
           );
        }

        return productDomainEntity;
    }
}