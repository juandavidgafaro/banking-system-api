namespace BankingSystem.Infrastructure.Repositories;
public class AccountRepository : SqlServerBase<AccountEntity>, IAccountRepository
{
    public AccountRepository(IOptions<InfrastructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task<AccountDomainEntity> Create(AccountDomainEntity account)
    {
        string sql = sqlstatements.insert_account;

        try
        {
            AccountEntity insertionResult = await SingleInsert<AccountEntity>(sql, new
            {
                account.Number,
                account.Balance,
                account.CancellationDate,
                account.MaturityDate,
            });

            return insertionResult;
        }
        catch (Exception ex) 
        {
            throw new InfrastructureException($"Error al intentar crear la cuenta, detalle:{ex.Message}");
        }        
    }
    public async Task Cancel(AccountDomainEntity account)
    {
        string sql = sqlstatements.cancel_account;

        try
        {
            await SingleUpdate(sql, new { AccountId = account.Id });
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar cancelar la cuenta con numero: {account.Number}, detalle:{ex.Message}");
        }

    }

    public async Task ModifyBalance(AccountDomainEntity account, double currentBalance)
    {
        string sql = sqlstatements.modify_account_balance;

        try
        {
            await SingleUpdate(sql, new { AccountId = account.Id, CurrentBalance = currentBalance });
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar modificar el saldo de la cuenta con numero: {account.Number}, detalle:{ex.Message}");
        }
    }
}