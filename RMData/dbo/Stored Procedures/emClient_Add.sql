CREATE PROCEDURE [dbo].[emClient_Add]
	@Idclient INT,
	@clientname NVARCHAR(150),
	@gstno nvarchar(15),
	@referredby nvarchar(150),
	@addr nvarchar(250)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Client(ClientName, GstNo,ReferredBy,Addr)
	VALUES ( @clientname, @gstno,@referredby,@addr);
	SELECT @Idclient = SCOPE_IDENTITY();
END
