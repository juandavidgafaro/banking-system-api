UPDATE Account
SET 
CancellationDate = GETDATE()
WHERE AccountId = @AccountId;