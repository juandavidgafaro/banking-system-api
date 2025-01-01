namespace BankingSystem.Api.Extensions;
public static class WebApplicationExtension
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddMediatorExtension();
        builder.Services.AddSwaggerExtension();
        builder.Services.AddCorsExtension();
        builder.Services.AddInfrastructureServices(builder.Configuration);

        builder.Services.AddTransient<IBankingProductFactoryProvider, BankingProductFactoryProvider>();
        builder.Services.AddTransient<IPhoneNumberValidatorStrategy, PhoneNumberValidatorStrategy>();
        builder.Services.AddTransient<IBuildAccountService, BuildAccountService>();
        builder.Services.AddTransient<ITransferBalanceToAnotherAccountService, TransferBalanceToAnotherAccountService>();

        return builder.Build();
    }

    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking System API v1");
            c.RoutePrefix = string.Empty;
        }
        );
        app.UseCors("mycors");
        app.UseHttpsRedirection();
        app.UseMiddleware<ErrorHandlerMiddleware>(new Dictionary<Type, IExceptionHandler>
            {
                {typeof(BadRequestException), new BadRequestExceptionHandler() },
                {typeof(InvalidOperationException), new InvalidOperationExceptionHandler() },
                {typeof(DomainException), new DomainExceptionHandler() },
                {typeof(InfrastructureException), new InfrastructureExceptionHandler() },
                {typeof(NotFoundException), new NotFoundExceptionHandler() }
            }
        );
        return app;
    }
}