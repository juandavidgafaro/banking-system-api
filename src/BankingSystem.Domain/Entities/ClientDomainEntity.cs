namespace BankingSystem.Domain.Entities;
public class ClientDomainEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string PersonType { get; set; }
    public LegalRepresentativeDomainEntity LegalRepresentative { get; set; }
    public ProductDomainEntity Product { get; set; }

    public ClientDomainEntity(
        string name,
        string identificationNumber,
        string identificationType,
        string personType,
        ProductDomainEntity product)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
        Product = product;
    }

    public ClientDomainEntity(
        string name,
        string identificationNumber,
        string identificationType,
        string personType,
        LegalRepresentativeDomainEntity legalRepresentative,
        ProductDomainEntity product)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
        LegalRepresentative = legalRepresentative;
        Product = product;
    }
}