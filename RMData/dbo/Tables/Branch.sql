CREATE TABLE [dbo].[Branch]
(
	[IdBranch] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BranchName] NCHAR(150) NOT NULL, 
    [Ho] BIT NOT NULL DEFAULT 0, 
)
