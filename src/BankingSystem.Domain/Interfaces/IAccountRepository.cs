namespace BankingSystem.Domain.Interfaces;
public interface IAccountRepository
{
    Task<AccountDomainEntity> Create(AccountDomainEntity account);
    Task ModifyBalance(double currentBalance);
    Task Cancel(DateTime cancellationDate);
}
