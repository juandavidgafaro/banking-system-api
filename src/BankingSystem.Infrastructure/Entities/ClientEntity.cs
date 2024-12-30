namespace BankingSystem.Infrastructure.Entities;
public class ClientEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentificationNumber { get; set; }
    public string IdentificationType { get; set; }
    public string PersonType { get; set; }
    public int LegalRepresentativeId { get; set; }
}