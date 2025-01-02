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
            int productId = await SingleInsert(sql, new
            {
                ProductType = product.Type.Name,
                ProductStatus = product.Status.Name,
                product.MonthlyInterestPercentage,
                product.TermMonths,
                product.ClientId,
                AccountId = product.Account.Id
            });


            ProductDomainEntity productCreated = await GetProductById(productId);

            return productCreated;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar crear el producto para el cliente Id: {product.ClientId}, detalle:{ex.Message}");
        }
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsByType(string type)
    {
        string sql = sqlstatements.get_all_products_by_type;

        try
        {
            IEnumerable<ProductEntity> products = await ExecuteResult<ProductEntity>(sql, new { ProductType = type });

            return products;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar obtener los productos por el tipo: {type}, detalle:{ex.Message}");
        }
    }

    public async Task<ProductDomainEntity> GetSpecificTypeProductByClient(int clientId, string productType)
    {
        string sql = sqlstatements.get_product_by_client_and_type;

        try
        {
            ProductEntity product = await ExecuteSingleAsync(sql, new { ProductType = productType, ClientId = clientId });

            return product;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar obtener el producto por el tipo: {productType} con el id de cliente: {clientId}, detalle:{ex.Message}");
        }
    }

    public async Task<ProductDomainEntity> GetProductById(int id)
    {
        string sql = sqlstatements.get_product_by_id;

        try
        {
            ProductEntity product = await ExecuteSingleQueryAsync(sql, new { ProductId = id });

            return product;
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar obtener el producto con el id: {id}, detalle:{ex.Message}");
        }
    }

    public async Task CancelProductById(int id)
    {
        string sql = sqlstatements.cancel_product;

        try
        {
            await SingleUpdate(sql, new { ProductId = id, Status = ProductStatus.Canceled.Name });
        }
        catch (Exception ex)
        {
            throw new InfrastructureException($"Error al intentar cancelar el producto con el id: {id}, detalle:{ex.Message}");
        }
    }
}