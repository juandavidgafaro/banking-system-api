namespace BankingSystem.Infrastructure.Services.Implementations;
public class ProductSevice : IProductSevice
{
    private readonly IProductRepository _productRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public ProductSevice(
        IProductRepository productRepository,
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository)
    {
        _productRepository = productRepository;
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }

    public async Task Create(ProductDomainEntity product)
    {
        await _accountRepository.Create(product.Account);
        await _productRepository.Create(product);
    }

    public async Task Cancel(int productId, TransactionDomainEntity transaction)
    {
        await _accountRepository.Cancel(DateTime.Now);
        await _productRepository.CancelProductById(productId);
        await _transactionRepository.Create(transaction);
    }
}
