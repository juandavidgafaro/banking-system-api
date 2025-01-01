namespace BankingSystem.Api.Application.Handlers;
public class DepositTransactionHandler : IRequestHandler<DepositTransactionCommand, Guid>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Deposit;

    private readonly IProductRepository _productRepository;
    private readonly ITransactionService _transactionService;

    public DepositTransactionHandler(
        IProductRepository productRepository,
        ITransactionService transactionService)
    {
        _productRepository = productRepository;
        _transactionService = transactionService;
    }

    public async Task<Guid> Handle(DepositTransactionCommand request, CancellationToken cancellationToken)
    {
        Guid transactionSerial = Guid.NewGuid();

        DepositValidationService.ValidateAmountToDeposit(request.Body.Amount);

        var product = await _productRepository.GetProductById(request.ProductId);

        if (product == default)
        {
            throw new NotFoundException(string.Format("El producto con Id {0} no existe.", request.ProductId));
        }

        if (!product.isActiveProduct())
        {
            throw new InvalidOperationException(string.Format("El producto con Id {0} no esta activo.", request.ProductId));
        }

        double totalAmount = DepositValidationService.GetTotalAmount(product.Account.Balance, request.Body.Amount);

        TransactionDomainEntity transaction = new()
        {
            OriginDate = DateTime.Now,
            Type = _TRANSACTION_TYPE,
            ProductId = request.ProductId,
            Serial = transactionSerial
        };

        await _transactionService.MakeDeposit(transaction, product.Account, totalAmount);

        return transactionSerial;
    }
}