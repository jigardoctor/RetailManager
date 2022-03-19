CREATE TABLE [dbo].[JobDetail]
(
	[IdJobDetail] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NatureOfJob] NCHAR(150) NOT NULL, 
    [DescritionOfJob] NCHAR(256) NULL, 
    [IdUser] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_JobDetail_ToTableUser] FOREIGN KEY ([IdUser]) REFERENCES [User](Id), 
)
