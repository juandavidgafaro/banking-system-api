namespace BankingSystem.Infrastructure.Services;
public interface IClientService
{
    Task<ClientDomainEntity> CreateBusinessClient(ClientDomainEntity client);
    Task<ClientDomainEntity> CreatePersonalClient(ClientDomainEntity client);
}