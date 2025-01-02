namespace BankingSystem.Infrastructure.Entities;
public class ClientEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string PersonType { get; set; }
    public string Country { get; set; }
    public int? LegalRepresentativeId { get; set; }


    public static implicit operator ClientDomainEntity(ClientEntity entity)
    {
        ClientDomainEntity clientDomainEntity = default;

        if (entity != default)
        {
            clientDomainEntity = new(
                entity.Id,
                entity.Name,
                entity.IdentificationNumber,
                entity.IdentificationType,
                Domain.Enums.PersonType.FromName(entity.PersonType),
                Domain.Enums.Country.FromName(entity.Country)
            );
        }

        return clientDomainEntity;
    }
}