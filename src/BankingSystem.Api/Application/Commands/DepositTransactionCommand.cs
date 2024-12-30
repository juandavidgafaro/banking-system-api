namespace BankingSystem.Api.Application.Commands;
public class DepositTransactionCommand : IRequest<Guid>
{
    public int ProductId { get; set; }
    public HeaderRequestModel Header { get; set; }
    public MakeDepositDTO Body { get; set; }
}
