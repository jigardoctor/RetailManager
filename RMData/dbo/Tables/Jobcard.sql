CREATE TABLE [dbo].[Jobcard]
(
	[IdJobcard] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SrNo] INT NOT NULL, 
    [IdClient] INT NOT NULL, 
    [IdBranch] INT NOT NULL, 
    [IdJobDetail] INT NOT NULL, 
    [IdUserJobAllocatedBy] INT NOT NULL, 
    [JobAllocatedToHo] BIT NOT NULL DEFAULT 1, 
    [IdUserEmpluyee] INT NOT NULL, 
    [TimeAlloted] NCHAR(10) NULL, 
    [Status] NCHAR(15) NOT NULL DEFAULT 'INCOMPLETE', 
    [Resone] NCHAR(150) NULL, 
    [ComplitionDate] DATETIME2 NULL, 
    [TimeTaken] DECIMAL NULL DEFAULT 0, 
    [BillAmount] MONEY NOT NULL DEFAULT 0, 
    [IdHostName] INT NOT NULL, 
    [BillNo] NCHAR(150) NULL, 
    [BillDate] DATETIME2 DEFAULT getutcdate() NOT NULL, 
    [Remark] NCHAR(150) NULL
)
