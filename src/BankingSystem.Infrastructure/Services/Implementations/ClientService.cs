namespace BankingSystem.Infrastructure.Services.Implementations;
public class ClientService : IClientService
{
    private readonly ILegalRepresentative _legalRepresentativeRepository;
    private readonly IClient _clientRepository;

    public ClientService(ILegalRepresentative legalRepresentativeRepository, IClient clientRepository)
    {
        _legalRepresentativeRepository = legalRepresentativeRepository;
        _clientRepository = clientRepository;
    }

    public async Task<ClientDomainEntity> CreateBusinessClient(ClientDomainEntity client)
    {
        LegalRepresentativeDomainEntity legalRepresentativeCreated = await _legalRepresentativeRepository.Create(client.LegalRepresentative);
        client.LegalRepresentative = legalRepresentativeCreated;
        ClientDomainEntity clientCreated = await _clientRepository.Create(client);

        return clientCreated;
    }

    public async Task<ClientDomainEntity> CreatePersonalClient(ClientDomainEntity client)
    {
        ClientDomainEntity clientCreated = await _clientRepository.Create(client);
        return clientCreated;
    }
}