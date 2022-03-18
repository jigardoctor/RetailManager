CREATE PROCEDURE [dbo].[emBranch_Edit]
	@Id INT,
	@branchname NVARCHAR(128),
	@ho bit
AS
begin
set nocount on;
	UPDATE Branch set BranchName=@branchname , Ho=@ho where IdBranch = @Id;
end
