﻿namespace BankingSystem.Infrastructure.Repositories;
public class TransactionRepository : SqlServerBase<TransactionEntity>, ITransaction
{
    public TransactionRepository(IOptions<InfrastructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task Create(TransactionDomainEntity transaction)
    {
        string sql = sqlstatements.insert_transaction;

        try
        {
            await SingleInsert(sql, new
            {
                transaction.OriginDate,
                Type = transaction.Type.Name,
                transaction.Serial,
                transaction.ProductId
            });

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}