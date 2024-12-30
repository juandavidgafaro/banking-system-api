namespace BankingSystem.Domain.Strategies.Implementations;
public class PhoneNumberValidatorStrategy : IPhoneNumberValidatorStrategy
{
    private readonly Dictionary<string, IPhoneNumberValidator> _validators;

    public PhoneNumberValidatorStrategy()
    {
        _validators = new Dictionary<string, IPhoneNumberValidator>
        {
            { "Colombia", new ColombiaPhoneNumberValidator() },
        };
    }

    public bool Validate(string country, string phoneNumber)
    {
        if (_validators.TryGetValue(country, out var validator))
        {
            return validator.IsValid(phoneNumber);
        }

        throw new DomainException($"No se encontró un validador para el país: {country}");
    }
}
