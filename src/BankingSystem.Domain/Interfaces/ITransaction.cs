namespace BankingSystem.Domain.Interfaces;
public interface ITransaction
{
    Task Create(TransactionDomainEntity transaction);
}

