namespace BankingSystem.Domain.Interfaces;
public interface IProduct
{
    Task<ProductDomainEntity> Create(ProductDomainEntity product);
    Task<ProductDomainEntity> GetSpecificTypeProductByClient(int clientId, string productType);
    Task<ProductDomainEntity> GetProductById(int id);
    Task CancelProductById(int id);
}