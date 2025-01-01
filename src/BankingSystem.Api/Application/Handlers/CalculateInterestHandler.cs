namespace BankingSystem.Api.Application.Handlers;

public class CalculateInterestHandler : IRequestHandler<CalculateInterestCommand, double>
{
    public async Task<double> Handle(CalculateInterestCommand request, CancellationToken cancellationToken)
    {
        double interestRate = ProductInterestService.GenerateInterestPercentage(ProductType.FromName(request.Body.ProductType));

        double finalBalance;

        if (interestRate == ProductInterestService._SAVINGS_ACCOUNT_MONTHLY_INTEREST_RATE)
        {
            finalBalance = ProductInterestService.GetInterestByPeriodOfTime(request.Body.Months, request.Body.InitialBalance, interestRate);

            return finalBalance;
        }

        finalBalance = ProductInterestService.GetInterestByPeriodOfTime(request.Body.Months, request.Body.InitialBalance, request.Body.InterestRate);

        return finalBalance;
    }
}
