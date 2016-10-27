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
	@pIsVendorVerified bit,
	@pNoOfEmployees int,	
    @pVendorAlsoKnownAs nvarchar(50),
    @pExperience nvarchar(50),
	@pBaseRate decimal
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
						IS_VENDOR_VERIFIED = COALESCE(@pIsVendorVerified, IS_VENDOR_VERIFIED),
						[VENDOR_ALSO_KNOWN_AS]= COALESCE(@pVendorAlsoKnownAs, VENDOR_ALSO_KNOWN_AS),
						[EXPERIENCE]= COALESCE(@pExperience, EXPERIENCE),
						[BASE_RATE]= COALESCE(@pBaseRate, BASE_RATE),
						[EMPLOYEE_COUNT]= COALESCE(@pNoOfEmployees, EMPLOYEE_COUNT)
WHERE VENDOR_ID = @pVendorId

END
GO
