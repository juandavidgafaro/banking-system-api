namespace BankingSystem.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Permirte crear un cliente.
    /// </summary>
    /// <param name="header"></param>
    /// <param name="createClientDTO"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromHeaderModel] HeaderModel header, [FromBody] CreateClientDTO createClientDTO)
    {
        CreateClientCommand createClientCommand = new()
        {
            Header = header,
            Body = createClientDTO
        };

        return StatusCode(StatusCodes.Status201Created, await _mediator.Send(createClientCommand));
    }

}