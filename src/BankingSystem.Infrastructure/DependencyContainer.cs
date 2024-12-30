using BankingSystem.Infrastructure.Services.Implementations;

namespace BankingSystem.Infrastructure;
public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ILegalRepresentativeRepository, LegalRepresentativeRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();

        services.AddTransient<IAccountNumberGeneratorService, AccountNumberGeneratorService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddTransient<IProductSevice, ProductSevice>();

        return services;
    }
}