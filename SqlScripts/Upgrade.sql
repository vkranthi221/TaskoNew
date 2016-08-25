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

--            CustomerRequested = 1,
--            VendorAccepted = 2,
--            VendorRejected = 3,
--            CustomerAccepted = 4,
--            OrderCompleted = 5,
--            CustomerCancelled = 6,
--            VendorCancelled = 7,

SET NOCOUNT ON;
	SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID, V.BASE_RATE, CV.FAVORITE_ID,
	(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_REVIEWS, dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	LEFT OUTER JOIN [dbo].[CUSTOMER_FAVORITE_VENDOR] CV ON CV.CUSTOMER_ID = @pCustomerId AND CV.VENDOR_ID = V.VENDOR_ID
	WHERE VS.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1  
	AND VS.VENDOR_SERVICE_ID NOT IN(SELECT VENDOR_SERVICE_ID FROM [ORDER] WHERE ORDER_STATUS_ID IN(1,2,4))
END

GO