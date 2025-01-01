namespace BankingSystem.Domain.Sevices;
public static class WithdrawalValidationService
{
    private const string _INVALID_TRANSACTION_TYPE = "Esta transacción no es permitida hasta cumplirse la fecha de expiración.";
    private const string _INSUFFICIENT_FUNDS_MESSAGE = "Fondos insuficientes.";

    public static double ValidateAndReturnCurrentBalance(double currentBalance, double withdrawalAmount)
    {
        if (withdrawalAmount > currentBalance)
        {
            throw new DomainException(_INSUFFICIENT_FUNDS_MESSAGE);
        }

        return currentBalance - withdrawalAmount;
    }

    public static void ValidateByProductType(ProductDomainEntity product, TransactionType transactionType)
    {
        if (product.Type.Equals(ProductType.CertificateOfDeposit))
        {
            DateTime currentDate = DateTime.Now;

            bool expirationDateMet = currentDate > product.ExpirationDate;

            if (!expirationDateMet && transactionType.Equals(TransactionType.Withdraw))
            {
                throw new DomainException(_INVALID_TRANSACTION_TYPE);
            }
        }
    }
}
