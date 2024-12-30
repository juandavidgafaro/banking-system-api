namespace BankingSystem.Infrastructure.Services.Implementations;
public class AccountNumberGeneratorService : IAccountNumberGeneratorService
{
    public int GenerateNumber()
    {
        IRandomizerString randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex
        {
            Pattern = @"\d{15}"
        });

        string? accountNumber = randomizer.Generate();

        if (string.IsNullOrEmpty(accountNumber))
        {
            throw new ArgumentException();
        }

        return int.Parse(accountNumber);
    }
}
