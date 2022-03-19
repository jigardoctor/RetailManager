CREATE PROCEDURE [dbo].[emClient_GetById]
	@Id int
AS
BEGIN
SET NOCOUNT ON;

	SELECT IdClient, ClientName	 ,GstNo,ReferredBy,Addr
	FROM [dbo].[Client]
	WHERE IdClient = @Id
end	
