INSERT INTO LegalRepresentative 
(Name, 
IdentificationNumber, 
IdentificationType, 
Phone) 
OUTPUT 
    INSERTED.LegalRepresentativeId AS Id, 
    INSERTED.Name, 
    INSERTED.IdentificationNumber, 
    INSERTED.IdentificationType, 
    INSERTED.Phone
VALUES 
(@Name, 
@IdentificationNumber, 
@IdentificationType,
@Phone);
