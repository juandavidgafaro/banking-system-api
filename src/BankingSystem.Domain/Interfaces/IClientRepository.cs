namespace BankingSystem.Domain.Interfaces;

public interface IClientRepository
{
    Task<ClientDomainEntity> Create(ClientDomainEntity client);
}