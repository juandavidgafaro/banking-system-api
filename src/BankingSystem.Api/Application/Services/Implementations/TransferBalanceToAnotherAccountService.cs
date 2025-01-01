namespace BankingSystem.Api.Application.Services.Implementations;
public class TransferBalanceToAnotherAccountService : ITransferBalanceToAnotherAccountService
{
    private readonly ITransactionService _transactionService;

    public TransferBalanceToAnotherAccountService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task GenerateTransferToSavingsAccount((ProductDomainEntity productDeposit, ProductDomainEntity productWithdrawal) transactionProducts)
    {
        Guid transactionSerial = Guid.NewGuid();

        TransactionDomainEntity depositTransaction = BuildTransaction(TransactionType.Deposit, transactionProducts.productDeposit.Id);
        TransactionDomainEntity withdrawalTransaction = BuildTransaction(TransactionType.Deposit, transactionProducts.productDeposit.Id);

        await _transactionService.MakeDeposit(depositTransaction, transactionProducts.productDeposit.Account, transactionProducts.productWithdrawal.Account.Balance);
        await _transactionService.MakeWithdrawal(withdrawalTransaction, transactionProducts.productWithdrawal.Account, transactionProducts.productWithdrawal.Account.Balance);
    }

    private static TransactionDomainEntity BuildTransaction(TransactionType transactionType, int productId)
    {
        Guid transactionSerial = Guid.NewGuid();

        TransactionDomainEntity depositTransaction = new()
        {
            OriginDate = DateTime.Now,
            Type = transactionType,
            ProductId = productId,
            Serial = transactionSerial
        };

        return depositTransaction;
    }
}