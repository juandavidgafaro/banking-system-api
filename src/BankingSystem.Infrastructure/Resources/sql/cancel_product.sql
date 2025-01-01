UPDATE Product
SET 
DateLastModification = GETDATE(),
Status = @Status
WHERE ProductId = @ProductId;