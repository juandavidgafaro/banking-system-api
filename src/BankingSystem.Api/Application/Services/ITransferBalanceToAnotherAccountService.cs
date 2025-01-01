namespace BankingSystem.Api.Application.Services;
public interface ITransferBalanceToAnotherAccountService
{
    Task GenerateTransferToSavingsAccount((ProductDomainEntity productDeposit, ProductDomainEntity productWithdrawal) transactionProducts);
}
