namespace BankingSystem.Api.Application.Models;
public class CreateClientModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string IdentificationType { get; set; }
    public required string PersonType { get; set; }

    public required string NameLegalRepresentative { get; set; }
    public required string IdentificationNumberLegalRepresentative { get; set; }
    public required string IdentificationTypeLegalRepresentative { get; set; }
    public required string PhoneLegalRepresentative { get; set; }

    public required string ProductType { get; set; }
    public required double MoneyForAccount { get; set; }
    public required int TermMonths { get; set; }
}
