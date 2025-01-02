namespace BankingSystem.Api.Application.DTOs;
public class LegalRepresentativeDTO
{
    public required string Name { get; set; }
    public long IdentificationNumber { get; set; }
    public required string IdentificationType { get; set; }
    public required string Country { get; set; }
    public long Phone { get; set; }
}