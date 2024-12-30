namespace BankingSystem.Domain.Strategies.Implementations;
public class ColombiaPhoneNumberValidator : IPhoneNumberValidator
{
    public bool IsValid(long phoneNumber)
    {
        return phoneNumber.ToString().Length == 10;
    }
}
