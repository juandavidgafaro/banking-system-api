namespace BankingSystem.Domain.Strategies;
public interface IPhoneNumberValidatorStrategy
{
    bool Validate(Country country, long phoneNumber);
}