namespace BankingSystem.Api.Application.Handlers;
public class CancelTransactionHandler : IRequestHandler<CancelTransactionCommand, Unit>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Cancel;

    private readonly IProductRepository _productRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IProductSevice _productSevice;

    public CancelTransactionHandler(
        IProductRepository productRepository,
        ITransactionRepository transactionRepository,
        IProductSevice productSevice)
    {
        _productRepository = productRepository;
        _transactionRepository = transactionRepository;
        _productSevice = productSevice;
    }

    public async Task<Unit> Handle(CancelTransactionCommand request, CancellationToken cancellationToken)
    {
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

        return Unit.Value;
    }
}
