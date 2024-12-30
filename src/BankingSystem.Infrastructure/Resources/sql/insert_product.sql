INSERT INTO Product 
(Type, 
Status, 
MonthlyInterestPercentage, 
TermMonths, 
DateLastModification, 
ClientId, 
AccountId)
OUTPUT 
    INSERTED.ProductId AS Id, 
    INSERTED.Type, 
    INSERTED.Status, 
    INSERTED.MonthlyInterestPercentage, 
    INSERTED.TermMonths, 
    INSERTED.DateLastModification, 
    INSERTED.ClientId, 
    INSERTED.AccountId
VALUES 
(@ProductType, 
@ProductStatus, 
@MonthlyInterestPercentage, 
@TermMonths,
GETDATE(), 
@ClientId, 
@AccountId);
