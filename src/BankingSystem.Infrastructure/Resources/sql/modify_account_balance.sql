UPDATE Account
SET 
Balance = @CurrentBalance
WHERE AccountId = @AccountId;