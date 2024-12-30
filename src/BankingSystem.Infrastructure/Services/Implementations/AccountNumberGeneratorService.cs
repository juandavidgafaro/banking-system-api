namespace BankingSystem.Infrastructure.Services.Implementations;
public class AccountNumberGeneratorService : IAccountNumberGeneratorService
{
    public long GenerateNumber()
    {
        IRandomizerString randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex
        {
            Pattern = @"\d{10}"
        });

        string? accountNumber = randomizer.Generate();

        if (string.IsNullOrEmpty(accountNumber))
        {
            throw new ArgumentException();
        }

        return long.Parse(accountNumber);
    }
}
