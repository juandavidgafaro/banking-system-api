using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingSystem.Domain.Sevices;
public static class ProductInterestService
{
    public readonly static double _SAVINGS_ACCOUNT_MONTHLY_INTEREST_RATE  = 0.4;
    public static double GenerateInterestPercentage(ProductType productType)
    {
        double percentage = 0;

        if (productType.Id == ProductType.SavingsAccount.Id)
        {
            percentage = _SAVINGS_ACCOUNT_MONTHLY_INTEREST_RATE;
        }

        return percentage;
    }

    public static double GetInterestByPeriodOfTime(int months, double initialBalance, double monthlyInterestRate)
    {
        return initialBalance * monthlyInterestRate * months;
    }
}
