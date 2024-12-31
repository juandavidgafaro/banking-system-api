namespace BankingSystem.Api.Application.Handlers;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Create;

    private readonly IClientRepository _clientRepository;
    private readonly IBuildAccountService _buildAccountService;
    private readonly IProductSevice _productSevice;
    private readonly IProduct _product;

    public CreateProductHandler(IClientRepository clientRepository, 
        IBuildAccountService buildAccountService, 
        IProductSevice productSevice, 
        IProduct product)
    {
        _clientRepository = clientRepository;
        _buildAccountService = buildAccountService;
        _productSevice = productSevice;
        _product = product;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ClientEntity client = await _clientRepository.GetClientById(request.Body.Product.Client.Id);

        if (client == default)
        {
            throw new ArgumentException(string.Format("El cliente con Id {0} no existe.", request.Body.Product.Client.Id));
        }

        AccountDomainEntity account = _buildAccountService.BuildByProductType(request.Body.Product.Type, (request.Body.Product.MoneyForAccount, request.Body.Product.TermMonths));

        double monthlyInterestPercentage = request.Body.Product.MonthlyInterestPercentage > 0 ? 
            request.Body.Product.MonthlyInterestPercentage 
            : ProductTypeInterestRateService.GenerateInterestPercentage(ProductType.FromName(request.Body.Product.Type));

        ProductDomainEntity product = new(
            _product,
            ProductStatus.Active,
            request.Body.Product.Type,
            request.Body.Product.Client.Id,
            monthlyInterestPercentage,
            account,
            _TRANSACTION_TYPE
        );

        TransactionDomainEntity transaction = new()
        {
            OriginDate = DateTime.Now,
            Type = TransactionType.Create,
            Serial = Guid.NewGuid()
        };

        return await _productSevice.Create(product, transaction);
    }
}
