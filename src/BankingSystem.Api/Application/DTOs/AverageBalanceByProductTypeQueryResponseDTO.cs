namespace BankingSystem.Api.Application.DTOs;

public class AverageBalanceByProductTypeQueryResponseDTO
{
    public double SavingsAccount { get; set; }
    public double CheckingAccount { get; set; }
    public double CDT { get; set; }
}