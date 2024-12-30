namespace BankingSystem.Api.Application.Factories.Implementations;
public class CheckingAccountFactory : IBankingProductFactory
{
    public IAccount CreateAccount(IAccountNumberGeneratorService accountNumberGeneratorService, double initialBalance = 0)
    {
        int number = accountNumberGeneratorService.GenerateNumber();

        var account = new CheckingAccount(number, initialBalance);
        return account;
    }
}