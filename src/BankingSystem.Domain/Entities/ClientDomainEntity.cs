namespace BankingSystem.Domain.Entities;
public class ClientDomainEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public PersonType PersonType { get; set; }
    public Country Country { get; set; }
    public LegalRepresentativeDomainEntity? LegalRepresentative { get; set; }

    public ClientDomainEntity(
        int id,
        string name,
        int identificationNumber,
        string identificationType,
        PersonType personType,
        Country country)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
        Country = country;
    }
    public ClientDomainEntity(
        string name,
        int identificationNumber,
        string identificationType,
        PersonType personType,
        Country country)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
        Country = country;
    }

    public ClientDomainEntity(
        int id,
        string name,
        int identificationNumber,
        string identificationType,
        PersonType personType,
        LegalRepresentativeDomainEntity legalRepresentative)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
        LegalRepresentative = legalRepresentative;
    }
}