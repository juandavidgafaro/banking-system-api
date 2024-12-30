namespace BankingSystem.Domain.Sevices;
public static class DepositValidationService
{
    private const string _INSUFFICIENT_AMOUNT_MESSAGE = "El monto a depositar no es valido.";
    private const double _AMOUNT_DEFAULT = 0;

    public static void ValidateAmountToDeposit(double depositAmount)
    {
        if (_AMOUNT_DEFAULT > depositAmount)
        {
            throw new DomainException(_INSUFFICIENT_AMOUNT_MESSAGE);
        }
    }

    public static double GetTotalAmount(double currentBalance, double depositAmount)
    {
        return currentBalance + depositAmount;
    }
}