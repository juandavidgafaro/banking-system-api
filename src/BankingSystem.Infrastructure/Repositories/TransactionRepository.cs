using BankingSystem.Infrastructure.Resources;

namespace BankingSystem.Infrastructure.Repositories;
public class TransactionRepository : SqlServerBase<TransactionEntity>, ITransactionRepository
{
    public TransactionRepository(IOptions<InfraestructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task Create(TransactionDomainEntity transaction)
    {
        string sql = sqlstatements.insert_transaction;


        bool insertionResult = await SingleInsert(sql, new
        {
            transaction.OriginDate,
            Type = transaction.Type.Name,
            transaction.Serial,
            transaction.ProductId
        });
    }
}