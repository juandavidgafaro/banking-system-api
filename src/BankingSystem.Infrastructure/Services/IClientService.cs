namespace BankingSystem.Infrastructure.Services;
public interface IClientService
{
    Task CreateBusinessClient(ClientDomainEntity client);
    Task CreatePersonalClient(ClientDomainEntity client);
}