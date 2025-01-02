SELECT 
    ClientId AS Id, 
    Name, 
    IdentificationNumber, 
    IdentificationType, 
    PersonType, 
    Country,
    LegalRepresentativeId
FROM Client
WHERE ClientId = @ClientId;