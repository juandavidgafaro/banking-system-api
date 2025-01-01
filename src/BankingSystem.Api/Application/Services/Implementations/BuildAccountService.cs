namespace BankingSystem.Api.Application.Services.Implementations;
public class BuildAccountService : IBuildAccountService
{
    private readonly IBankingProductFactoryProvider _bankingProductFactoryProvider;
    private readonly IAccountNumberGeneratorService _accountNumberGeneratorService;

    public BuildAccountService(IBankingProductFactoryProvider bankingProductFactoryProvider, IAccountNumberGeneratorService accountNumberGeneratorService)
    {
        _bankingProductFactoryProvider = bankingProductFactoryProvider;
        _accountNumberGeneratorService = accountNumberGeneratorService;
    }

    public AccountDomainEntity BuildByProductType(string productType, (double Balance, int TermMonth) initialData)
    {
        IBankingProductFactory productFartory = _bankingProductFactoryProvider.GetFactory(productType);

        Factories.IAccount accounDetails;
        AccountDomainEntity account;

        if (ProductType.FromName(productType) == ProductType.CertificateOfDeposit)
        {
            accounDetails = productFartory.CreateAccount(_accountNumberGeneratorService, initialData.Balance);

            account = new(
                accounDetails.GetNumber(),
                accounDetails.GetBalance(),
                DateTime.Now.AddMonths(initialData.TermMonth)
            );
        }
        else
        {
            accounDetails = productFartory.CreateAccount(_accountNumberGeneratorService);
            account = new(
                accounDetails.GetNumber(),
                accounDetails.GetBalance()
            );
        }

        return account;
    }
}