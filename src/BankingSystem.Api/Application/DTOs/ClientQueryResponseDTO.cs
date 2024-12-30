namespace BankingSystem.Api.Application.DTOs;
public class ClientQueryResponseDTO
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public int IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string PersonType { get; set; }
    public int? LegalRepresentativeId { get; set; }
}