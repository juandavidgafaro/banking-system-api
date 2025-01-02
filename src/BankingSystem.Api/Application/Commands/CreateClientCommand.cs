namespace BankingSystem.Api.Application.Commands;

public class CreateClientCommand : IRequest<int>
{
    public HeaderRequestModel Header { get; set; }
    public CreateClientRequestDTO Body { get; set; }
}
