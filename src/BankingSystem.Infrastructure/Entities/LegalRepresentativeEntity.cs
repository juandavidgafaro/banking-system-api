namespace BankingSystem.Infrastructure.Entities;
public class LegalRepresentativeEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public long Phone { get; set; }

    public static implicit operator LegalRepresentativeDomainEntity(LegalRepresentativeEntity entity)
    {
        LegalRepresentativeDomainEntity legalRepresentativeDomainEntity = default;

        if (entity != default)
        {
            legalRepresentativeDomainEntity = new(
                entity.Id,
                entity.Name,
                entity.IdentificationNumber,
                entity.IdentificationType,
                entity.Phone
            );
        }

        return legalRepresentativeDomainEntity;
    }
}
