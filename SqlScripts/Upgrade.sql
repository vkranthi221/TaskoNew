---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 


GO
CREATE PROCEDURE [dbo].[usp_GetServices]

AS
BEGIN

SET NOCOUNT ON;

SELECT [SERVICE_ID]
      ,[NAME]
      ,[PARENT_SERVICE_ID]
      ,[IMAGE_URL]
  FROM [dbo].[SERVICES]
  WHERE [PARENT_SERVICE_ID] IS NULL
END

GO
CREATE PROCEDURE [dbo].[usp_GetRecentOrder]
(
	@pCustomerId binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT TOP 1 ORD.ORDER_ID, Cust.CUSTOMER_ID, CUST.NAME AS CUSTOMER_NAME, VS.VENDOR_SERVICE_ID, VEN.VENDOR_ID ,VEN.NAME AS VENDOR_NAME, 
  SVCS.SERVICE_ID AS SERVICE_ID,SVCS.NAME AS SERVICE_NAME , OS.ORDER_STATUS_ID, OS.NAME AS ORDERSTATUS_NAME,
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION, ORD.SOURCE_ADDRESS_ID, ORD.DESTINATION_ADDRESS_ID
  FROM dbo.[ORDER] ORD
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR VEN ON VS.VENDOR_ID= VEN.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID   
WHERE ORD.CUSTOMER_ID = @pCustomerId ORDER BY ORD.REQUESTED_DATE DESC

---- Source Address
 SELECT TOP 1 Address_ID,COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[SOURCE_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORD.CUSTOMER_ID = @pCustomerId ORDER BY ORD.REQUESTED_DATE DESC

 ---- Destination Address
 SELECT TOP 1 Address_ID,COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[DESTINATION_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORD.CUSTOMER_ID = @pCustomerId ORDER BY ORD.REQUESTED_DATE DESC
END

GO

CREATE PROCEDURE [dbo].[usp_GetServiceVendors]
(
  @pServiceId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

	SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	WHERE SVC.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1
END

GO
CREATE PROCEDURE [dbo].[usp_AddAddress]
(
  @pCountry nvarchar(max),
  @pState nvarchar(max),
  @pLatitude nvarchar(max),
  @pLongitude nvarchar(max),
  @pLocality nvarchar(max),
  @pCity nvarchar(max),
  @pAddress nvarchar(max),
  @Pincode nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

  DECLARE @AddressId binary(16)
  SET  @AddressId = newId()

  INSERT INTO [dbo].[ADDRESS] VALUES(@AddressId,@pCountry,@pState,@pLatitude,@pLongitude,@pLocality,@pCity,@pAddress,@Pincode)

  SELECT @AddressId as ADDRESS_ID
END

GO

CREATE PROCEDURE [dbo].[usp_ConfirmOrder]
(
  @pVendorServiceId binary(16),
  @pCustomerId binary(16),
  @pSourceAddressId binary(16),
  @pDestinationAddressId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

  DECLARE @OrderId Varchar(50)
  SET  @OrderId = dbo.GenerateOrderID()

  INSERT INTO [dbo].[ORDER] VALUES(@OrderId,@pVendorServiceId,@pCustomerId,GetDate(),1,'',@pSourceAddressId,@pDestinationAddressId)

  SELECT @OrderId as ORDER_ID
END

GO
