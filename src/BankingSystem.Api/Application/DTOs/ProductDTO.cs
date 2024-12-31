namespace BankingSystem.Api.Application.DTOs;

public class ProductDTO
{
    public int? Id { get; set; }
    public required string Type { get; set; }
    public string? Status { get; set; }
    public int TermMonths { get; set; }
    public double MoneyForAccount { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public ClientDomainEntity Client { get; set; }
    public AccountDomainEntity? Account { get; set; }
}