namespace BankingSystem.Infrastructure.Repositories;
public class AccountRepository : SqlServerBase<AccountEntity>, IAccountRepository
{
    public AccountRepository(IOptions<InfraestructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public Task Create(AccountDomainEntity accountDomainEntity)
    {
        throw new NotImplementedException();
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