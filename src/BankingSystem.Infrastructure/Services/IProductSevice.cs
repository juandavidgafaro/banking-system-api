namespace BankingSystem.Infrastructure.Services;
public interface IProductSevice
{
    Task Cancel(int productId, TransactionDomainEntity transaction, AccountDomainEntity account);
    Task<int> Create(ProductDomainEntity product, TransactionDomainEntity transaction);
}