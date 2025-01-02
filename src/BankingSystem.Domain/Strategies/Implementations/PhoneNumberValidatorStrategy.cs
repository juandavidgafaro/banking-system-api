namespace BankingSystem.Domain.Strategies.Implementations;
public class PhoneNumberValidatorStrategy : IPhoneNumberValidatorStrategy
{
    private readonly Dictionary<string, IPhoneNumberValidator> _validators;

    public PhoneNumberValidatorStrategy()
    {
        _validators = new Dictionary<string, IPhoneNumberValidator>
        {
            { Country.Colombia.Name, new ColombiaPhoneNumberValidator() },
        };
    }

    public bool Validate(Country country, long phoneNumber)
    {
        if (_validators.TryGetValue(country.Name, out var validator))
        {
            return validator.IsValid(phoneNumber);
        }

        throw new DomainException($"No se encontró un validador para el formato del numero celular, por el país: {country.Name}");
    }
}
