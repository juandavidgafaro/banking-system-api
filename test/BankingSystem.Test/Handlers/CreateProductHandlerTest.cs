namespace BankingSystem.Test.Handlers;
public class CreateProductHandlerTests
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private readonly Mock<IBuildAccountService> _buildAccountServiceMock;
    private readonly Mock<IProductSevice> _productServiceMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly CreateProductHandler _handler;

    public CreateProductHandlerTests()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _buildAccountServiceMock = new Mock<IBuildAccountService>();
        _productServiceMock = new Mock<IProductSevice>();
        _productRepositoryMock = new Mock<IProductRepository>();

        _handler = new CreateProductHandler(
            _clientRepositoryMock.Object,
            _buildAccountServiceMock.Object,
            _productServiceMock.Object,
            _productRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnProductId_WhenProductIsCreatedSuccessfully()
    {
        // Arrange
        CreateProductCommand request = new()
        {
            Body = new CreateProductRequestDto
            {
                ClientId = 1,
                Type = "Cuenta corriente",
                InitialBalance = 1000,
                TermMonths = 12,
                MonthlyInterestPercentage = 0.05
            }
        };

        ClientEntity clientEntity = new() { Id = 1, Name = "Test Client" };
        int expectedProductId = 123;

        _clientRepositoryMock.Setup(repo => repo.GetClientById(request.Body.ClientId))
            .ReturnsAsync(clientEntity);

        (double, int) data = (request.Body.InitialBalance, request.Body.TermMonths);

        _buildAccountServiceMock.Setup(service => service.BuildByProductType(
                request.Body.Type,
                data))
            .Returns(It.IsAny<AccountDomainEntity>());

        _productServiceMock.Setup(service => service.Create(
                It.IsAny<ProductDomainEntity>(),
                It.IsAny<TransactionDomainEntity>()))
            .ReturnsAsync(expectedProductId);

        // Act
        int result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(expectedProductId, result);
        _clientRepositoryMock.Verify(repo => repo.GetClientById(request.Body.ClientId), Times.Once);
        _buildAccountServiceMock.Verify(service => service.BuildByProductType(
            request.Body.Type,
            data), Times.Once);
        _productServiceMock.Verify(service => service.Create(
            It.IsAny<ProductDomainEntity>(),
            It.IsAny<TransactionDomainEntity>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenClientDoesNotExist()
    {
        // Arrange
        CreateProductCommand request = new()
        {
            Body = new CreateProductRequestDto
            {
                ClientId = 1,
                Type = "SavingsAccount",
                InitialBalance = 1000,
                TermMonths = 12,
                MonthlyInterestPercentage = 0.05
            }
        };

        _clientRepositoryMock.Setup(repo => repo.GetClientById(request.Body.ClientId))
            .ReturnsAsync((ClientEntity)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(
            () => _handler.Handle(request, CancellationToken.None));

        _clientRepositoryMock.Verify(repo => repo.GetClientById(request.Body.ClientId), Times.Once);
        _buildAccountServiceMock.VerifyNoOtherCalls();
        _productServiceMock.VerifyNoOtherCalls();
    }
}
