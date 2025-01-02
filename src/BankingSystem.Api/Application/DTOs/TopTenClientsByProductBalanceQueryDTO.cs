namespace BankingSystem.Api.Application.DTOs;
public class TopTenClientsByProductBalanceQueryDTO
{
    public required IEnumerable<ClientDTO> ClientsBySavingsAccounts { get; set; }
    public required IEnumerable<ClientDTO> ClientsByCheckingAccounts { get; set; }
    public required IEnumerable<ClientDTO> ClientsByCDTs { get; set; }
    
}