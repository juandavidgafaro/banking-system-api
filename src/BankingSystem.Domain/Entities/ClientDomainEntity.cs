namespace BankingSystem.Domain.Entities;
public class ClientDomainEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string PersonType { get; set; }
    public LegalRepresentativeDomainEntity? LegalRepresentative { get; set; }

    public ClientDomainEntity(
        int id,
        string name,
        int identificationNumber,
        string identificationType,
        string personType)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
    }
    public ClientDomainEntity(

        string name,
        int identificationNumber,
        string identificationType,
        string personType)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PersonType = personType;
    }

    public ClientDomainEntity(
        int id,
        string name,
        int identificationNumber,
        string identificationType,
        string personType,
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