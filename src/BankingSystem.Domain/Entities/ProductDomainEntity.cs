namespace BankingSystem.Domain.Entities;
public class ProductDomainEntity
{
    private const string _EXISTING_PRODUCT_ERROR_MESSAGE = "El cliente actualmente posee un producto de este tipo.";
    private const string _INVALID_TRANSACTION_TYPE = "Esta transacción no es permitida hasta cumplirse la fecha de expiración.";
    private const string _INVALID_CANCELATION_TRANSACTION = "Para poder cancelar, el cliente debe contar con una cuenta de ahorros o crearla si no tiene.";
    private const int _ACTIVE_STATUS = 1;

    public int Id { get; set; }
    public int ClientId { get; set; }
    public string Type { get; set; }
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
        string type,
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
        string productType,
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

    public bool isActiveProduct()
    {
        return Status.Id == _ACTIVE_STATUS;
    }

    public void ValidateTypeForTransaction(TransactionType transactionType)
    {
        DateTime currentDate = DateTime.Now;

        bool expirationDateMet = currentDate > ExpirationDate;

        if (ProductType.FromName(Type).Id == 3 && !expirationDateMet && transactionType.Id == 2)
        {
            throw new DomainException(_INVALID_TRANSACTION_TYPE);
        }
    }

    public int ActionsForCancellationProcess(IProductRepository productRepository, string productType, int clientId)
    {
        int productIdToCancel = 0;

        if (ProductType.FromName(productType).Id == 3)
        {
            productIdToCancel = ValidateProductTypeByClientId(productRepository, ProductType.CertificateOfDeposit.Name, clientId, TransactionType.Cancel);
            CanBeCanceled = productIdToCancel > 0;
        }

        return productIdToCancel;
    }

    private int ValidateProductTypeByClientId(IProductRepository productRepository, string productType, int clientId, TransactionType transactionType)
    {
        ProductDomainEntity product = productRepository.GetSpecificTypeProductByClient(clientId, productType).GetAwaiter().GetResult();

        if (product != default && transactionType.Id == 0)
        {
            throw new DomainException(_EXISTING_PRODUCT_ERROR_MESSAGE);
        }

        if (product == default && transactionType.Id == 3)
        {
            throw new DomainException(_INVALID_CANCELATION_TRANSACTION);
        }

        return product.Id;
    }
}