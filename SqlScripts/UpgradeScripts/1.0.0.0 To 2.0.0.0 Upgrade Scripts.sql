---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_IsVendorExists]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_IsVendorExists] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_IsVendorExists]
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

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateVendorRating]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_UpdateVendorRating] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_UpdateVendorRating]
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

GO
ALTER PROCEDURE [dbo].[usp_GetVendorOrders]
(
      @pVENDORID BINARY(16) = NULL,
      @pORDERSTATUSID INT,
	  @pPAGENO INT,
	  @pRECORDSPERPAGE INT
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @VSQL NVARCHAR(MAX)
    
IF @pVENDORID IS NOT NULL   
SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME, ORD.COMMENTS, VS.VENDOR_ID
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
  WHERE VS.VENDOR_ID = @VVENDORID '
  ELSE
  SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME, VD.NAME AS VENDOR_NAME, 
  CUST.NAME AS CUSTOMER_NAME, VD.VENDOR_ID, CUST.CUSTOMER_ID
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID
  INNER JOIN VENDOR VD ON VD.VENDOR_ID = VS.VENDOR_ID
  INNER JOIN CUSTOMER CUST ON CUST.CUSTOMER_ID= ORD.CUSTOMER_ID'

IF(@PORDERSTATUSID<>0)
      SET @VSQL = @VSQL + ' AND ORD.ORDER_STATUS_ID = @vORDERSTATUSID '

IF(@pPAGENO<>0)
	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID DESC OFFSET (@vPAGENO-1)*@vRECORDSPERPAGE ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vVENDORID BINARY(16),@vORDERSTATUSID INT, @vPAGENO INT, @vRECORDSPERPAGE INT', @pVENDORID, @pORDERSTATUSID, @pPAGENO, @pRECORDSPERPAGE

END


GO

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
  CUST.MOBILE_NUMBER AS CUSTOMER_MOBILE_NUMBER, VEN.MOBILE_NUMBER AS VENDOR_MOBILE_NUMBER, ORD.CUSTOMER_DISTANCE, ORD.CUSTOMER_ETA, ORD.VISITING_FEE
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

GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DOCUMENT_TYPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DOCUMENT_TYPE](
	[DOCUMENT_TYPE_ID] [int] IDENTITY(0,1) NOT NULL,
	[DOCUMENT_TYPE_NAME] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DOCUMENT_TYPE] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('None')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Aadhar Card')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Driving License')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Voter ID')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Passport')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Bank Passbook')
INSERT INTO [dbo].[DOCUMENT_TYPE] VALUES('Pan Card')

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VENDOR_DOCUMENTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VENDOR_DOCUMENTS](
	[VENDOR_DOCUMENT_ID] [binary](16) NOT NULL,
	[VENDOR_ID] [binary](16) NOT NULL,
	[PHOTOIDPROOF_DOCUMENT_TYPE_ID] [int] ,
	[PHOTOIDPROOF_DOCUMENT_NUMBER] [nvarchar](max) NULL,
	[ADDRESSPROOF_DOCUMENT_TYPE_ID] [int] ,
	[ADDRESSPROOF_DOCUMENT_NUMBER] [nvarchar](max) NULL,
	[PENDING_DOCUMENT_TYPE_ID] [int] ,
	[PASSPORT_SIZE_PHOTO] [bit] NOT NULL,
	[REGISTRATION_FEE_PAID] [bit] NOT NULL,
	[BACKGROUND_VERIFICATION_INITIATED] [bit] NOT NULL,
 CONSTRAINT [PK_VENDOR_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[VENDOR_DOCUMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[VENDOR_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_DOCUMENTS_VENDOR] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])

ALTER TABLE [dbo].[VENDOR_DOCUMENTS] CHECK CONSTRAINT [FK_VENDOR_DOCUMENTS_VENDOR]

END

GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertUpdateVendorDocuments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_InsertUpdateVendorDocuments] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_InsertUpdateVendorDocuments] 
 @pVendorId binary(16)
,@pPhotoDocTypeId int 
,@pPhotoDocTypeNumber nvarchar(max) null
,@pAddressProofDocTypeId int 
,@pAddressProofDocTypeNumber nvarchar(max) null
,@pPendingDocTypeId int 
,@pIsPassportSizePhoto bit
,@pIsRegistrationFeePaid bit
,@pIsBkgrndChkInitiated bit
AS
BEGIN
IF EXISTS (SELECT VENDOR_DOCUMENT_ID FROM VENDOR_DOCUMENTS WHERE VENDOR_ID = @pVendorId)
  BEGIN
        UPDATE [dbo].VENDOR_DOCUMENTS SET PHOTOIDPROOF_DOCUMENT_TYPE_ID = COALESCE(@pPhotoDocTypeId, PHOTOIDPROOF_DOCUMENT_TYPE_ID)
						,PHOTOIDPROOF_DOCUMENT_NUMBER = COALESCE(@pPhotoDocTypeNumber,PHOTOIDPROOF_DOCUMENT_NUMBER)
						,ADDRESSPROOF_DOCUMENT_TYPE_ID = COALESCE(@pAddressProofDocTypeId,ADDRESSPROOF_DOCUMENT_TYPE_ID)
						,ADDRESSPROOF_DOCUMENT_NUMBER = COALESCE(@pAddressProofDocTypeNumber, ADDRESSPROOF_DOCUMENT_NUMBER)
						,PENDING_DOCUMENT_TYPE_ID = COALESCE(@pPendingDocTypeId, PENDING_DOCUMENT_TYPE_ID)
						,PASSPORT_SIZE_PHOTO = @pIsPassportSizePhoto
						,REGISTRATION_FEE_PAID = @pIsRegistrationFeePaid
						,BACKGROUND_VERIFICATION_INITIATED = @pIsBkgrndChkInitiated					
         WHERE VENDOR_ID = @pVendorId
   END
ELSE
BEGIN
	   INSERT INTO VENDOR_DOCUMENTS 
	   VALUES (NEWID(), @pVendorId, @pPhotoDocTypeId, @pPhotoDocTypeNumber, @pAddressProofDocTypeId, @pAddressProofDocTypeNumber, 
	   @pPendingDocTypeId, @pIsPassportSizePhoto, @pIsRegistrationFeePaid, @pIsBkgrndChkInitiated) 
	END
END

GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetVendorDocuments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetVendorDocuments] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_GetVendorDocuments]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT VD.[VENDOR_ID], V.[NAME] AS [VENDOR_NAME], [VENDOR_DOCUMENT_ID], [PHOTOIDPROOF_DOCUMENT_TYPE_ID], [PHOTOIDPROOF_DOCUMENT_NUMBER],
[ADDRESSPROOF_DOCUMENT_TYPE_ID], [ADDRESSPROOF_DOCUMENT_NUMBER], [PENDING_DOCUMENT_TYPE_ID], [PASSPORT_SIZE_PHOTO],
[REGISTRATION_FEE_PAID], [BACKGROUND_VERIFICATION_INITIATED]
  FROM VENDOR_DOCUMENTS VD
  INNER JOIN dbo.VENDOR V ON V.VENDOR_ID = VD.VENDOR_ID   
WHERE VD.VENDOR_ID = @pVendorId 

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAllPendingOrders]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetAllPendingOrders] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_GetAllPendingOrders]
AS
BEGIN

SET NOCOUNT ON;
  SELECT ORD.ORDER_ID FROM dbo.[ORDER] ORD  
  WHERE REQUESTED_DATE <=DATEADD(MINUTE, -2, CURRENT_TIMESTAMP) AND ORD.ORDER_STATUS_ID = 1  
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ResetAllLogins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_ResetAllLogins] AS' 
END
GO

ALTER PROCEDURE [dbo].[usp_ResetAllLogins]
AS
BEGIN

SET NOCOUNT ON;
  UPDATE ADDRESS SET LATITIUDE = '0', LONGITUDE = '0' WHERE ADDRESS_ID != 0xFC32A83A7791074B8072B68B652088E6
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DB_VERSION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DB_VERSION](
	[VERSION] [nvarchar](50) NOT NULL,
	[UPDATED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_DB_VERSION] PRIMARY KEY CLUSTERED 
(
	[VERSION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

GO

IF NOT EXISTS (SELECT * FROM [dbo].[DB_VERSION] WHERE [VERSION] = '2.0.0.0')
BEGIN
     INSERT INTO [dbo].[DB_VERSION] values('2.0.0.0', Getdate())
END
GO