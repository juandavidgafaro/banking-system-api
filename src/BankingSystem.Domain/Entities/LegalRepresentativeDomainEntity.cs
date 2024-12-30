namespace BankingSystem.Domain.Entities;
public class LegalRepresentativeDomainEntity
{
    private const string _INVALID_NUMBER_FORMAT_ERROR_MESSAGE = "El número de celular del representante legal no tiene un formato valido.";

    public int Id { get; set; }
    public string Name { get; set; }
    public long IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public long Phone { get; set; }

    public LegalRepresentativeDomainEntity(int id, 
        string name,
        long identificationNumber,
        string identificationType, 
        long phone)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Phone = phone;
    }

    public LegalRepresentativeDomainEntity(
        IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy,
        string country,
        string name,
        long identificationNumber,
        string identificationType,
        long phone)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PhoneNumberValidator(phoneNumberValidatorStrategy, country, phone);
        Phone = phone;
    }

    private void PhoneNumberValidator(IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy, string country, long phone)
    {
        if (!phoneNumberValidatorStrategy.Validate(country, phone))
        {
            throw new DomainException(_INVALID_NUMBER_FORMAT_ERROR_MESSAGE);
        }
    }
}