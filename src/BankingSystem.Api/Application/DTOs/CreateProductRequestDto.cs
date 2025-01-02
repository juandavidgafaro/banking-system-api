namespace BankingSystem.Api.Application.DTOs;
public class CreateProductRequestDto
{
    public required string Type { get; set; }
    public int TermMonths { get; set; }
    public double InitialBalance { get; set; }
    public double MonthlyInterestPercentage { get; set; }
    public int ClientId { get; set; }
}