CREATE PROCEDURE [dbo].[emClient_Edit]
	@Idclient INT,
	@clientname NVARCHAR(150),
	@gstno nvarchar(15),
	@referredby nvarchar(150),
	@addr nvarchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Client set ClientName=@clientname , GstNo=@gstno ,@referredby=@referredby,Addr=@addr where IdClient = @Idclient;
END
