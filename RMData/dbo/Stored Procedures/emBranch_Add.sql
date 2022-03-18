CREATE PROCEDURE [dbo].[emBranch_Add]
	@IdBranch INT,
	@branchname NVARCHAR(128),
	@ho bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Branch(BranchName, Ho)
	VALUES ( @branchname, @ho);
	SELECT @IdBranch = SCOPE_IDENTITY();
END

