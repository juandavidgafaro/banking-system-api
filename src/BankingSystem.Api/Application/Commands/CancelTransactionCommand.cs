namespace BankingSystem.Api.Application.Commands;
public class CancelTransactionCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
    public HeaderModel Header { get; set; }
}