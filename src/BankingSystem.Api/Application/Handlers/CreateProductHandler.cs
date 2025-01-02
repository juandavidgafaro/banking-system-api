namespace BankingSystem.Api.Application.Handlers;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Create;

    private readonly IClientRepository _clientRepository;
    private readonly IBuildAccountService _buildAccountService;
    private readonly IProductSevice _productSevice;
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IClientRepository clientRepository, 
        IBuildAccountService buildAccountService, 
        IProductSevice productSevice,
        IProductRepository product)
    {
        _clientRepository = clientRepository;
        _buildAccountService = buildAccountService;
        _productSevice = productSevice;
        _productRepository = product;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ClientEntity client = await _clientRepository.GetClientById(request.Body.ClientId);

        if (client == default)
        {
            throw new NotFoundException(string.Format("El cliente con Id {0} no existe.", request.Body.ClientId));
        }

        AccountDomainEntity account = _buildAccountService.BuildByProductType(request.Body.Type, (request.Body.InitialBalance, request.Body.TermMonths));

        double monthlyInterestPercentage = request.Body.MonthlyInterestPercentage > 0 ? 
            request.Body.MonthlyInterestPercentage 
            : ProductInterestService.GenerateInterestPercentage(ProductType.FromName(request.Body.Type));

        ProductDomainEntity product = new(
            _productRepository,
            ProductStatus.Active,
            ProductType.FromName(request.Body.Type),
            request.Body.ClientId,
            request.Body.TermMonths,
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
