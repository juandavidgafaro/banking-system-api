namespace BankingSystem.Api.Application.Factories.Implementations;

public class CDTFactory : IBankingProductFactory
{
    public IAccount CreateAccount(IAccountNumberGeneratorService accountNumberGeneratorService, double initialBalance = 0)
    {
        long number = accountNumberGeneratorService.GenerateNumber();

        ValidateInitialBalance(initialBalance);

        return new CDT(number, initialBalance);
    }

    private void ValidateInitialBalance(double initialBalance)
    {
        if (initialBalance < 1)
        {
            throw new InvalidOperationException("El monto inicial no es el indicado para la creación del producto.");
        }
    }
}

