CREATE PROCEDURE [dbo].[emBranch_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdBranch,BranchName, Ho
	FROM [dbo].[Branch]
	ORDER BY BranchName
end
