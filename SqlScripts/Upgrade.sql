---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 

ALTER TABLE [dbo].[VENDOR] ADD [FACEBOOK_URL] NVARCHAR(MAX) NULL

GO
ALTER PROCEDURE [dbo].[usp_AddVendor]
(
  @pBaseRate float,
  @pEmailAddress nvarchar(max),
  @pIsVendorLive bit,
  @pIsVendorVerified bit,
  @pMobileNumber nvarchar(max),
  @pName nvarchar(max),
  @pNoOfEmployees int,
  --@pTimeSpentOnApp nvarchar(max),
  @pUserName nvarchar(max),
  @pAddressId binary(16),
  @pPassword nvarchar(max),
  @pDOB datetime,
  @pGender bit,
  @pPhoto nvarchar(max),
  @pAreOrdersBlocked bit,
  @pIsBlocked bit,
  @pIsPowerSeller bit,
  @pMonthlyCharge decimal,
  @pVendorAlsoKnownAs nvarchar(50),
  @pExperience nvarchar(50),
  @pFacebookUrl nvarchar(max)

  --@pActiveTimePerDay nvarchar(max),
  --@pDataConsumption int,
  --@pCallsToCustomerCare int
)

AS
BEGIN
SET NOCOUNT ON;
DECLARE @vendorId Binary(16),
		@vendorCount int
SET @vendorId = NEWID()

SET @vendorCount = (SELECT COUNT(*) FROM VENDOR WHERE [USER_NAME] = @PUSERNAME)

IF(@vendorCount = 0)
BEGIN
INSERT INTO VENDOR (VENDOR_ID, [USER_NAME], NAME, MOBILE_NUMBER, [PASSWORD], EMAIL_ADDRESS, ADDRESS_ID, EMPLOYEE_COUNT, BASE_RATE, IS_VENDOR_VERIFIED, IS_VENDOR_LIVE, DATE_OF_BIRTH, GENDER, PHOTO, ARE_ORDERS_BLOCKED, IS_BLOCKED,MONTHLY_CHARGE,IS_POWER_SELLER, REGISTERED_DATE, VENDOR_ALSO_KNOWN_AS, EXPERIENCE, FACEBOOK_URL) 
    VALUES (@vendorId, @pUserName, @pName, @pMobileNumber, @pPassword, @pEmailAddress, @pAddressId, @pNoOfEmployees, @pBaseRate,   @pIsVendorVerified,@pIsVendorLive, @pDOB, @pGender, @pPhoto, @pAreOrdersBlocked,@pIsBlocked,@pMonthlyCharge,@pIsPowerSeller, GETDATE(), @pVendorAlsoKnownAs, @pExperience, @pFacebookUrl)

	IF EXISTS (Select VENDOR_ID FROM dbo.VENDOR WHERE VENDOR_ID = @vendorId)
	BEGIN   
	-- If add Vendor success then only add the entry in Activity table
		DECLARE @pComment nvarchar(max)
		SET @pComment = CONCAT('Vendor ', @pName, ' registered.')
		EXEC [dbo].[usp_AddActivity] 'VENDOR', null, @vendorId, null, @pComment
	END

	SELECT @vendorId as VENDOR_ID
  END 
END

GO
ALTER PROCEDURE [dbo].[usp_UpdateVendor]
(
	@pVendorId binary(16),
	@pName nvarchar(max),
	@pMobileNumber nvarchar(max),  
	@pEmailAddress nvarchar(max),
	@pGender bit,
	@pDOB datetime,
	@pVendorAlsoKnownAs nvarchar(50),
	@pExperience nvarchar(50),
	@pFacebookUrl nvarchar(max) 
)

AS
BEGIN

SET NOCOUNT ON;

UPDATE [dbo].VENDOR SET NAME = COALESCE(@pName,NAME),
						MOBILE_NUMBER = COALESCE(@pMobileNumber,MOBILE_NUMBER),	
						DATE_OF_BIRTH = COALESCE(@pDOB,DATE_OF_BIRTH),	
						GENDER = COALESCE(@pGender, GENDER),
						EMAIL_ADDRESS = COALESCE(@pEmailAddress, EMAIL_ADDRESS),
						VENDOR_ALSO_KNOWN_AS = COALESCE(@pVendorAlsoKnownAs, VENDOR_ALSO_KNOWN_AS),
						EXPERIENCE = COALESCE(@pExperience, EXPERIENCE),
						FACEBOOK_URL = COALESCE(@pFacebookUrl, FACEBOOK_URL)
WHERE VENDOR_ID = @pVendorId

END

GO

ALTER PROCEDURE [dbo].[usp_UpdateVendorDetails]
(
	@pVendorId binary(16),
	@pName nvarchar(max),
	@pMobileNumber nvarchar(max),  
	@pEmailAddress nvarchar(max),
	@pGender bit,
	@pDOB datetime,
	@pPhoto nvarchar(max),
	@pAreOrdersBlocked bit,
	@pIsPowerSeller bit,
	@pIsBlocked bit,
	@pMonthlyCharge decimal,
	@pFacebookUrl nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

UPDATE [dbo].VENDOR SET NAME = COALESCE(@pName,NAME),
						MOBILE_NUMBER = COALESCE(@pMobileNumber,MOBILE_NUMBER),	
						DATE_OF_BIRTH = COALESCE(@pDOB,DATE_OF_BIRTH),	
						GENDER = COALESCE(@pGender, GENDER),
						EMAIL_ADDRESS = COALESCE(@pEmailAddress, EMAIL_ADDRESS),
						PHOTO =  COALESCE(@pPhoto, PHOTO),
						ARE_ORDERS_BLOCKED = @pAreOrdersBlocked,
						IS_BLOCKED = @pIsBlocked,
						MONTHLY_CHARGE = @pMonthlyCharge,
						IS_POWER_SELLER = @pIsPowerSeller,
						FACEBOOK_URL = COALESCE(@pFacebookUrl, FACEBOOK_URL)
WHERE VENDOR_ID = @pVendorId

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
      ,AD.Address AS VENDOR_ADDRESS
	  ,AD.COUNTRY AS VENDOR_COUNTRY
	  ,AD.CITY AS VENDOR_CITY
	  ,AD.ADDRESS_TYPE AS VENDOR_ADDRESS_TYPE
	  ,AD.[STATE] AS VENDOR_STATE
	  ,AD.LATITIUDE AS VENDOR_LATTITUDE
	  ,AD.LOCALITY AS VENDOR_LOCALITY
	  ,AD.LONGITUDE AS VENDOR_LONGITUDE
	  ,AD.PINCODE AS VENDOR_PINCODE
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
   FROM [dbo].[VENDOR] VD (NOLOCK)
   INNER JOIN ADDRESS AD ON VD.ADDRESS_ID = AD.Address_ID
   WHERE VENDOR_ID = @pVendorId 
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
/*           CustomerRequested = 1,
-            VendorAccepted = 2,
             VendorRejected = 3,
             CustomerAccepted = 4,
             OrderCompleted = 5,
             CustomerCancelled = 6,
             VendorCancelled = 7 */

    SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID, V.BASE_RATE, CV.FAVORITE_ID, A.LATITIUDE AS LATITIUDE, A.LONGITUDE AS LONGITUDE,
	(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_REVIEWS, dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS,V.FACEBOOK_URL	
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	INNER JOIN [ADDRESS] A ON V.ADDRESS_ID = A.ADDRESS_ID
	LEFT OUTER JOIN [dbo].[CUSTOMER_FAVORITE_VENDOR] CV ON CV.CUSTOMER_ID = @pCustomerId AND CV.VENDOR_ID = V.VENDOR_ID
	WHERE SVC.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1
	AND VS.VENDOR_SERVICE_ID NOT IN(SELECT VENDOR_SERVICE_ID FROM [ORDER] WHERE ORDER_STATUS_ID IN(1,2,4) AND DATEADD(HOUR,3,[REQUESTED_DATE]) >= GetDate())	
END

GO

ALTER PROCEDURE [dbo].[usp_GetRecentOrder]
(
	@pCustomerId binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT TOP 1 ORD.ORDER_ID, Cust.CUSTOMER_ID, CUST.NAME AS CUSTOMER_NAME, VS.VENDOR_SERVICE_ID, VEN.VENDOR_ID ,VEN.NAME AS VENDOR_NAME, 
  SVCS.SERVICE_ID AS SERVICE_ID,SVCS.NAME AS SERVICE_NAME , OS.ORDER_STATUS_ID, OS.NAME AS ORDERSTATUS_NAME,
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION, ORD.SOURCE_ADDRESS_ID, ORD.DESTINATION_ADDRESS_ID,ORD.COMMENTS
  FROM dbo.[ORDER] ORD
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR VEN ON VS.VENDOR_ID= VEN.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID   
WHERE ORD.CUSTOMER_ID = @pCustomerId AND ORD.ORDER_STATUS_ID = 5 ORDER BY ORD.REQUESTED_DATE DESC

---- Source Address
 SELECT TOP 1 Address_ID,ADDRESS_TYPE, COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[SOURCE_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORD.CUSTOMER_ID = @pCustomerId AND ORD.ORDER_STATUS_ID = 5 ORDER BY ORD.REQUESTED_DATE DESC

 ---- Destination Address
 SELECT TOP 1 Address_ID, ADDRESS_TYPE, COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[DESTINATION_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORD.CUSTOMER_ID = @pCustomerId AND ORD.ORDER_STATUS_ID = 5 ORDER BY ORD.REQUESTED_DATE DESC
END

