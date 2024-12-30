using BankingSystem.Api.Application.Commands;
using BankingSystem.Api.Application.Queries;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromHeaderModel] HeaderRequestModel header, [FromBody] CreateClientDTO createClientDTO)
    {
        CreateClientCommand createClientCommand = new()
        {
            Header = header,
            Body = createClientDTO
        };

        int clientId = await _mediator.Send(createClientCommand);

        return Ok(new { clientId = clientId });
    }

    /// <summary>
    /// Retorna un cliente por su Id.
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpGet("{clientId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetClientById(int clientId)
    {
        GetClientByIdQuery query = new GetClientByIdQuery(clientId);

        ClientQueryResponseDTO clientDTO = await _mediator.Send(query);

        return Ok(clientDTO);
    }


}