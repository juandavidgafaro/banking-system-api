namespace BankingSystem.Infrastructure.Services.Implementations;
public class ClientService : IClientService
{
    private readonly ILegalRepresentativeRepository _legalRepresentativeRepository;
    private readonly IClientRepository _clientRepository;

    public ClientService(ILegalRepresentativeRepository legalRepresentativeRepository, IClientRepository clientRepository)
    {
        _legalRepresentativeRepository = legalRepresentativeRepository;
        _clientRepository = clientRepository;
    }

    public async Task CreateBusinessClient(ClientDomainEntity client)
    {
        await _legalRepresentativeRepository.Create(client.LegalRepresentative);
        await _clientRepository.Create(client);
    }

    public async Task CreatePersonalClient(ClientDomainEntity client)
    {
        await _clientRepository.Create(client);
    }
}