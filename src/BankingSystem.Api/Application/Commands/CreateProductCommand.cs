namespace BankingSystem.Api.Application.Commands;
public class CreateProductCommand : IRequest<int>
{
    public HeaderRequestModel Header { get; set; }
    public CreateProductRequestDto Body { get; set; }
}