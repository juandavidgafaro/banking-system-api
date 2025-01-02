namespace BankingSystem.Api.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IdentificationNumber { get; set; }
        public required string IdentificationType { get; set; }
        public required string PersonType { get; set; }
        public required string Country { get; set; }
        public LegalRepresentativeDTO? LegalRepresentative { get; set; }
    }
}
