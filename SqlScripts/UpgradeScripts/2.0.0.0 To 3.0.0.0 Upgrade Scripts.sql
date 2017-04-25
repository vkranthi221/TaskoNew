--------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 

ALTER TABLE [ORDER] ADD IS_OFFLINE bit
GO
 UPDATE [ORDER] SET IS_OFFLINE = 0
GO

ALTER TABLE [ORDER] ADD IS_ORDER_NOTIFIED bit
GO
UPDATE [ORDER] SET IS_ORDER_NOTIFIED = 1
GO

ALTER TABLE [ORDER] ADD B_TO_B_CUSTOMER_NAME Varchar(MAX)
GO

ALTER TABLE [dbo].[ADDRESS] ADD  [HOME_LONGITUDE] [NVARCHAR](MAX) NULL, [HOME_LATITIUDE] [NVARCHAR](MAX) NULL
GO

INSERT INTO CUSTOMER VALUES (0X56BA452B096A7E448DABD357277551BF,'Tasko Customer','taskocustomer@tasko.in','999', 1, GETDATE())
GO

ALTER PROCEDURE [dbo].[usp_ConfirmOrder]
(
  @pVendorServiceId binary(16),
  @pCustomerId binary(16),
  @pSourceAddressId binary(16),
  @pDestinationAddressId binary(16),
  @pIsOffline bit,
  @pBToBCustomerName varchar(MAX)
)

AS
BEGIN

SET NOCOUNT ON;

  DECLARE @OrderId Varchar(50)
  SET  @OrderId = dbo.GenerateOrderID()
  DECLARE @OrderStatusId int
  SET @OrderStatusId = 1 --Pending

  --IF(@pIsOffline = 1)
  --BEGIN
  -- SET @OrderStatusId = 6 --Completed for Offline Orders
  --END

  INSERT INTO [dbo].[ORDER] VALUES(@OrderId,@pVendorServiceId,@pCustomerId,GetDate(),
                                    @OrderStatusId,'',@pSourceAddressId,@pDestinationAddressId,
									null, null,null,null,null, @pIsOffline, 0, @pBToBCustomerName)

  IF EXISTS (Select ORDER_ID FROM dbo.[ORDER] WHERE ORDER_ID = @OrderId)
  BEGIN
     --- We should log the activity only when the above insert statement is success.
	  DECLARE @pComment nvarchar(max)
	  SET @pComment = CONCAT('New Order ', @OrderId, ' has been placed.')
	  EXEC [dbo].[usp_AddActivity] 'ORDER', null, null, @OrderId, @pComment
  END
  SELECT @OrderId as ORDER_ID
END

GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetOfflineOrdersWithNoRatings]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetOfflineOrdersWithNoRatings] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_GetOfflineOrdersWithNoRatings]
AS
BEGIN

SET NOCOUNT ON;
 
SELECT ORD.REQUESTED_DATE,ORD.ORDER_ID, SVCS.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME as VENDOR_NAME, ORD.CUSTOMER_ID
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR V ON V.VENDOR_ID = VS.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  WHERE ORD.IS_OFFLINE = 1 AND ORD.IS_ORDER_NOTIFIED = 0 
  AND ORD.ORDER_ID Not In(Select ORDER_ID from VENDOR_RATING)
  AND GETDATE() > DATEADD(day,3,ORD.REQUESTED_DATE) AND ORD.CUSTOMER_ID <> 0X56BA452B096A7E448DABD357277551BF
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateOrderIsNotified]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_UpdateOrderIsNotified] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_UpdateOrderIsNotified]
(
	@pOrderId varchar(50)
)
AS
BEGIN
  UPDATE [dbo].[ORDER]  SET IS_ORDER_NOTIFIED = 1 WHERE ORDER_ID = @pOrderId	
END
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
  Update dbo.[ORDER] SET IS_ORDER_NOTIFIED = 1 WHERE ORDER_ID = @pOrderId AND CUSTOMER_ID = @pCustomerId

END
GO

ALTER PROCEDURE [dbo].[usp_GetVendorAddress]
(
  @pVendorId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

 SELECT Addr.ADDRESS_ID, ADDRESS_TYPE, COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE, HOME_LATITIUDE, HOME_LONGITUDE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.VENDOR V ON V.[ADDRESS_ID] = Addr.[Address_ID]
 WHERE V.VENDOR_ID = @pVendorId 
END
GO

ALTER PROCEDURE [dbo].[usp_GetVendorDetails]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;
SELECT VD.VENDOR_ID
      ,VD.USER_NAME
      ,VD.NAME
      ,VD.MOBILE_NUMBER
      ,VD.EMAIL_ADDRESS
	  ,AD.Address_ID
      ,AD.Address AS VENDOR_ADDRESS
	  ,AD.COUNTRY AS VENDOR_COUNTRY
	  ,AD.CITY AS VENDOR_CITY
	  ,AD.ADDRESS_TYPE AS VENDOR_ADDRESS_TYPE
	  ,AD.[STATE] AS VENDOR_STATE
	  ,AD.LATITIUDE AS VENDOR_LATTITUDE
	  ,AD.LOCALITY AS VENDOR_LOCALITY
	  ,AD.LONGITUDE AS VENDOR_LONGITUDE
	  ,AD.PINCODE AS VENDOR_PINCODE
	  ,AD.HOME_LATITIUDE 
	  ,AD.HOME_LONGITUDE AS HOME_LONGITUDE
      ,VD.PHOTO
      ,VD.EMPLOYEE_COUNT
      ,VD.BASE_RATE
      ,VD.IS_VENDOR_VERIFIED
      ,VD.IS_VENDOR_LIVE
      ,VD.TIME_SPENT_ON_APP
      ,VD.ACTIVE_TIME_PER_DAY
      ,VD.DATA_CONSUMPTION
      ,VD.CALLS_TO_CUSTOMER_CARE
	  ,VD.DATE_OF_BIRTH
	  ,VD.GENDER
	  ,VD.REGISTERED_DATE
	  ,VD.VENDOR_REF_ID
	  ,VD.VENDOR_ALSO_KNOWN_AS
	  ,VD.EXPERIENCE
	  ,VD.FACEBOOK_URL
	  ,VD.IS_VENDOR_VERIFIED
	  ,VD.PHOTO
	  ,VD.IS_POWER_SELLER
	  ,VD.MONTHLY_CHARGE
   FROM [dbo].[VENDOR] VD (NOLOCK)
   INNER JOIN ADDRESS AD ON VD.ADDRESS_ID = AD.Address_ID
   WHERE VENDOR_ID = @pVendorId 
END
GO

ALTER PROCEDURE [dbo].[usp_UpdateVendorLocation]
(
	@pLatitude nvarchar(max),
	@pLongitude nvarchar(max),
	@pVendorId nvarchar(max),
	@pAddress nvarchar(max),
	@pAddressType nvarchar(max),
	@pCity nvarchar(max),
	@pCountry nvarchar(max),
	@pLocality nvarchar(max),
	@pPincode nvarchar(max),
	@pState nvarchar(max),
	@pHomeLatitude nvarchar(max),
	@pHomeLongitude nvarchar(max)
)

AS
BEGIN

IF(Len(@pHomeLatitude) > 0 AND @pHomeLatitude != '0' AND Len(@pHomeLongitude) > 0 AND @pHomeLongitude !='0')
BEGIN
UPDATE A1 SET A1.LONGITUDE= @pLongitude, A1.LATITIUDE = @pLatitude, A1.COUNTRY = @pCountry, A1.STATE = @pState, A1.LOCALITY = @pLocality, A1.CITY = @pCity, A1.ADDRESS = @pAddress,
A1.PINCODE = @pPincode, A1.ADDRESS_TYPE = @pAddressType, A1.HOME_LATITIUDE = @pHomeLatitude, A1.HOME_LONGITUDE = @pHomeLongitude FROM [ADDRESS] AS A1
INNER JOIN VENDOR V ON V.ADDRESS_ID = A1.Address_ID WHERE V.VENDOR_ID = @pVendorId
END
ELSE
BEGIN
UPDATE A1 SET A1.LONGITUDE= @pLongitude, A1.LATITIUDE = @pLatitude, A1.COUNTRY = @pCountry, A1.STATE = @pState, A1.LOCALITY = @pLocality, A1.CITY = @pCity, A1.ADDRESS = @pAddress,
A1.PINCODE = @pPincode, A1.ADDRESS_TYPE = @pAddressType FROM [ADDRESS] AS A1
INNER JOIN VENDOR V ON V.ADDRESS_ID = A1.Address_ID WHERE V.VENDOR_ID = @pVendorId
END

if @pLongitude = '0' and @pLatitude  = '0'
Begin
update vendor set IS_VENDOR_LIVE = 0 where VENDOR_ID = @pVendorId
END 

END
GO

ALTER PROCEDURE [dbo].[usp_GetServiceVendors]
(
  @pServiceId binary(16),
  @pCustomerId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

    SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID, V.BASE_RATE, CV.FAVORITE_ID, 
	A.LATITIUDE AS LATITIUDE, A.LONGITUDE AS LONGITUDE,	A.HOME_LATITIUDE AS HOME_LATITIUDE, A.HOME_LONGITUDE AS HOME_LONGITUDE,
	(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_REVIEWS,
	dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS,V.FACEBOOK_URL,V.PHOTO, V.MOBILE_NUMBER	
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	INNER JOIN [ADDRESS] A ON V.ADDRESS_ID = A.ADDRESS_ID
	LEFT OUTER JOIN [dbo].[CUSTOMER_FAVORITE_VENDOR] CV ON CV.CUSTOMER_ID = @pCustomerId AND CV.VENDOR_ID = V.VENDOR_ID
	WHERE SVC.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1
	--AND VS.VENDOR_SERVICE_ID NOT IN(SELECT VENDOR_SERVICE_ID FROM [ORDER] WHERE ORDER_STATUS_ID IN(1,2,4) AND DATEADD(HOUR,3,[REQUESTED_DATE]) >= GetDate())	
END
GO

ALTER PROCEDURE [dbo].[usp_GetAllCustomersByStatus]
(
	@pStatus smallint
)
AS
BEGIN

	SET NOCOUNT ON;

	if(@pStatus = 0)
	BEGIN
		SELECT [CUSTOMER_ID]
			  ,[NAME]
			  ,[MOBILE_NUMBER]
			  ,[EMAIL_ADDRESS]
			  ,[REGISTERED_DATE]
		FROM [dbo].[CUSTOMER] (NOLOCK)
	END
	ELSE
	BEGIN
		SELECT [CUSTOMER_ID]
			  ,[NAME]
			  ,[MOBILE_NUMBER]
			  ,[EMAIL_ADDRESS]
			  ,[REGISTERED_DATE]
		FROM [dbo].[CUSTOMER] (NOLOCK)
		WHERE STATUS = @pStatus
	END
END
GO

ALTER PROCEDURE [dbo].[usp_AddAddress]
(
  @pCountry nvarchar(max),
  @pState nvarchar(max),
  @pLatitude nvarchar(max),
  @pLongitude nvarchar(max),
  @pLocality nvarchar(max),
  @pCity nvarchar(max),
  @pAddress nvarchar(max),
  @Pincode nvarchar(max),
  @pAddressType nvarchar(max),
  @pHomeLongitude nvarchar(max),
  @pHomeLatitude nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

  DECLARE @AddressId binary(16)
  SET  @AddressId = newId()

  INSERT INTO [dbo].[ADDRESS] VALUES(@AddressId,@pCountry,@pState,@pLatitude,@pLongitude,@pLocality,@pCity,@pAddress,@Pincode,@pAddressType,@pHomeLongitude,@pHomeLatitude)

  SELECT @AddressId as ADDRESS_ID
END

GO
ALTER PROCEDURE [dbo].[usp_GetCustomerDetails]
(
	@pCustomerId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT [CUSTOMER_ID]
      ,[NAME]
      ,[MOBILE_NUMBER]
      ,[EMAIL_ADDRESS]
	  ,[REGISTERED_DATE]
FROM [dbo].[CUSTOMER] (NOLOCK)
WHERE CUSTOMER_ID = @pCustomerId 

END
GO

ALTER PROCEDURE [dbo].[usp_GetOrdersByService]
(  
  @pServiceId Binary(16),
  @pIsOffline bit
)

AS
BEGIN

SET NOCOUNT ON;

SELECT [ORDER_ID],[REQUESTED_DATE], OS.[NAME] AS ORDER_STATUS_NAME, CUST.[NAME] AS CUSTOMER_NAME, SVS.[NAME] AS [SERVICE_NAME], V.[NAME] AS VENDOR_NAME
   FROM [dbo].[ORDER] ORD
   INNER JOIN [dbo].[ORDER_STATUS] OS ON OS.ORDER_STATUS_ID = ORD.ORDER_STATUS_ID
   INNER JOIN [dbo].[CUSTOMER] CUST ON CUST.CUSTOMER_ID = ORD.CUSTOMER_ID
   INNER JOIN [dbo].[VENDOR_SERVICES] VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
   INNER JOIN [dbo].[SERVICES] SVS ON SVS.SERVICE_ID = VS.SERVICE_ID
   INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID

   WHERE VS.SERVICE_ID = @pServiceId AND ORD.IS_OFFLINE = @pIsOffline
END
GO

ALTER PROCEDURE [dbo].[usp_UpdateCustomerAddress]
(
  @pAddressId binary(16),  
  @pCountry nvarchar(max),
  @pState nvarchar(max),
  @pLatitude nvarchar(max),
  @pLongitude nvarchar(max),
  @pLocality nvarchar(max),
  @pCity nvarchar(max),
  @pAddress nvarchar(max),
  @Pincode nvarchar(max),
  @pAddressType nvarchar(max),
  @pHomeLongitude nvarchar(max),
  @pHomeLatitude nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

  DECLARE @AddressId binary(16)
  SET  @AddressId = newId()

  UPDATE [dbo].[ADDRESS] SET COUNTRY = @pCountry, STATE= @pState, LATITIUDE = @pLatitude, 
                         LONGITUDE = @pLongitude,LOCALITY = @pLocality,CITY = @pCity,
                         [ADDRESS]=@pAddress,PINCODE = @Pincode, ADDRESS_TYPE = @pAddressType,
						 HOME_LONGITUDE = @pHomeLongitude, HOME_LATITIUDE =@pHomeLatitude
  WHERE Address_ID = @pAddressId

  SELECT @AddressId as ADDRESS_ID
END
GO


ALTER PROCEDURE [dbo].[usp_GetVendorOrders]
(
      @pVENDORID BINARY(16) = NULL,
      @pORDERSTATUSID INT,
	  @pPAGENO INT,
	  @pRECORDSPERPAGE INT,
	  @pISOFFLINE bit
)
AS
BEGIN

SET NOCOUNT ON;
DECLARE @VSQL NVARCHAR(MAX)
    
IF @pVENDORID IS NOT NULL   
SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME, ORD.COMMENTS, VS.VENDOR_ID, ORD.B_TO_B_CUSTOMER_NAME
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
  WHERE VS.VENDOR_ID = @VVENDORID AND ORD.IS_OFFLINE = @pISOFFLINE'
  ELSE
  SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME, VD.NAME AS VENDOR_NAME, 
  CUST.NAME AS CUSTOMER_NAME, VD.VENDOR_ID, CUST.CUSTOMER_ID, ORD.B_TO_B_CUSTOMER_NAME
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID
  INNER JOIN VENDOR VD ON VD.VENDOR_ID = VS.VENDOR_ID
  INNER JOIN CUSTOMER CUST ON CUST.CUSTOMER_ID= ORD.CUSTOMER_ID'

IF(@PORDERSTATUSID<>0)
      SET @VSQL = @VSQL + ' AND ORD.ORDER_STATUS_ID = @vORDERSTATUSID '

	  SET @VSQL = @VSQL + ' AND ORD.IS_OFFLINE = @pISOFFLINE'

IF(@pPAGENO<>0)
	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID DESC OFFSET (@vPAGENO-1)*@vRECORDSPERPAGE ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vVENDORID BINARY(16),@vORDERSTATUSID INT, @vPAGENO INT, @vRECORDSPERPAGE INT, @pISOFFLINE bit', @pVENDORID, @pORDERSTATUSID, @pPAGENO, @pRECORDSPERPAGE,@pISOFFLINE

END


ALTER PROCEDURE [dbo].[usp_GetOrderDetails]
(
	@pOrderId Varchar(50)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT ORD.ORDER_ID, Cust.CUSTOMER_ID, CUST.NAME AS CUSTOMER_NAME, VS.VENDOR_SERVICE_ID, VEN.VENDOR_ID ,VEN.NAME AS VENDOR_NAME, VEN.PHOTO,
  SVCS.SERVICE_ID AS SERVICE_ID,SVCS.NAME AS SERVICE_NAME , SVCS.IMAGE_URL, OS.ORDER_STATUS_ID, OS.NAME AS ORDERSTATUS_NAME,
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION ,ORD.SOURCE_ADDRESS_ID, ORD.DESTINATION_ADDRESS_ID,ORD.COMMENTS,
  CUST.MOBILE_NUMBER AS CUSTOMER_MOBILE_NUMBER, VEN.MOBILE_NUMBER AS VENDOR_MOBILE_NUMBER, ORD.CUSTOMER_DISTANCE, ORD.CUSTOMER_ETA, ORD.VISITING_FEE,
  ORD.B_TO_B_CUSTOMER_NAME
  FROM dbo.[ORDER] ORD
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR VEN ON VS.VENDOR_ID= VEN.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID   
WHERE ORDER_ID = @pOrderId 

---- Source Address
 --SELECT [Address_ID],[ADDRESS_TYPE],[COUNTRY],[STATE],[LATITIUDE] ,[LONGITUDE] ,[LOCALITY],[CITY],[ADDRESS],[PINCODE]
 --FROM dbo.[ADDRESS] Addr
 --INNER JOIN dbo.[ORDER] ORD ON ORD.[SOURCE_ADDRESS_ID] = Addr.[Address_ID]
 --WHERE ORDER_ID = @pOrderId 

 SELECT ORDER_PRICE, SERVICE_QUALITY, PUNCTUALITY, COURTESY, PRICE FROM [dbo].[VENDOR_RATING] WHERE ORDER_ID =  @pOrderId 

 ---- Destination Address
 SELECT [Address_ID],[ADDRESS_TYPE], [COUNTRY],[STATE],[LATITIUDE] ,[LONGITUDE] ,[LOCALITY],[CITY],[ADDRESS],[PINCODE]
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[DESTINATION_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORDER_ID = @pOrderId 
 
 SELECT ROUND(((SUM(VR.SERVICE_QUALITY)+ SUM(VR.PUNCTUALITY)+SUM(VR.COURTESY)+SUM(VR.PRICE))/count(*))/4,0) AS OVERALL_RATING
   FROM VENDOR_RATING VR  WHERE VR.ORDER_ID = @pOrderId
END


IF NOT EXISTS (SELECT * FROM [dbo].[DB_VERSION] WHERE [VERSION] = '3.0.0.0')
BEGIN
     INSERT INTO [dbo].[DB_VERSION] values('3.0.0.0', Getdate())
END
GO