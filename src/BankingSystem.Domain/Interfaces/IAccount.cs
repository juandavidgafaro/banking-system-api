namespace BankingSystem.Domain.Interfaces;
public interface IAccount
{
    Task<AccountDomainEntity> Create(AccountDomainEntity account);
    Task ModifyBalance(AccountDomainEntity account, double currentBalance);
    Task Cancel(AccountDomainEntity account);
}
