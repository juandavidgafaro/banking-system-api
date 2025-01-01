namespace BankingSystem.Infrastructure.Services;
public interface ITransactionService
{
    Task MakeDeposit(TransactionDomainEntity transaction, AccountDomainEntity account, double currentBalance);
    Task MakeWithdrawal(TransactionDomainEntity transaction, AccountDomainEntity account, double currentBalance);
}
