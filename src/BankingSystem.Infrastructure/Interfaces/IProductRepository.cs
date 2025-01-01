namespace BankingSystem.Infrastructure.Interfaces;

public interface IProductRepository : IProduct
{
    Task<IEnumerable<ProductEntity>> GetAllProductsByType(string type);
}
