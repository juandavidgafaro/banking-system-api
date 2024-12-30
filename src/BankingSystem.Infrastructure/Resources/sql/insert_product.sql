INSERT INTO Product (Type, 
Status, 
MonthlyInterestPercentage, 
TermMonths, 
DateLastModification, 
ClientId, 
AccountId)
VALUES (@ProductType, 
@ProductStatus, 
@MonthlyInterestPercentage, 
@TermMonths,
GETDATE(), 
@ClientId, 
@AccountId);
