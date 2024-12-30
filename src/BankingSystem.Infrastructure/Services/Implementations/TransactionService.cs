namespace BankingSystem.Infrastructure.Services.Implementations;
public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task MakeDeposit(TransactionDomainEntity transaction, double currentBalance)
    {
        await _accountRepository.ModifyBalance(currentBalance);
        await _transactionRepository.Create(transaction);
    }

    public async Task MakeWithdrawal(TransactionDomainEntity transaction, double currentBalance)
    {
        await _accountRepository.ModifyBalance(currentBalance);
        await _transactionRepository.Create(transaction);
    }
}