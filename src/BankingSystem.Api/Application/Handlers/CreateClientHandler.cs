namespace BankingSystem.Api.Application.Handlers;
public class CreateClientHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Create;
    private readonly IBankingProductFactoryProvider _bankingProductFactoryProvider;
    private readonly IAccountNumberGeneratorService _accountNumberGeneratorService;
    private readonly IPhoneNumberValidatorStrategy _phoneNumberValidatorStrategy;
    private readonly IProductSevice _productSevice;
    private readonly IProductRepository _productRepository;
    private readonly IClientService _clientService;

    public CreateClientHandler(
        IBankingProductFactoryProvider bankingProductFactoryProvider,
        IAccountNumberGeneratorService accountNumberGeneratorService,
        IPhoneNumberValidatorStrategy phoneNumberValidatorStrategy,
        IProductRepository productRepository,
        IClientService clientService,
        IProductSevice productSevice)
    {
        _bankingProductFactoryProvider = bankingProductFactoryProvider;
        _accountNumberGeneratorService = accountNumberGeneratorService;
        _phoneNumberValidatorStrategy = phoneNumberValidatorStrategy;
        _productRepository = productRepository;
        _clientService = clientService;
        _productSevice = productSevice;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        IBankingProductFactory productFartory = _bankingProductFactoryProvider.GetFactory(request.Body.Client.Product.Type);

        IAccount accounDetails;
        AccountDomainEntity account;

        if (ProductType.FromName(request.Body.Client.Product.Type) == ProductType.CertificateOfDeposit)
        {
            accounDetails = productFartory.CreateAccount(_accountNumberGeneratorService, request.Body.Client.Product.MoneyForAccount);

            account = new(
                accounDetails.GetNumber(),
                accounDetails.GetBalance(),
                DateTime.Now.AddMonths(request.Body.Client.Product.TermMonths)
            );
        }
        else
        {
            accounDetails = productFartory.CreateAccount(_accountNumberGeneratorService);
            account = new(
                accounDetails.GetNumber(),
                accounDetails.GetBalance()
            );
        }

        ProductDomainEntity product;
        ClientDomainEntity clientCreated;

        ClientDomainEntity client = new(
            request.Body.Client.Name,
            request.Body.Client.IdentificationNumber,
            request.Body.Client.IdentificationType,
            request.Body.Client.PersonType
        );

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

            product = new(
            ProductStatus.Active,
            request.Body.Client.Product.Type,
            clientCreated.Id,
            ProductTypeInterestRateService.GenerateInterestPercentage(ProductType.FromName(request.Body.Client.Product.Type)),
            account,
            _TRANSACTION_TYPE);

            TransactionDomainEntity transaction = new()
            {
                OriginDate = DateTime.Now,
                Type = TransactionType.Create,
                Serial = Guid.NewGuid()
            };

            await _productSevice.Create(product, transaction);
        }
        else
        {
            clientCreated = await _clientService.CreatePersonalClient(client);

            product = new(
            ProductStatus.Active,
            request.Body.Client.Product.Type,
            clientCreated.Id,
            ProductTypeInterestRateService.GenerateInterestPercentage(ProductType.FromName(request.Body.Client.Product.Type)),
            account,
            _TRANSACTION_TYPE);

            TransactionDomainEntity transaction = new()
            {
                OriginDate = DateTime.Now,
                Type = TransactionType.Create,
                Serial = Guid.NewGuid()
            };

            await _productSevice.Create(product, transaction);
        }

        return clientCreated.Id;
    }
}
