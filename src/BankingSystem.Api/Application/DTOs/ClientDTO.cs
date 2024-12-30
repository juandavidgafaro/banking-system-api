namespace BankingSystem.Api.Application.DTOs
{
    public class ClientDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string PersonType { get; set; }
        public string Country { get; set; }
        public LegalRepresentativeDTO? LegalRepresentative { get; set; }
        public ProductDTO Product { get; set; }
    }
}
