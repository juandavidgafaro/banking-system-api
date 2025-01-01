namespace BankingSystem.Api.Application.DTOs;
public class TopTenClientsByProductBalanceQueryDTO
{
    public IEnumerable<ClientDTO> ClientsBySavingsAccounts { get; set; }
    public IEnumerable<ClientDTO> ClientsByCheckingAccounts { get; set; }
    public IEnumerable<ClientDTO> ClientsByCDTs { get; set; }
    
}