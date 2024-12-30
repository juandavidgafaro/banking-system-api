namespace BankingSystem.Api.Extensions;
public static class MediatorExtension
{
    public static IServiceCollection AddMediatorExtension(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}