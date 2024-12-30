namespace BankingSystem.Api.Application.Services;
public static class TransferBalanceToAnotherAccountService
{
    public static async Task GenerateTransferToSavingsAccount(ITransactionRepository transactionRepository, TransactionDomainEntity transaction)
    {
        await transactionRepository.Create(transaction);
    }
}