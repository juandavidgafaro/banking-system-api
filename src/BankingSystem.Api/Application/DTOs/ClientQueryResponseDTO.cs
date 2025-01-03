﻿namespace BankingSystem.Api.Application.DTOs;
public class ClientQueryResponseDTO
{
    public int ClientId { get; set; }
    public required string Name { get; set; }
    public int IdentificationNumber { get; set; }
    public required string IdentificationType { get; set; }
    public required string PersonType { get; set; }
    public int? LegalRepresentativeId { get; set; }
}