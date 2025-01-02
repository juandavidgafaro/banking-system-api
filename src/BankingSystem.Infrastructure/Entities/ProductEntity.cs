namespace BankingSystem.Infrastructure.Entities;
public class ProductEntity
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public int TermMonths { get; set; }

    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public int ClientIdentificationNumber { get; set; }
    public string ClientIdentificationType { get; set; }
    public string ClientPersonType { get; set; }
    public string ClientCountry { get; set; }


    public int AccountId { get; set; }
    public long AccountNumber { get; set; }
    public int AccountBalance { get; set; }


    public static implicit operator ProductDomainEntity(ProductEntity entity)
    {
        ProductDomainEntity productDomainEntity = default;

        if (entity != default)
        {
            productDomainEntity = new(
               entity.Id,
               ProductType.FromName(entity.Type),
               ProductStatus.FromName(entity.Status),
               new ClientDomainEntity(
                   entity.ClientId,
                   entity.ClientName,
                   entity.ClientIdentificationNumber,
                   entity.ClientIdentificationType,
                   PersonType.FromName(entity.ClientPersonType),
                   Country.FromName(entity.ClientCountry)
               ),
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