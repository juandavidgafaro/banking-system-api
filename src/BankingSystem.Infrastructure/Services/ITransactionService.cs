namespace BankingSystem.Infrastructure.Services;
public interface ITransactionService
{
    Task MakeDeposit(TransactionDomainEntity transaction, double currentBalance);
    Task MakeWithdrawal(TransactionDomainEntity transaction, double currentBalance);
}
