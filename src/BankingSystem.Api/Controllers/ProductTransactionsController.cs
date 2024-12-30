namespace BankingSystem.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductTransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductTransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Permite hacer un deposito por el productId.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="header"></param>
    /// <param name="deposit"></param>
    /// <returns></returns>
    [HttpPost("{productId}/Deposit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Post(int productId, [FromHeaderModel] HeaderRequestModel header, [FromBody] MakeDepositDTO makeDeposit)
    {
        DepositTransactionCommand depositTransactionCommand = new DepositTransactionCommand()
        {
            ProductId = productId,
            Header = header,
            Body = makeDeposit
        };

        Guid transactionId = await _mediator.Send(depositTransactionCommand);

        return Ok(transactionId);
    }

    /// <summary>
    /// Permite hacer un retiro por el productId.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="header"></param>
    /// <param name="makeWithdraw"></param>
    /// <returns></returns>
    [HttpPost("{productId}/Withdraw")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(int productId, [FromHeaderModel] HeaderRequestModel header, [FromBody] MakeWithdrawDTO makeWithdraw)
    {
        WithdrawTransactionCommand withdrawTransactionCommand = new WithdrawTransactionCommand()
        {
            ProductId = productId,
            Header = header,
            Body = makeWithdraw
        };

        Guid transactionId = await _mediator.Send(withdrawTransactionCommand);

        return Ok(transactionId);
    }

}
