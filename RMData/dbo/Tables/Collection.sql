CREATE TABLE [dbo].[Collection]
(
	[IdCollection] INT NOT NULL IDENTITY PRIMARY KEY, 
    [IdJobcard] INT NOT NULL, 
    [ReceiveDate] DATETIME2 NULL DEFAULT getutcdate(), 
    [ReceiveAmount] MONEY NOT NULL
)
