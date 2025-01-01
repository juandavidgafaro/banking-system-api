namespace BankingSystem.Api.Application.Commands;
public class CalculateInterestCommand : IRequest<double>
{
    public CalculateInterestRequestDTO Body { get; set; }
}