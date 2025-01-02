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
        ClientDomainEntity clientCreated;

        ClientDomainEntity client = new(
            request.Body.Name,
            request.Body.IdentificationNumber,
            request.Body.IdentificationType,
            PersonType.FromName(request.Body.PersonType),
            Country.FromName(request.Body.Country)
        );

        if(PersonType.Natural == PersonType.FromName(request.Body.PersonType))
        {
            clientCreated = await _clientService.CreatePersonalClient(client);

            return clientCreated.Id;
        }

        if(request.Body.LegalRepresentative == default)
        {
            throw new BadRequestException($"Los datos del representante legal son obligatorios en los clientes tipo: {request.Body.PersonType}");
        }

        LegalRepresentativeDomainEntity legalRepresentative = new(
            _phoneNumberValidatorStrategy,
            Country.FromName(request.Body.Country),
            request.Body.LegalRepresentative.Name,
            request.Body.LegalRepresentative.IdentificationNumber,
            request.Body.LegalRepresentative.IdentificationType,
            request.Body.LegalRepresentative.Phone);

        client.LegalRepresentative = legalRepresentative;

        clientCreated = await _clientService.CreateBusinessClient(client);

        return clientCreated.Id;
    }
}
