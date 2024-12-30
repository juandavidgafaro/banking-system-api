namespace BankingSystem.Infrastructure.Interfaces;
public interface IClientInfrastructureRepository
{
    Task<ClientEntity> GetClientById(int id);
}