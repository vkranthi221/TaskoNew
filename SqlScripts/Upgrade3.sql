---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 
CREATE PROCEDURE [dbo].[usp_DeleteFavoriteVendor]
(
  @pCustomerId binary(16), 
  @pVendorId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

  DELETE FROM [dbo].CUSTOMER_FAVORITE_VENDOR WHERE VENDOR_ID = @pVendorId AND CUSTOMER_ID = @pCustomerId
END
GO

ALTER PROCEDURE [dbo].[usp_SetFavoriteVendor]
(
  @pCustomerId binary(16), 
  @pVendorId binary(16)
)

AS
BEGIN

DECLARE @IsFavouriteVendorAlreadySet bit
SET NOCOUNT ON;
	IF EXISTS (SELECT VENDOR_ID from [dbo].CUSTOMER_FAVORITE_VENDOR WHERE VENDOR_ID = @pVendorId AND CUSTOMER_ID = @pCustomerId)
		BEGIN
			SET @IsFavouriteVendorAlreadySet =1
		END
	ELSE
	BEGIN
	  INSERT INTO [dbo].CUSTOMER_FAVORITE_VENDOR VALUES(newid(), @pVendorId, @pCustomerId)
	  SET @IsFavouriteVendorAlreadySet =0
	END	
END

GO