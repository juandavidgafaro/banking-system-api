namespace BankingSystem.Api.Application.Handlers;
public class GetAverageBalanceByProductTypeHandler : IRequestHandler<GetAverageBalanceByProductTypeQuery, AverageBalanceByProductTypeQueryResponseDTO>
{
    private readonly IProductRepository _productRepository;

    public GetAverageBalanceByProductTypeHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public  async Task<AverageBalanceByProductTypeQueryResponseDTO> Handle(GetAverageBalanceByProductTypeQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductEntity> savingsAccounts = await _productRepository.GetAllProductsByType(ProductType.SavingsAccount.Name);
        IEnumerable<ProductEntity> checkingAccounts = await _productRepository.GetAllProductsByType(ProductType.CheckingAccount.Name);
        IEnumerable<ProductEntity> cDTS = await _productRepository.GetAllProductsByType(ProductType.CertificateOfDeposit.Name);

        AverageBalanceByProductTypeQueryResponseDTO averages = new()
        {
            SavingsAccount = GetAverange(savingsAccounts),
            CheckingAccount = GetAverange(checkingAccounts),
            CDT = GetAverange(cDTS),
        };

        return averages;
    }

    private static double GetAverange(IEnumerable<ProductEntity> products)
    {
        double averange = 0;

        if (products.Count() != 0)
        {
            averange = products.Average(product => product.AccountBalance);
        }

        return averange;
    }
}