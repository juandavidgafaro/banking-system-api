namespace BankingSystem.Api.Application.Factories;
public interface IBankingProductFactory
{
    IAccount CreateAccount(IAccountNumberGeneratorService accountNumberGeneratorService, double initialBalance = 0);
}