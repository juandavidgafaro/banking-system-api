namespace BankingSystem.Api.Application.DTOs;
public class CalculateInterestRequestDTO
{
    public double InitialBalance { get; set; }
    public double InterestRate { get; set; }
    public int Months { get; set; }
    public string ProductType { get; set; }
}