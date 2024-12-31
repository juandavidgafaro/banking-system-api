namespace BankingSystem.Domain.Interfaces;

public interface IClient
{
    Task<ClientDomainEntity> Create(ClientDomainEntity client);
}