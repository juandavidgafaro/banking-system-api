namespace BankingSystem.Api.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public required string Type { get; set; }
    public required string Status { get; set; }
    public int TermMonths { get; set; }
    public double MoneyForAccount { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public required ClientDomainEntity Client { get; set; }
    public required AccountDomainEntity Account { get; set; }
}