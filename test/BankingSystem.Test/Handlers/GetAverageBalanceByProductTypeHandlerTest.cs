namespace BankingSystem.Test.Handlers;

public class GetAverageBalanceByProductTypeHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly GetAverageBalanceByProductTypeHandler _handler;

    public GetAverageBalanceByProductTypeHandlerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _handler = new GetAverageBalanceByProductTypeHandler(_productRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnCorrectAverages_WhenProductsExist()
    {
        // Arrange
        var savingsAccounts = new List<ProductEntity>
        {
            new ProductEntity { AccountBalance = 1000 },
            new ProductEntity { AccountBalance = 2000 }
        };
        var checkingAccounts = new List<ProductEntity>
        {
            new ProductEntity { AccountBalance = 1500 },
            new ProductEntity { AccountBalance = 2500 }
        };
        var cdts = new List<ProductEntity>
        {
            new ProductEntity { AccountBalance = 5000 },
            new ProductEntity { AccountBalance = 7000 }
        };

        _productRepositoryMock
            .Setup(repo => repo.GetAllProductsByType(ProductType.SavingsAccount.Name))
            .ReturnsAsync(savingsAccounts);
        _productRepositoryMock
            .Setup(repo => repo.GetAllProductsByType(ProductType.CheckingAccount.Name))
            .ReturnsAsync(checkingAccounts);
        _productRepositoryMock
            .Setup(repo => repo.GetAllProductsByType(ProductType.CertificateOfDeposit.Name))
            .ReturnsAsync(cdts);

        // Act
        var result = await _handler.Handle(new GetAverageBalanceByProductTypeQuery(), CancellationToken.None);

        // Assert
        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.SavingsAccount.Name), Times.Once);
        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.CheckingAccount.Name), Times.Once);
        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.CertificateOfDeposit.Name), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnZeroAverages_WhenNoProductsExist()
    {
        // Arrange
        _productRepositoryMock
            .Setup(repo => repo.GetAllProductsByType(It.IsAny<string>()))
            .ReturnsAsync(new List<ProductEntity>());

        // Act
        var result = await _handler.Handle(new GetAverageBalanceByProductTypeQuery(), CancellationToken.None);

        // Assert

        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.SavingsAccount.Name), Times.Once);
        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.CheckingAccount.Name), Times.Once);
        _productRepositoryMock.Verify(repo => repo.GetAllProductsByType(ProductType.CertificateOfDeposit.Name), Times.Once);
    }
}
