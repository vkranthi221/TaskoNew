
ALTER PROCEDURE [dbo].[usp_AddService]
(
  @pName nvarchar(max),
  @pImageUrl nvarchar(max),
  @pParentServiceId Binary(16) = null,
  @pStatus int
)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @IsServiceAlreadyExist bit

IF NOT EXISTS (SELECT NAME from [dbo].[SERVICES] WHERE NAME = @pName)
 BEGIN
   INSERT INTO [dbo].[SERVICES] VALUES (NEWID(), @pName, @pParentServiceId, @pImageUrl, @pStatus)
   SET @IsServiceAlreadyExist =0
 END
 ELSE
 BEGIN
   SET @IsServiceAlreadyExist =1
 END

 SELECT @IsServiceAlreadyExist
END

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
	@pFacebookUrl nvarchar(max),
	@pIsVendorVerified bit
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
						FACEBOOK_URL = COALESCE(@pFacebookUrl, FACEBOOK_URL),
						IS_VENDOR_VERIFIED = COALESCE(@pIsVendorVerified, IS_VENDOR_VERIFIED)
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
	  ,IS_VENDOR_VERIFIED
   FROM [dbo].[VENDOR] VD (NOLOCK)
   INNER JOIN ADDRESS AD ON VD.ADDRESS_ID = AD.Address_ID
   WHERE VENDOR_ID = @pVendorId 
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
	@pFacebookUrl nvarchar(max),
	@pIsVendorVerified bit
	
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
						FACEBOOK_URL = COALESCE(@pFacebookUrl, FACEBOOK_URL),
						IS_VENDOR_VERIFIED = COALESCE(@pIsVendorVerified, IS_VENDOR_VERIFIED)
WHERE VENDOR_ID = @pVendorId

END

GO