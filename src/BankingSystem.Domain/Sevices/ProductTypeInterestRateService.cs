namespace BankingSystem.Domain.Sevices;
public static class ProductTypeInterestRateService
{
    public static double GenerateInterestPercentage(ProductType productType)
    {
        double percentage = 0;

        if (productType.Id == ProductType.SavingsAccount.Id)
        {
            percentage = 0.4;
        }

        return percentage;
    }
}
