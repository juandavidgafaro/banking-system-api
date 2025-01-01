namespace BankingSystem.Infrastructure.Services.Implementations;
public class TransactionService : ITransactionService
{
    private readonly IAccount _accountRepository;
    private readonly ITransaction _transactionRepository;

    public TransactionService(IAccount accountRepository, ITransaction transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task MakeDeposit(TransactionDomainEntity transaction, AccountDomainEntity account, double currentBalance)
    {
        await _accountRepository.ModifyBalance(account, currentBalance);
        await _transactionRepository.Create(transaction);
    }

    public async Task MakeWithdrawal(TransactionDomainEntity transaction, AccountDomainEntity account, double currentBalance)
    {
        await _accountRepository.ModifyBalance(account, currentBalance);
        await _transactionRepository.Create(transaction);
    }
}