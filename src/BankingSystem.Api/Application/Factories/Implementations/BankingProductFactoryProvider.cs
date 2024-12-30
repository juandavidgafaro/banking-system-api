namespace BankingSystem.Api.Application.Factories.Implementations;
public class BankingProductFactoryProvider : IBankingProductFactoryProvider
{
    public IBankingProductFactory GetFactory(string productType)
    {
        return ProductType.FromName(productType).Id switch
        {
            1 => new SavingsAccountFactory(),
            2 => new CheckingAccountFactory(),
            3 => new CDTFactory(),
            _ => throw new ArgumentException($"El tipo de cuenta: {productType} no es valida.")
        };
    }
}