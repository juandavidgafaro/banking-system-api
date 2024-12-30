namespace BankingSystem.Api.Application.Factories.Implementations;
public class SavingsAccountFactory : IBankingProductFactory
{
    public IAccount CreateAccount(IAccountNumberGeneratorService accountNumberGeneratorService, double initialBalance = 0)
    {
        int number = accountNumberGeneratorService.GenerateNumber();

        var account = new SavingsAccount(number, initialBalance);
        return account;
    }
}