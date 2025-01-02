using MediatR;

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
        TransactionDomainEntity withdrawalTransaction = BuildTransaction(TransactionType.Withdraw, transactionProducts.productDeposit.Id);

        if (transactionProducts.productWithdrawal.Account.Balance > 0)
        {
            double totalAmountDeposit = DepositValidationService.GetTotalAmount(transactionProducts.productDeposit.Account.Balance, transactionProducts.productWithdrawal.Account.Balance);
            double currentBalanceWithdrawal = WithdrawalValidationService.ValidateAndReturnCurrentBalance(transactionProducts.productWithdrawal.Account.Balance, transactionProducts.productWithdrawal.Account.Balance);

            await _transactionService.MakeDeposit(depositTransaction, transactionProducts.productDeposit.Account, totalAmountDeposit);
            await _transactionService.MakeWithdrawal(withdrawalTransaction, transactionProducts.productWithdrawal.Account, currentBalanceWithdrawal);

        }
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