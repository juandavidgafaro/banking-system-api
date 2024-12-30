SELECT 
    ClientId AS Id, 
    Name, 
    IdentificationNumber, 
    IdentificationType, 
    PersonType, 
    LegalRepresentativeId
FROM Client
WHERE ClientId = @ClientId;