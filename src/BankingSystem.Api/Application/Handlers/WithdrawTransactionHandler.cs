namespace BankingSystem.Api.Application.Handlers;
public class WithdrawTransactionHandler : IRequestHandler<WithdrawTransactionCommand, Guid>
{
    private readonly TransactionType _TRANSACTION_TYPE = TransactionType.Withdraw;

    private readonly IProductRepository _productRepository;
    private readonly ITransactionService _transactionService;

    public WithdrawTransactionHandler(
        IProductRepository productRepository,
        ITransactionService transactionService)
    {
        _productRepository = productRepository;
        _transactionService = transactionService;
    }

    public async Task<Guid> Handle(WithdrawTransactionCommand request, CancellationToken cancellationToken)
    {
        Guid transactionSerial = Guid.NewGuid();

        var product = await _productRepository.GetProductById(request.ProductId);

        if (product == default)
        {
            throw new NotFoundException(string.Format("El producto con Id {0} no existe.", request.ProductId));
        }

        if (!product.isActiveProduct())
        {
            throw new InvalidOperationException(string.Format("El producto con Id {0} no esta activo.", request.ProductId));
        }

        WithdrawalValidationService.ValidateByProductType(product, _TRANSACTION_TYPE);

        double currentBalance = WithdrawalValidationService.ValidateAndReturnCurrentBalance(product.Account.Balance, request.Body.Amount);

        TransactionDomainEntity transaction = new()
        {
            OriginDate = DateTime.Now,
            Type = _TRANSACTION_TYPE,
            ProductId = request.ProductId,
            Serial = transactionSerial
        };

        await _transactionService.MakeWithdrawal(transaction, product.Account, currentBalance);

        return transactionSerial;
    }
}
