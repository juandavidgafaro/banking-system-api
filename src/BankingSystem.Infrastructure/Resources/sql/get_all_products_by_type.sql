SELECT 
P.ProductId AS Id,
P.Type AS Type,
P.Status AS Status,
P.MonthlyInterestPercentage AS MonthlyInterestPercentage,
P.TermMonths AS TermMonths,
C.ClientId AS ClientId,
C.Name AS ClientName,
C.IdentificationNumber AS ClientIdentificationNumber,
C.IdentificationType AS ClientIdentificationType,
C.PersonType AS ClientPersonType,
C.Country AS ClientCountry,
A.AccountId AS AccountId,
A.Number AS AccountNumber,
A.Balance AS AccountBalance
FROM 
Product P
JOIN 
Client C ON P.ClientId = C.ClientId
JOIN
Account A ON P.AccountId = A.AccountId
WHERE 
P.Type = @ProductType;