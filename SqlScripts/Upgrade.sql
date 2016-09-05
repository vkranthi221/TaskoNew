---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 
ALTER PROCEDURE [dbo].[usp_GetCustomerOrders]
(
      @pCustomerId binary(16),
	  @pOrderstatusId int,
	  @pPageNo int,
	  @pRecordsPerPage int
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @VSQL NVARCHAR(MAX)
            
SET @VSQL= 'SELECT ORD.ORDER_ID, OS.NAME AS ORDERSTATUS_NAME, SVCS.SERVICE_ID , SVCS.NAME AS SERVICE_NAME, ORD.REQUESTED_DATE, ORD.COMMENTS
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
WHERE ORD.CUSTOMER_ID = @vCustomerId '

IF(@pOrderstatusId<>0)
      SET @VSQL = @VSQL + ' AND ORD.ORDER_STATUS_ID = @vOrderstatusId '

	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID DESC OFFSET (@vPAGENO-1)*@vrecordsperpage ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vCustomerId binary(16),@vOrderstatusId int, @vPAGENO INT, @vRECORDSPERPAGE INT', @pCustomerId, @pOrderstatusId, @pPageNo, @pRecordsPerPage

END
GO


UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Refrigerator_Service.png' where NAME = 'Refrigerator Service'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Microwave_Service.png' where NAME = 'Microwave Service'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Mixer_Grinder_Repair.png' where NAME = 'Mixer Grinder Repair'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Washing_Machine_Service.png' where NAME = 'Semi-Automatic Washing Machine Service'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Washing_Machine_Service.png' where NAME = 'Fully Automatic Washing Machine Service'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/Bike_Service.png' where NAME = 'Bike Service'
UPDATE SERVICES SET IMAGE_URL = 'http://api.tasko.in/serviceimages/ac_services.png' where NAME = 'AC Installation'

GO

ALTER PROCEDURE [dbo].[usp_GetServiceVendors]
(
  @pServiceId binary(16),
  @pCustomerId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;
/*           CustomerRequested = 1,
-            VendorAccepted = 2,
             VendorRejected = 3,
             CustomerAccepted = 4,
             OrderCompleted = 5,
             CustomerCancelled = 6,
             VendorCancelled = 7 */

	SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID, V.BASE_RATE, CV.FAVORITE_ID, A.LATITIUDE AS LATITIUDE, A.LONGITUDE AS LONGITUDE,
	(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_REVIEWS, dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	INNER JOIN [ADDRESS] A ON V.ADDRESS_ID = A.ADDRESS_ID
	LEFT OUTER JOIN [dbo].[CUSTOMER_FAVORITE_VENDOR] CV ON CV.CUSTOMER_ID = @pCustomerId AND CV.VENDOR_ID = V.VENDOR_ID
	WHERE SVC.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1
	AND VS.VENDOR_SERVICE_ID NOT IN(SELECT VENDOR_SERVICE_ID FROM [ORDER] WHERE ORDER_STATUS_ID IN(1,2,4) AND DATEADD(HOUR,3,[REQUESTED_DATE]) >= GetDate())	
END

GO

ALTER TABLE[dbo].[VENDOR_RATING] ADD [ORDER_PRICE] decimal(18, 2) NULL

GO

USE [Tasko]
GO

ALTER PROCEDURE [dbo].[usp_AddVendorRating]
(
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

  INSERT INTO [dbo].[VENDOR_RATING] VALUES(NewId(),@pServiceQuality,@pPunctuality,@pCourtesy,@pPrice,Getdate(),@pComments,@pOrderId,@pVendorId,@pCustomerId,@pOrderPrice)

END

GO

ALTER PROCEDURE [dbo].[usp_GetVendorRatings]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT TOP 25 VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY, VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME, VR.ORDER_PRICE,
  ROUND(SUM(VR.SERVICE_QUALITY + VR.PUNCTUALITY + VR.COURTESY + VR.PRICE)/4,0) AS TOTAL
  FROM VENDOR_RATING VR
  INNER JOIN CUSTOMER CUST ON VR.CUSTOMER_ID = CUST.CUSTOMER_ID
  WHERE VR.VENDOR_ID= @pVendorId 
  GROUP BY VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY,VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME, VR.ORDER_PRICE
  ORDER BY REVIEW_DATE DESC
END

GO