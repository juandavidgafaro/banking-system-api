namespace BankingSystem.Domain.Entities;
public class LegalRepresentativeDomainEntity
{
    private const string _INVALID_NUMBER_FORMAT_ERROR_MESSAGE = "El número de celular del representante legal no tiene un formato valido.";

    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string Phone { get; set; }

    public LegalRepresentativeDomainEntity(
        IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy,
        string country,
        string name,
        string identificationNumber,
        string identificationType,
        string phone)
    {
        Name = name;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        PhoneNumberValidator(phoneNumberValidatorStrategy, country, phone);
        Phone = phone;
    }

    private void PhoneNumberValidator(IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy, string country, string phone)
    {
        if (!phoneNumberValidatorStrategy.Validate(country, phone))
        {
            throw new DomainException(_INVALID_NUMBER_FORMAT_ERROR_MESSAGE);
        }
    }
}