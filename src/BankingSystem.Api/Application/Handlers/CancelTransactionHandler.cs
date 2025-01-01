namespace BankingSystem.Api.Application.Handlers;
public class CancelTransactionHandler : IRequestHandler<CancelTransactionCommand, Guid>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Cancel;

    private readonly IProductRepository _productRepository;
    private readonly ITransaction _transactionRepository;
    private readonly IProductSevice _productSevice;
    private readonly ITransferBalanceToAnotherAccountService _transferBalanceToAnotherAccountService;

    public CancelTransactionHandler(
        IProductRepository productRepository,
        ITransaction transactionRepository,
        IProductSevice productSevice,
        ITransferBalanceToAnotherAccountService transferBalanceToAnotherAccountService)
    {
        _productRepository = productRepository;
        _transactionRepository = transactionRepository;
        _productSevice = productSevice;
        _transferBalanceToAnotherAccountService = transferBalanceToAnotherAccountService;
    }

    public async Task<Guid> Handle(CancelTransactionCommand request, CancellationToken cancellationToken)
    {
        Guid transactionSerial = Guid.NewGuid();

        ProductDomainEntity product = await _productRepository.GetProductById(request.ProductId);

        if (product == default)
        {
            throw new NotFoundException(string.Format("El producto con Id {0} no existe.", request.ProductId));
        }

        if(!product.isActiveProduct())
        {
            throw new InvalidOperationException(string.Format("El producto con Id {0} no esta activo", request.ProductId));
        }

        if (ProductType.CertificateOfDeposit.Equals(product.Type))
        {

            ProductDomainEntity savingsProduct = product.ValidateProductForTransaction(_productRepository, ProductType.SavingsAccount, product.ClientId, _TRANSACTION_TYPE);

            TransactionDomainEntity savingsProductTransaction = new()
            {
                OriginDate = DateTime.Now,
                Type = TransactionType.Deposit,
                ProductId = savingsProduct.Id
            };

            await _transferBalanceToAnotherAccountService.GenerateTransferToSavingsAccount((savingsProduct, product));
        }

        TransactionDomainEntity cancellationTransaction = new()
        {
            OriginDate = DateTime.Now,
            Type = _TRANSACTION_TYPE,
            ProductId = product.Id,
        };

        await _productSevice.Cancel(product.Id, cancellationTransaction, product.Account);

        return transactionSerial;
    }
}
