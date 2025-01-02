--﻿INSERT INTO Product 
--(Type, 
--Status, 
--MonthlyInterestPercentage, 
--TermMonths, 
--DateLastModification, 
--ClientId, 
--AccountId)
--VALUES 
--(@ProductType, 
--@ProductStatus, 
--@MonthlyInterestPercentage, 
--@TermMonths,
--GETDATE(), 
--@ClientId, 
--@AccountId);

--SELECT SCOPE_IDENTITY();

DECLARE @Id INT;

INSERT INTO Product 
(Type, 
Status, 
MonthlyInterestPercentage, 
TermMonths, 
DateLastModification, 
ClientId, 
AccountId)
VALUES 
(@ProductType, 
@ProductStatus, 
@MonthlyInterestPercentage, 
@TermMonths,
GETDATE(), 
@ClientId, 
@AccountId);

SET @Id = SCOPE_IDENTITY();

SELECT @Id;