CREATE TABLE [dbo].[JobDetail]
(
	[IdJobDetail] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NatureOfJob] NCHAR(150) NOT NULL, 
    [DescritionOfJob] NCHAR(256) NULL, 
    [IdUser] INT NOT NULL, 
)
