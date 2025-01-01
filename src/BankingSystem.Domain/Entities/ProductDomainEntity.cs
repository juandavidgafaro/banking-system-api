namespace BankingSystem.Domain.Entities;
public class ProductDomainEntity
{
    private const string _EXISTING_PRODUCT_ERROR_MESSAGE = "El cliente actualmente posee un producto de este tipo.";
    private const string _INVALID_CANCELATION_TRANSACTION = "Para poder cancelar, el cliente debe contar con una cuenta de ahorros o crearla si no tiene.";

    public int Id { get; set; }
    public int ClientId { get; set; }
    public ClientDomainEntity? Client { get; set; }
    public ProductType Type { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime OriginDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime DateLastModification { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public int TermMonths { get; set; }
    public AccountDomainEntity Account { get; set; }
    public bool CanBeCanceled { get; private set; }

    public ProductDomainEntity(
        int id,
        ProductType type,
        ProductStatus status,
        AccountDomainEntity account
        )
    {
        Id = id;
        Type = type;
        Status = status;
        Account = account;
    }

    public ProductDomainEntity(
        ProductStatus status,
        ProductType productType,
        int clientId,
        double monthlyInterestPercentage,
        AccountDomainEntity account,
        TransactionType transactionType)
    {
        Status = status;
        Type = productType;
        Account = account;
        ClientId = clientId;
        MonthlyInterestPercentage = monthlyInterestPercentage;
    }

    public ProductDomainEntity(
        IProduct productRepository,
        ProductStatus status,
        ProductType productType,
        int clientId,
        double monthlyInterestPercentage,
        AccountDomainEntity account,
        TransactionType transactionType)
    {
        ValidateProductForTransaction(productRepository, productType, clientId, transactionType);

        Status = status;
        Type = productType;
        Account = account;
        ClientId = clientId;
        MonthlyInterestPercentage = monthlyInterestPercentage;
    }

    public bool isActiveProduct()
    {
        return Status.Name == ProductStatus.Active.Name;
    }

    public ProductDomainEntity ValidateProductForTransaction(IProduct productRepository, ProductType productType, int clientId, TransactionType transactionType)
    {
        ProductDomainEntity product = productRepository.GetSpecificTypeProductByClient(clientId, productType.Name).GetAwaiter().GetResult();

        if (product != default && transactionType.Equals(TransactionType.Create))
        {
            throw new DomainException(_EXISTING_PRODUCT_ERROR_MESSAGE);
        }

        if (product == default && transactionType.Equals(TransactionType.Cancel))
        {
            throw new DomainException(_INVALID_CANCELATION_TRANSACTION);
        }

        return product;
    }
}