CREATE PROCEDURE [dbo].[emClient_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdClient,ClientName, GstNo,ReferredBy,Addr
	FROM [dbo].[Client]
	ORDER BY ClientName
end
