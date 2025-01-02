INSERT INTO LegalRepresentative 
(Name, 
IdentificationNumber, 
IdentificationType, 
Country,
Phone) 
OUTPUT 
    INSERTED.LegalRepresentativeId AS Id, 
    INSERTED.Name, 
    INSERTED.IdentificationNumber, 
    INSERTED.IdentificationType, 
    INSERTED.Country, 
    INSERTED.Phone
VALUES 
(@Name, 
@IdentificationNumber, 
@IdentificationType,
@Country,
@Phone);
