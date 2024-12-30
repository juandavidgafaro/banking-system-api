INSERT INTO Client
(Name, 
IdentificationNumber, 
IdentificationType,
PersonType, 
LegalRepresentativeId)
OUTPUT 
    INSERTED.ClientId AS Id, 
    INSERTED.Name, 
    INSERTED.IdentificationNumber, 
    INSERTED.IdentificationType, 
    INSERTED.PersonType, 
    INSERTED.LegalRepresentativeId
VALUES 
(@Name,
@IdentificationNumber, 
@IdentificationType, 
@PersonType, 
@LegalRepresentativeId);
