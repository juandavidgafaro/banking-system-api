namespace BankingSystem.Domain.Strategies;
public interface IPhoneNumberValidator
{
    bool IsValid(string phoneNumber);
}