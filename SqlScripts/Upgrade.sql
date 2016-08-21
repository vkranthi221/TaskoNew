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

