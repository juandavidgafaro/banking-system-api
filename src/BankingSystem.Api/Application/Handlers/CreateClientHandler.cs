namespace BankingSystem.Api.Application.Handlers;
public class CreateClientHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Create;
    private readonly IBankingProductFactoryProvider _bankingProductFactoryProvider;
    private readonly IAccountNumberGeneratorService _accountNumberGeneratorService;
    private readonly IPhoneNumberValidatorStrategy _phoneNumberValidatorStrategy;
    private readonly IProductSevice _productSevice;
    private readonly IClientRepository _productRepository;
    private readonly IClientService _clientService;
    private readonly IBuildAccountService _buildAccountService;

    public CreateClientHandler(
        IBankingProductFactoryProvider bankingProductFactoryProvider,
        IAccountNumberGeneratorService accountNumberGeneratorService,
        IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy,
        IClientRepository productRepository,
        IClientService clientService,
        IProductSevice productSevice,
        IBuildAccountService buildAccountService)
    {
        _bankingProductFactoryProvider = bankingProductFactoryProvider;
        _accountNumberGeneratorService = accountNumberGeneratorService;
        _phoneNumberValidatorStrategy = phoneNumberValidatorStrategy;
        _productRepository = productRepository;
        _clientService = clientService;
        _productSevice = productSevice;
        _buildAccountService = buildAccountService;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        AccountDomainEntity account = _buildAccountService.BuildByProductType(request.Body.Client.Product.Type, (request.Body.Client.Product.MoneyForAccount, request.Body.Client.Product.TermMonths));

        ProductDomainEntity product;
        ClientDomainEntity clientCreated;

        ClientDomainEntity client = new(
            request.Body.Client.Name,
            request.Body.Client.IdentificationNumber,
            request.Body.Client.IdentificationType,
            request.Body.Client.PersonType
        );

        double monthlyInterestPercentage = request.Body.Client.Product.MonthlyInterestPercentage > 0 ?
            request.Body.Client.Product.MonthlyInterestPercentage
            : ProductTypeInterestRateService.GenerateInterestPercentage(ProductType.FromName(request.Body.Client.Product.Type));

        if (PersonType.Business.Name == request.Body.Client.PersonType)
        {
            LegalRepresentativeDomainEntity legalRepresentative = new(
            _phoneNumberValidatorStrategy,
            request.Body.Client.Country,
            request.Body.Client.LegalRepresentative.Name,
            request.Body.Client.LegalRepresentative.IdentificationNumber,
            request.Body.Client.LegalRepresentative.IdentificationType,
            request.Body.Client.LegalRepresentative.Phone);

            client.LegalRepresentative = legalRepresentative;

            clientCreated = await _clientService.CreateBusinessClient(client);
        }
        else
        {
            clientCreated = await _clientService.CreatePersonalClient(client);
        }

        product = new(
            ProductStatus.Active,
            request.Body.Client.Product.Type,
            clientCreated.Id,
            monthlyInterestPercentage,
            account,
            _TRANSACTION_TYPE);

        TransactionDomainEntity transaction = new()
        {
            OriginDate = DateTime.Now,
            Type = TransactionType.Create,
            Serial = Guid.NewGuid()
        };

        await _productSevice.Create(product, transaction);

        return clientCreated.Id;
    }
}
