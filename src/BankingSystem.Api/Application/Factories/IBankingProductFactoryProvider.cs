namespace BankingSystem.Api.Application.Factories;
public interface IBankingProductFactoryProvider
{
    IBankingProductFactory GetFactory(string productType);
}
