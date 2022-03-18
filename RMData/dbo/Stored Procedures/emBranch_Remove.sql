CREATE PROCEDURE [dbo].[emBranch_Remove]
	@Id int 
AS
begin
set nocount on;
	DELETE FROM Branch where IdBranch = @Id;
end
