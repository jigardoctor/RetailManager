CREATE PROCEDURE [dbo].[emClient_Remove]
	@Id int 
AS
begin
set nocount on;
	DELETE FROM Client where IdClient = @Id;
end
