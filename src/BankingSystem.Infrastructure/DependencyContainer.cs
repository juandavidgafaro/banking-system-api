using BankingSystem.Infrastructure.Interfaces;

namespace BankingSystem.Infrastructure;
public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<InfrastructureSettings>(configuration);

        services.AddTransient<IClient, ClientRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IProduct, ProductRepository>();
        services.AddTransient<IAccount, AccountRepository>();
        services.AddTransient<ILegalRepresentative, LegalRepresentativeRepository>();
        services.AddTransient<ITransaction, TransactionRepository>();

        services.AddTransient<IAccountNumberGeneratorService, AccountNumberGeneratorService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddTransient<IProductSevice, ProductSevice>();

        return services;
    }
}