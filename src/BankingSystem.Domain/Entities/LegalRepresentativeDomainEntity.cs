namespace BankingSystem.Domain.Entities;
public class LegalRepresentativeDomainEntity
{
    private const string _INVALID_NUMBER_FORMAT_ERROR_MESSAGE = "El número de celular del representante legal no tiene un formato valido.";

    public int Id { get; set; }
    public string Name { get; set; }
    public long IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public Country Country { get; set; }
    public long Phone { get; set; }

    public LegalRepresentativeDomainEntity(int id, 
        string name,
        long identificationNumber,
        string identificationType,
        Country country,
        long phone)
    {
        Id = id;
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Phone = phone;
        Country = country;
    }

    public LegalRepresentativeDomainEntity(
        IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy,
        Country country,
        string name,
        long identificationNumber,
        string identificationType,
        long phone)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PhoneNumberValidator(phoneNumberValidatorStrategy, country, phone);
        Country = country;
        Phone = phone;
    }

    private void PhoneNumberValidator(IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy, Country country, long phone)
    {
        if (!phoneNumberValidatorStrategy.Validate(country, phone))
        {
            throw new DomainException(_INVALID_NUMBER_FORMAT_ERROR_MESSAGE);
        }
    }
}