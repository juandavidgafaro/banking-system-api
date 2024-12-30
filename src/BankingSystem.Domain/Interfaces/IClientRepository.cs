namespace BankingSystem.Domain.Interfaces;

public interface IClientRepository
{
    Task<bool> Create(ClientDomainEntity client);
}