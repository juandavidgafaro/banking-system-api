namespace BankingSystem.Infrastructure.Repositories;
public class ClientRepository : SqlServerBase<ClientDomainEntity>, IClientRepository
{
    public ClientRepository(IOptions<InfraestructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task<bool> Create(ClientDomainEntity client)
    {
        string sql = "";

        bool insertionResult = await SingleInsert(sql, new
        {

        });

        return insertionResult;
    }
}
