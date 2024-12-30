namespace BankingSystem.Domain.Strategies;
public interface IPhoneNumberValidator
{
    bool IsValid(long phoneNumber);
}