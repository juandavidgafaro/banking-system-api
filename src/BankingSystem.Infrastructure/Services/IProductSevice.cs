namespace BankingSystem.Infrastructure.Services;
public interface IProductSevice
{
    Task Cancel(int productId, TransactionDomainEntity transaction);
}