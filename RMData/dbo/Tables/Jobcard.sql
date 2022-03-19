﻿CREATE TABLE [dbo].[Jobcard]
(
	[IdJobcard] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SrNo] INT NOT NULL, 
    [IdClient] INT NOT NULL, 
    [IdBranch] INT NOT NULL, 
    [IdJobDetail] INT NOT NULL, 
    [IdUserJobAllocatedBy] NVARCHAR(128) NOT NULL, 
    [JobAllocatedToHo] BIT NOT NULL DEFAULT 1, 
    [IdUserEmployee] NVARCHAR(128) NOT NULL, 
    [TimeAlloted] NCHAR(10) NULL, 
    [Status] NCHAR(15) NOT NULL DEFAULT 'INCOMPLETE', 
    [Resone] NCHAR(150) NULL, 
    [ComplitionDate] DATETIME2 NULL, 
    [TimeTaken] DECIMAL NULL DEFAULT 0, 
    [BillAmount] MONEY NOT NULL DEFAULT 0, 
    [IdHostName] INT NOT NULL, 
    [BillNo] NCHAR(150) NULL, 
    [BillDate] DATETIME2 DEFAULT getutcdate() NOT NULL, 
    [Remark] NCHAR(150) NULL, 
    CONSTRAINT [FK_Jobcard_ToTableClient] FOREIGN KEY ([IdClient]) REFERENCES [Client]([IdClient]), 
    CONSTRAINT [FK_Jobcard_ToTableBranch] FOREIGN KEY ([IdBranch]) REFERENCES [Branch]([IdBranch]), 
    CONSTRAINT [FK_Jobcard_ToTableJobDetail] FOREIGN KEY ([IdJobDetail]) REFERENCES [JobDetail]([IdJobDetail]), 
    CONSTRAINT [FK_Jobcard_ToTableHostName] FOREIGN KEY ([IdHostName]) REFERENCES [HostName]([IdHostName]), 
    CONSTRAINT [FK_Jobcard_ToTableUser] FOREIGN KEY  ([IdUserEmployee]) REFERENCES [User](Id), 
)
