INSERT INTO Client
(Name, 
IdentificationNumber, 
IdentificationType,
PersonType, 
Country, 
LegalRepresentativeId)
OUTPUT 
    INSERTED.ClientId AS Id, 
    INSERTED.Name, 
    INSERTED.IdentificationNumber, 
    INSERTED.IdentificationType, 
    INSERTED.PersonType, 
    INSERTED.Country, 
    INSERTED.LegalRepresentativeId
VALUES 
(@Name,
@IdentificationNumber, 
@IdentificationType, 
@PersonType, 
@Country, 
@LegalRepresentativeId);
