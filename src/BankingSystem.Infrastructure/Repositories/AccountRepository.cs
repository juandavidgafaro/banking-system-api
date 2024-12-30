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
            throw new Exception(ex.Message);
        }        
    }
    public Task Cancel(DateTime cancellationDate)
    {
        throw new NotImplementedException();
    }

    public Task ModifyBalance(double currentBalance)
    {
        throw new NotImplementedException();
    }
}