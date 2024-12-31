namespace BankingSystem.Infrastructure.Interfaces;
public interface IClientRepository : IClient
{
    Task<ClientEntity> GetClientById(int id);
}