namespace BankingSystem.Domain.Interfaces;
public interface IProduct
{
    Task<ProductDomainEntity> Create(ProductDomainEntity product);
    Task<List<ProductDomainEntity>> GetSpecificTypeProductsByClient(int clientId, string productType);
    Task<ProductDomainEntity> GetSpecificTypeProductByClient(int clientId, string productType);
    Task<ProductDomainEntity> GetProductById(int id);
    Task CancelProductById(int id);
}