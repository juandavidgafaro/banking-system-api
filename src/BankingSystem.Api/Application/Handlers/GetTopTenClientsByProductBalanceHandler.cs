namespace BankingSystem.Api.Application.Handlers;
public class GetTopTenClientsByProductBalanceHandler : IRequestHandler<GetTopTenClientsByProductBalanceQuery, TopTenClientsByProductBalanceQueryDTO>
{
    private readonly int _RANGE_TOP = 10;
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;

    public GetTopTenClientsByProductBalanceHandler(IProductRepository productRepository, IClientRepository clientInfrastructureRepository)
    {
        _productRepository = productRepository;
        _clientRepository = clientInfrastructureRepository;
    }

    public async Task<TopTenClientsByProductBalanceQueryDTO> Handle(GetTopTenClientsByProductBalanceQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductEntity> savingsAccounts = await _productRepository.GetAllProductsByType(ProductType.SavingsAccount.Name);
        IEnumerable<ProductEntity> checkingAccounts = await _productRepository.GetAllProductsByType(ProductType.CheckingAccount.Name);
        IEnumerable<ProductEntity> cDTS = await _productRepository.GetAllProductsByType(ProductType.CertificateOfDeposit.Name);

        savingsAccounts.OrderByDescending(p => p.AccountBalance).Take(ValidateNumberOfCurrentClientsForTop(savingsAccounts.Count()));
        checkingAccounts.OrderByDescending(p => p.AccountBalance).Take(ValidateNumberOfCurrentClientsForTop(checkingAccounts.Count()));
        cDTS.OrderByDescending(p => p.AccountBalance).Take(ValidateNumberOfCurrentClientsForTop(cDTS.Count()));

        IEnumerable<ClientDTO> topClientsBySavingsAccounts = await GetClientsInformation(savingsAccounts.Select(p => p.ClientId).ToArray());
        IEnumerable<ClientDTO> topClientsByCheckingAccounts = await GetClientsInformation(checkingAccounts.Select(p => p.ClientId).ToArray());
        IEnumerable<ClientDTO> topClientsByCDTs = await GetClientsInformation(cDTS.Select(p => p.ClientId).ToArray());

        return new()
        {
            ClientsBySavingsAccounts = topClientsBySavingsAccounts,
            ClientsByCheckingAccounts = topClientsByCheckingAccounts,
            ClientsByCDTs = topClientsByCDTs
        };
    }

    private async Task<IEnumerable<ClientDTO>> GetClientsInformation(int[] clientIds)
    {
        List<ClientDTO> clientDTOs = [];

        foreach (int clientId in clientIds)
        {
            ClientEntity client = await _clientRepository.GetClientById(clientId);

            ClientDTO clientDTO = new ClientDTO()
            {
                Id = client.Id,
                Name = client.Name,
                IdentificationNumber = client.IdentificationNumber,
                IdentificationType = client.IdentificationType,
                PersonType = client.PersonType
            };
            clientDTOs.Add(clientDTO);
        }

        return clientDTOs;
    }

    private int ValidateNumberOfCurrentClientsForTop(int numberClients)
    {
        if (numberClients < _RANGE_TOP) 
        {
            return numberClients;
        }

        return _RANGE_TOP;
    }
}
