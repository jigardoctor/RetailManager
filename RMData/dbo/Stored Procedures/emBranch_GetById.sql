CREATE PROCEDURE [dbo].[emBranch_GetById]
	@Id int
AS
BEGIN
SET NOCOUNT ON;

	SELECT IdBranch, BranchName ,Ho
	FROM [dbo].Branch
	WHERE IdBranch = @Id
end	
