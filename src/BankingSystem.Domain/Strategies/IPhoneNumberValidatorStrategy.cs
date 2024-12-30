namespace BankingSystem.Domain.Strategies;
public interface IPhoneNumberValidatorStrategy
{
    bool Validate(string country, long phoneNumber);
}