---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 

CREATE PROCEDURE [dbo].[usp_IsVendorExists]
(
	@pUsername varchar(max),
	@pMobileNumber varchar(50),
	@pEmailAddress varchar(max) 
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @count int
	DECLARE @IsVendorExists bit
	SELECT @count = COUNT(1) from VENDOR V WHERE V.USER_NAME = @pUsername OR MOBILE_NUMBER = @pMobileNumber OR EMAIL_ADDRESS = @pEmailAddress
	IF(@count >0)
      BEGIN
	    SET @IsVendorExists = 1
	  END
	ELSE
	  BEGIN 
	     SET @IsVendorExists =0
	  END
	SELECT @IsVendorExists as IsVendorExists
END
GO

CREATE PROCEDURE [dbo].[usp_UpdateVendorRating]
(
  @pVendorRatingId binary(16),
  @pOrderId varchar(50),
  @pCustomerId binary(16),
  @pVendorId binary(16),
  @pServiceQuality decimal(18,2),
  @pPunctuality decimal(18,2),
  @pCourtesy decimal(18,2),
  @pPrice decimal(18,2),
  @pComments nvarchar(max),
  @pOrderPrice decimal(18,2)
)

AS
BEGIN

SET NOCOUNT ON;

  UPDATE [dbo].[VENDOR_RATING] 
  SET SERVICE_QUALITY = @pServiceQuality, PUNCTUALITY = @pPunctuality, COURTESY = @pCourtesy,
  PRICE = @pPrice, REVIEW_DATE = Getdate(), COMMENTS = @pComments, ORDER_ID = @pOrderId,
  VENDOR_ID = @pVendorId, CUSTOMER_ID = @pCustomerId, ORDER_PRICE = @pOrderPrice 
  WHERE  VENDOR_RATING_ID = @pVendorRatingId

END

GO

ALTER PROCEDURE [dbo].[usp_GetVendorsByService]
(  
  @pServiceId Binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

SELECT V.[VENDOR_ID],[NAME],[USER_NAME],[MOBILE_NUMBER],[EMAIL_ADDRESS],[IS_VENDOR_LIVE],[VENDOR_REF_ID]
   FROM [dbo].[VENDOR] V
   INNER JOIN [dbo].[VENDOR_SERVICES] VS ON V.VENDOR_ID = VS.VENDOR_ID
   WHERE VS.SERVICE_ID = @pServiceId
END
