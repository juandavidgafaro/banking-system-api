namespace BankingSystem.Api.Application.Commands;

public class CreateClientCommand : IRequest<Unit>
{
    public HeaderModel Header { get; set; }
    public CreateClientDTO Body { get; set; }
}
