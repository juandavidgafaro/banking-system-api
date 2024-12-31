namespace BankingSystem.Api.Application.Commands;
public class CreateProductCommand : IRequest<int>
{
    public HeaderRequestModel Header { get; set; }
    public CreateProductDTO Body { get; set; }
}