CREATE TABLE [dbo].[Salary]
(
	[IdSalary] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME2 NULL DEFAULT getutcdate(), 
    [IdUser] NVARCHAR(128) NOT NULL, 
    [Hajri] DECIMAL(18, 2) NOT NULL, 
    [HourWork] DECIMAL(18, 2) NULL, 
    [Salary] MONEY NOT NULL DEFAULT 0, 
    [Remark] NCHAR(150) NULL ,
    CONSTRAINT [FK_Salary_ToTableUser] FOREIGN KEY ([IdUser]) REFERENCES [User](Id), 
)