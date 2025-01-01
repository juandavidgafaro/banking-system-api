namespace BankingSystem.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Permite crear un producto.
    /// </summary>
    /// <param name="header"></param>
    /// <param name="createProductDTO"></param>
    /// <returns>Retorna el Id del producto creado.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<int>> CreateProduct([FromHeaderModel] HeaderRequestModel header, [FromBody] CreateProductDTO createProductDTO)
    {
        CreateProductCommand createProductCommand = new CreateProductCommand()
        {
            Header = header,
            Body = createProductDTO
        };

        int productId = await _mediator.Send(createProductCommand);

        return Ok(productId);
    }


    /// <summary>
    /// Retorna el saldo promedio por los tipos de producto.
    /// </summary>
    /// <returns></returns>
    [HttpGet("AverageBalanceByProductType")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AverageBalanceByProductTypeQueryResponseDTO>> GetAverageBalance()
    {
        AverageBalanceByProductTypeQueryResponseDTO averages = await _mediator.Send(new GetAverageBalanceByProductTypeQuery());

        return Ok(averages);
    }

    /// <summary>
    /// Retorna el top 10 de los clientes con mayor saldo por tipo de producto.
    /// </summary>
    /// <returns></returns>
    [HttpGet("TopTenClientsByProductBalance")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AverageBalanceByProductTypeQueryResponseDTO>> GetTopTenClients()
    {
        TopTenClientsByProductBalanceQueryDTO topClients = await _mediator.Send(new GetTopTenClientsByProductBalanceQuery());

        return Ok(topClients);
    }

    /// <summary>
    /// Permite hacer un deposito por el id del producto.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="header"></param>
    /// <param name="makeDeposit"></param>
    /// <returns></returns>
    [HttpPost("{productId}/Deposit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TransactionProcesDTO>> Deposit(int productId, [FromHeaderModel] HeaderRequestModel header, [FromBody] MakeDepositDTO makeDeposit)
    {
        DepositTransactionCommand depositTransactionCommand = new DepositTransactionCommand()
        {
            ProductId = productId,
            Header = header,
            Body = makeDeposit
        };

        Guid transactionId = await _mediator.Send(depositTransactionCommand);

        return Ok(new TransactionProcesDTO(transactionId));
    }

    /// <summary>
    /// Permite hacer un retiro por el por el id del producto.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="header"></param>
    /// <param name="makeWithdraw"></param>
    /// <returns></returns>
    [HttpPost("{productId}/Withdraw")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TransactionProcesDTO>> Withdraw(int productId, [FromHeaderModel] HeaderRequestModel header, [FromBody] MakeWithdrawDTO makeWithdraw)
    {
        WithdrawTransactionCommand withdrawTransactionCommand = new WithdrawTransactionCommand()
        {
            ProductId = productId,
            Header = header,
            Body = makeWithdraw
        };

        Guid transactionId = await _mediator.Send(withdrawTransactionCommand);

        return Ok(new TransactionProcesDTO(transactionId));
    }

    /// <summary>
    /// Permite calcular el interes en un periodo de tiempo.
    /// </summary>
    /// <param name="header"></param>
    /// <param name="calculateInterestRequestDTO"></param>
    /// <returns></returns>
    [HttpPost("CalculateInterest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<double>> CalculateInterest([FromHeaderModel] HeaderRequestModel header, [FromBody] CalculateInterestRequestDTO calculateInterestRequestDTO)
    {
        CalculateInterestCommand calculateInterestCommand = new CalculateInterestCommand()
        {
            Body = calculateInterestRequestDTO
        };

        double balanceWithInterest = await _mediator.Send(calculateInterestCommand);

        return Ok(balanceWithInterest);
    }

    /// <summary>
    /// Permite cancelar un producto por el id del producto.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="header"></param>
    /// <returns></returns>
    [HttpPatch("{productId}/Cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TransactionProcesDTO>> CancelProduct(int productId, [FromHeaderModel] HeaderRequestModel header)
    {
        CancelTransactionCommand cancelTransactionCommand = new CancelTransactionCommand()
        {
            ProductId = productId,
            Header = header,
        };

        Guid transactionId = await _mediator.Send(cancelTransactionCommand);

        return Ok(new TransactionProcesDTO(transactionId));
    }
}
