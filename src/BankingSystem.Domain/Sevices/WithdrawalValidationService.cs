namespace BankingSystem.Domain.Sevices;
public static class WithdrawalValidationService
{
    private const string _INSUFFICIENT_FUNDS_MESSAGE = "Fondos insuficientes.";

    public static double ValidateAndReturnCurrentBalance(double currentBalance, double withdrawalAmount)
    {
        if (withdrawalAmount > currentBalance)
        {
            throw new DomainException(_INSUFFICIENT_FUNDS_MESSAGE);
        }

        return currentBalance - withdrawalAmount;
    }
}
