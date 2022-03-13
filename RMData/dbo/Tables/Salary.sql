CREATE TABLE [dbo].[Salary]
(
	[IdSalary] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME2 NULL DEFAULT getutcdate(), 
    [IdUser] INT NOT NULL, 
    [Hajri] DECIMAL(18, 2) NOT NULL, 
    [HourWork] DECIMAL(18, 2) NULL, 
    [Salary] MONEY NOT NULL DEFAULT 0, 
    [Remark] NCHAR(150) NULL ,
)