﻿CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)

AS
begin
set nocount on;
	select Id,FirstName,LastName,EmailAddress,MonthlySalary
	from [dbo].[User]
	where Id = @Id
end
