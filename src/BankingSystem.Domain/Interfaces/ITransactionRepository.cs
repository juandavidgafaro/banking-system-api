namespace BankingSystem.Domain.Interfaces;
public interface ITransactionRepository
{
    Task Create(TransactionDomainEntity transaction);
}

