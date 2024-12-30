INSERT INTO Account 
(Number, 
Balance, 
OriginDate, 
CancellationDate, 
MaturityDate, 
DateLastModification) 
OUTPUT 
    INSERTED.AccountId AS Id, 
    INSERTED.Number, 
    INSERTED.Balance, 
    INSERTED.OriginDate,
    INSERTED.CancellationDate,
    INSERTED.MaturityDate,
    INSERTED.DateLastModification
VALUES 
(@Number, 
@Balance, 
GETDATE(), 
@CancellationDate, 
@MaturityDate,
GETDATE());
