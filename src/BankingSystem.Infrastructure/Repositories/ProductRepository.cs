using BankingSystem.Infrastructure.Resources;

namespace BankingSystem.Infrastructure.Repositories;
public class ProductRepository : SqlServerBase<ProductEntity>, IProductRepository
{
    public ProductRepository(IOptions<InfraestructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task Create(ProductDomainEntity product)
    {
        string sql = sqlstatements.insert_product;


        bool insertionResult = await SingleInsert(sql, new
        {
            
        });
    }

    public Task<ProductDomainEntity> GetSpecificTypeProductByClient(int clientId, string productType)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductDomainEntity>> GetSpecificTypeProductsByClient(int clientId, string productType)
    {
        string sql = "";

        bool insertionResult = await SingleInsert(sql, new
        {

        });

        return new List<ProductDomainEntity>();
    }

    public async Task<ProductDomainEntity> GetProductById(int id)
    {
        string sql = "";

        ProductEntity product = await ExecuteSingleQueryAsync(sql, new { id });

        return product;
    }

    public Task CancelProductById(int id)
    {
        throw new NotImplementedException();
    }
}