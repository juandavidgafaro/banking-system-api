namespace BankingSystem.Infrastructure.Repositories;
public class ProductRepository : SqlServerBase<ProductEntity>, IProductRepository
{
    public ProductRepository(IOptions<InfrastructureSettings> settings)
    : base(settings.Value.SqlServerSettings.ConnectionStrings.BankingSystemDataServer)
    {
    }

    public async Task<ProductDomainEntity> Create(ProductDomainEntity product)
    {
        string sql = sqlstatements.insert_product;

        try
        {
            ProductEntity insertionResult = await SingleInsert<ProductEntity>(sql, new
            {
                ProductType = product.Type,
                ProductStatus = product.Status.Name,
                product.MonthlyInterestPercentage,
                product.TermMonths,
                product.ClientId,
                AccountId = product.Account.Id
            });

            return insertionResult;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

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