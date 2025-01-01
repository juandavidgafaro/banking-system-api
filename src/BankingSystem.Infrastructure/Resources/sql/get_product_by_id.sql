SELECT 
P.ProductId AS Id,
P.Type AS Type,
P.Status AS Status,
A.Number AS AccountNumber,
P.MonthlyInterestPercentage AS MonthlyInterestPercentage,
P.TermMonths AS TermMonths,
A.Balance AS AccountBalance,
P.ClientId AS ClientId,
P.AccountId AS AccountId
FROM 
Product P
JOIN 
Account A ON P.AccountId = A.AccountId
WHERE 
P.ProductId = @ProductId;