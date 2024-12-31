namespace BankingSystem.Api.Application.Handlers;
public class CancelTransactionHandler : IRequestHandler<CancelTransactionCommand, Guid>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Cancel;

    private readonly IProduct _productRepository;
    private readonly ITransaction _transactionRepository;
    private readonly IProductSevice _productSevice;

    public CancelTransactionHandler(
        IProduct productRepository,
        ITransaction transactionRepository,
        IProductSevice productSevice)
    {
        _productRepository = productRepository;
        _transactionRepository = transactionRepository;
        _productSevice = productSevice;
    }

    public async Task<Guid> Handle(CancelTransactionCommand request, CancellationToken cancellationToken)
    {
        Guid transactionSerial = Guid.NewGuid();

        ProductDomainEntity product = await _productRepository.GetProductById(request.ProductId);

        if (product == default)
        {
            throw new ArgumentException(string.Format("El producto con Id {0} no existe.", request.ProductId));
        }

        int productIdToCancel = product.ActionsForCancellationProcess(_productRepository, product.Type, product.ClientId);

        if (product.CanBeCanceled)
        {
            TransactionDomainEntity savingsProductTransaction = new()
            {
                OriginDate = DateTime.Now,
                Type = TransactionType.Deposit,
                ProductId = productIdToCancel,
            };

            await TransferBalanceToAnotherAccountService.GenerateTransferToSavingsAccount(_transactionRepository, savingsProductTransaction);
        }

        TransactionDomainEntity cancellationTransaction = new()
        {
            OriginDate = DateTime.Now,
            Type = _TRANSACTION_TYPE,
            ProductId = product.Id,
        };

        await _productSevice.Cancel(productIdToCancel, cancellationTransaction);

        return transactionSerial;
    }
}
