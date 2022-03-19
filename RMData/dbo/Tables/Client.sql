CREATE TABLE [dbo].[Client]
(
	[IdClient] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientName] NCHAR(150) NOT NULL, 
    [GstNo] NCHAR(15) NOT NULL, 
    [ReferredBy] NCHAR(150) NULL, 
    [Addr] NCHAR(250) NULL, 

)
