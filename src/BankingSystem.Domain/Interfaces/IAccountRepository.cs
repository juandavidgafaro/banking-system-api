namespace BankingSystem.Domain.Interfaces;
public interface IAccountRepository
{
    Task Create(AccountDomainEntity accountDomainEntity);
    Task ModifyBalance(double currentBalance);
    Task Cancel(DateTime cancellationDate);
}
