namespace BankingSystem.Infrastructure.Repositories;
public class ClientRepository : SqlServerBase<ClientEntity>, IClientRepository
{
    public ClientRepository(IOptions<InfrastructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task<ClientDomainEntity> Create(ClientDomainEntity client)
    {
        string sql = sqlstatements.insert_client;

        try
        {
            ClientEntity insertionResult = await SingleInsert<ClientEntity>(sql, new
            {
                client.Name,
                client.IdentificationNumber,
                client.IdentificationType,
                client.PersonType,
                LegalRepresentativeId = client.LegalRepresentative?.Id
            });

            return insertionResult;
        }
        catch (Exception ex) 
        {
            throw new InfrastructureException($"Error al intentar crear el cliente con numero de identificación: {client.IdentificationNumber}, detalle:{ex.Message}");
        }
    }

    public async Task<ClientEntity> GetClientById(int id)
    {
        string sql = sqlstatements.get_client_by_id;

        try
        {
            ClientEntity client = await ExecuteSingleAsync(sql, new { ClientId = id });

            return client;
        }
        catch(Exception ex)
        {
            throw new InfrastructureException($"Error al intentar obtener el cliente con el Id: {id}, detalle:{ex.Message}");
        }
    }
}
