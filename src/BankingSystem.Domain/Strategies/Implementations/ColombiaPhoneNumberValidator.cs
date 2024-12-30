namespace BankingSystem.Domain.Strategies.Implementations;
public class ColombiaPhoneNumberValidator : IPhoneNumberValidator
{
    public bool IsValid(string phoneNumber)
    {
        return phoneNumber.StartsWith("+57") && phoneNumber.Length == 13;
    }
}
