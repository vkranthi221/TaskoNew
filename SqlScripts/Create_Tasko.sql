----------------------------------------------------------------------------------------------------------
--------------------------- All Copy Rights are reserved to Tasko.in--------------------------------------
USE [Tasko]
GO
----------------------------------------------------------------------------------------------------------

GO
CREATE TABLE [dbo].[SERVICES]( 
	[SERVICE_ID] Binary (16) NOT NULL ,
	[NAME] VARCHAR(MAX) NOT NULL,
	[PARENT_SERVICE_ID] Binary (16) NULL ,
	[IMAGE_URL] VARCHAR(MAX) NULL,
    CONSTRAINT [SERVICES_PK] PRIMARY KEY CLUSTERED(SERVICE_ID))
GO

/****** Object:  ForeignKey [FK_ParentService]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[SERVICES]  WITH CHECK ADD  CONSTRAINT [PARENT_SERVICE_ID_FK] FOREIGN KEY([PARENT_SERVICE_ID])
REFERENCES [dbo].[SERVICES] ([SERVICE_ID])
GO
ALTER TABLE [dbo].[SERVICES] CHECK CONSTRAINT [PARENT_SERVICE_ID_FK]
GO

CREATE TABLE [dbo].[LOGGEDON_USER](
	[USER_ID] [binary](16) NOT NULL,
	[AUTH_CODE] [binary](16) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Auth_Code](
	[code] [binary](16) NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ADDRESS](
	[Address_ID] [binary](16) NOT NULL,
	[COUNTRY] [nvarchar](max) NULL,
	[STATE] [nvarchar](max) NULL,
	[LATITIUDE] [nvarchar](max) NULL,
	[LONGITUDE] [nvarchar](max) NULL,
	[LOCALITY] [nvarchar](max) NULL,
	[CITY] [nvarchar](max) NULL,
	[ADDRESS] [nvarchar](max) NULL,
	[PINCODE] [nvarchar](max) NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED ([Address_ID]))

GO

CREATE TABLE [dbo].[ORDER_STATUS](
	[ORDER_STATUS_ID] int NOT NULL,
	[NAME] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [ORDER_STATUS_PK] PRIMARY KEY CLUSTERED(ORDER_STATUS_ID))
GO
    
CREATE TABLE [dbo].[ISSUES](
	[ISSUE_ID] Binary(16) NOT NULL,
	[NAME] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [ISSUES_PK] PRIMARY KEY CLUSTERED(ISSUE_ID))
GO

CREATE TABLE [dbo].[ID_PROOFS](
	[ID_PROOF_ID] Binary(16) NOT NULL,
	[NAME] VARCHAR(MAX) NOT NULL,
 CONSTRAINT [ID_PROOFS_PK] PRIMARY KEY CLUSTERED(ID_PROOF_ID))

GO

--For now I removed the VendorId column as i dont see any use case
CREATE TABLE [dbo].[VENDOR](
	[VENDOR_ID] Binary (16) NOT NULL ,
	[NAME] VARCHAR(MAX) NOT NULL,
	[MOBILE_NUMBER] [varchar](50) NOT NULL,
	[PASSWORD] VARCHAR(MAX) NOT NULL,
	[EMAIL_ADDRESS] VARCHAR(max) NULL,
	[ADDRESS] VARCHAR(MAX) NOT NULL,
	[PHOTO] [image] NULL,
	[EMPLOYEE_COUNT] int NOT NULL,
	[BASE_RATE] decimal(18, 0) NOT NULL,
	[IS_VENDOR_VERIFIED] bit NOT NULL,
	[IS_VENDOR_LIVE] bit NOT NULL,
	[TIME_SPENT_ON_APP] time(7) NOT NULL,
	[ACTIVE_TIME_PER_DAY] time(7) NOT NULL,
	[DATA_CONSUMPTION] decimal(18, 0) NOT NULL,
	[CALLS_TO_CUSTOMER_CARE] int NOT NULL,
    CONSTRAINT [VENDOR_PK] PRIMARY KEY CLUSTERED(VENDOR_ID))
GO

CREATE TABLE [dbo].[VENDOR_SERVICES](
	[VENDOR_SERVICE_ID] Binary(16) NOT NULL,
	[VENDOR_ID] Binary(16) NOT NULL,
	[SERVICE_ID] Binary(16) NOT NULL,
	[IS_VENDOR_SERVICE_ACTIVE] bit NOT NULL,
    CONSTRAINT [VENDOR_SERVICES_PK] PRIMARY KEY CLUSTERED(VENDOR_SERVICE_ID))   
GO

/****** Object:  ForeignKey [VENDOR_SERVICES_SERVICES_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_SERVICES]  WITH CHECK ADD  CONSTRAINT [VENDOR_SERVICES_SERVICES_FK] FOREIGN KEY([SERVICE_ID])
REFERENCES [dbo].[SERVICES] ([SERVICE_ID])
GO
ALTER TABLE [dbo].[VENDOR_SERVICES] CHECK CONSTRAINT [VENDOR_SERVICES_SERVICES_FK]
GO

/****** Object:  ForeignKey [VENDOR_SERVICES_VENDOR_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_SERVICES]  WITH CHECK ADD  CONSTRAINT [VENDOR_SERVICES_VENDOR_FK] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO
ALTER TABLE [dbo].[VENDOR_SERVICES] CHECK CONSTRAINT [VENDOR_SERVICES_VENDOR_FK]
GO

CREATE TABLE [dbo].[VENDOR_PROOF](
	[VENDOR_PROOF_ID] Binary(16) NOT NULL,
	[VENDOR_ID] Binary(16) NOT NULL,
	[ID_PROOF_ID] Binary(16) NOT NULL,
	[PROOF] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [VENDOR_PROOF_PK] PRIMARY KEY CLUSTERED(VENDOR_PROOF_ID))
GO

/****** Object:  ForeignKey [VENDOR_PROOF_ID_PROOFS_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_PROOF]  WITH CHECK ADD  CONSTRAINT [VENDOR_PROOF_ID_PROOFS_FK] FOREIGN KEY([ID_PROOF_ID])
REFERENCES [dbo].[ID_PROOFS] ([ID_PROOF_ID])
GO
ALTER TABLE [dbo].[VENDOR_PROOF] CHECK CONSTRAINT [VENDOR_PROOF_ID_PROOFS_FK]
GO

/****** Object:  ForeignKey [VENDOR_PROOF_VENDOR_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_PROOF]  WITH CHECK ADD  CONSTRAINT [VENDOR_PROOF_VENDOR_FK] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO
ALTER TABLE [dbo].[VENDOR_PROOF] CHECK CONSTRAINT [VENDOR_PROOF_VENDOR_FK]
GO

CREATE TABLE [dbo].[VENDOR_ISSUES](
	[VENDOR_ISSUE_ID] Binary(16) NOT NULL,
	[VENDOR_ID] Binary(16) NOT NULL,
	[CUSTOMER_ID] Binary(16) NOT NULL,
	[ISSUE_ID] Binary(16) NOT NULL,
	[COMMENTS] VARCHAR(MAX) NULL,
    CONSTRAINT [VENDOR_ISSUES_PK] PRIMARY KEY CLUSTERED(VENDOR_ISSUE_ID))
GO

/****** Object:  ForeignKey [VENDOR_ISSUES_ISSUES_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_ISSUES]  WITH CHECK ADD  CONSTRAINT [VENDOR_ISSUES_ISSUES_FK] FOREIGN KEY([ISSUE_ID])
REFERENCES [dbo].[ISSUES] ([ISSUE_ID])
GO
ALTER TABLE [dbo].[VENDOR_ISSUES] CHECK CONSTRAINT [VENDOR_ISSUES_ISSUES_FK]
GO

/****** Object:  ForeignKey [VENDOR_ISSUES_VENDOR_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_ISSUES]  WITH CHECK ADD  CONSTRAINT [VENDOR_ISSUES_VENDOR_FK] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO
ALTER TABLE [dbo].[VENDOR_ISSUES] CHECK CONSTRAINT [VENDOR_ISSUES_VENDOR_FK]
GO

CREATE TABLE [dbo].[CUSTOMER](
	[CUSTOMER_ID] Binary(16) NOT NULL,
	[NAME] VARCHAR(MAX) NOT NULL,
	[EMAIL_ADDRESS] VARCHAR(MAX) NOT NULL,
	[MOBILE_NUMBER] VARCHAR(MAX) NOT NULL,
 CONSTRAINT [CUSTOMER_PK] PRIMARY KEY CLUSTERED(CUSTOMER_ID))
 
GO

CREATE TABLE [dbo].[ORDER](
	[ORDER_ID] [varchar](50) NOT NULL,
	[VENDOR_SERVICE_ID] [binary](16) NOT NULL,
	[CUSTOMER_ID] [binary](16) NOT NULL,
	[REQUESTED_DATE] [datetime] NOT NULL,
	[ORDER_STATUS_ID] [int] NOT NULL,
	[ORDER_LOCATION] [varchar](max) NULL,
	[SOURCE_ADDRESS_ID] [binary](16) NOT NULL,
	[DESTINATION_ADDRESS_ID] [binary](16) NOT NULL,
	[COMMENTS] nVarchar(max) NULL
 CONSTRAINT [ORDER_PK] PRIMARY KEY CLUSTERED ([ORDER_ID] ASC))

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [FK_ORDER_ADDRESS] FOREIGN KEY([SOURCE_ADDRESS_ID])
REFERENCES [dbo].[ADDRESS] ([Address_ID])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [FK_ORDER_ADDRESS]
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [FK_ORDER_ADDRESS1] FOREIGN KEY([DESTINATION_ADDRESS_ID])
REFERENCES [dbo].[ADDRESS] ([Address_ID])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [FK_ORDER_ADDRESS1]
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [ORDER_CUSTOMER_FK] FOREIGN KEY([CUSTOMER_ID])
REFERENCES [dbo].[CUSTOMER] ([CUSTOMER_ID])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [ORDER_CUSTOMER_FK]
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [ORDER_ORDER_STATUS_FK] FOREIGN KEY([ORDER_STATUS_ID])
REFERENCES [dbo].[ORDER_STATUS] ([ORDER_STATUS_ID])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [ORDER_ORDER_STATUS_FK]
GO

ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [ORDER_VENDOR_SERVICES_FK] FOREIGN KEY([VENDOR_SERVICE_ID])
REFERENCES [dbo].[VENDOR_SERVICES] ([VENDOR_SERVICE_ID])
GO

ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [ORDER_VENDOR_SERVICES_FK]
GO

CREATE TABLE [dbo].[VENDOR_RATING](
	[VENDOR_RATING_ID] Binary(16) NOT NULL,
	[SERVICE_QUALITY] decimal(18, 2) NOT NULL,
	[PUNCTUALITY] decimal(18, 2) NOT NULL,
	[COURTESY] decimal(18, 2) NOT NULL,
	[PRICE] decimal(18, 2) NOT NULL,
	[REVIEW_DATE] datetime NOT NULL,
	[COMMENTS] VARCHAR(MAX) NULL,
	[ORDER_ID] VARCHAR(50) NOT NULL,
	[VENDOR_ID] Binary(16) NOT NULL,
	[CUSTOMER_ID] Binary(16) NOT NULL
    CONSTRAINT [VENDOR_RATING_PK] PRIMARY KEY CLUSTERED(VENDOR_RATING_ID))
GO

/****** Object:  ForeignKey [VENDOR_RATING_ORDER_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[VENDOR_RATING]  WITH CHECK ADD  CONSTRAINT [VENDOR_RATING_ORDER_FK] FOREIGN KEY([ORDER_ID])
REFERENCES [dbo].[ORDER] ([ORDER_ID])
GO
ALTER TABLE [dbo].[VENDOR_RATING] CHECK CONSTRAINT [VENDOR_RATING_ORDER_FK]
GO

CREATE TABLE [dbo].[CUSTOMER_RATING](
	[CUSTOMER_RATING_ID] Binary(16) NOT NULL,
	[ORDER_ID] VARCHAR(50) NOT NULL,
	[RATING] decimal(18, 2) NOT NULL,
	[COMMENTS] VARCHAR(MAX) NULL,
 CONSTRAINT [CUSTOMER_RATING_PK] PRIMARY KEY CLUSTERED(CUSTOMER_RATING_ID))

GO

/****** Object:  ForeignKey [CUSTOMER_RATING_ORDER_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[CUSTOMER_RATING]  WITH CHECK ADD  CONSTRAINT [CUSTOMER_RATING_ORDER_FK] FOREIGN KEY([ORDER_ID])
REFERENCES [dbo].[ORDER] ([ORDER_ID])
GO
ALTER TABLE [dbo].[CUSTOMER_RATING] CHECK CONSTRAINT [CUSTOMER_RATING_ORDER_FK]
GO

CREATE TABLE [dbo].[CUSTOMER_ADDRESS](
	[ID] [binary](16) NOT NULL,
	[CUSTOMER_ID] [binary](16) NOT NULL,
	[ADDRESS_ID] [binary](16) NOT NULL,
 CONSTRAINT [PK_CUSTOMER_ADDRESS] PRIMARY KEY CLUSTERED([ID] ASC))

GO
/*********** Functions **************************/
CREATE FUNCTION dbo.GenerateOrderID()
RETURNS VARCHAR(MAX) 
AS 
-- Returns the New Order ID
BEGIN
    DECLARE @ORDER_ID VARCHAR(MAX);
    DECLARE @START_INDEX_ORDER_ID int;
    SET @START_INDEX_ORDER_ID = 1000;
    DECLARE @ORDER_COUNT int;
    
    SELECT @ORDER_COUNT = Count(*) FROM dbo.[ORDER]
    
    IF(@ORDER_COUNT > 0)
      BEGIN
         SET @ORDER_ID = 'TASKO' + CONVERT(varchar, @START_INDEX_ORDER_ID + @ORDER_COUNT)
      END
    ELSE 
      BEGIN
         SET @ORDER_ID = 'TASKO' + CONVERT(varchar, @START_INDEX_ORDER_ID)
      END 
      
    RETURN @ORDER_ID;
END;

GO
CREATE FUNCTION [dbo].[GetVendorTotalRating](
@pVendorId Binary(16)
)
RETURNS DECIMAL 
AS 
-- Returns the New Order ID
BEGIN
   DECLARE @OVERALL_RATING DECIMAL;
        
SELECT @OVERALL_RATING = ROUND(((SUM(SERVICE_QUALITY)+ SUM(PUNCTUALITY)+SUM(COURTESY)+SUM(PRICE))/count(*))/4,0)
  FROM VENDOR_RATING   
  WHERE VENDOR_ID = @pVENDORID
      
    RETURN @OVERALL_RATING;
END;

GO

CREATE TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR](
	[FAVORITE_ID] [binary](16) NOT NULL,
	[VENDOR_ID] [binary](16) NOT NULL,
	[CUSTOMER_ID] [binary](16) NOT NULL,
 CONSTRAINT [PK_Customer_Favorite_Vendor] PRIMARY KEY CLUSTERED 
(
	[FAVORITE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[OTP_DETAILS](
	[PHONE_NUMBER] [nvarchar](50) NOT NULL,
	[EMAIL_ID] [nvarchar](50) NULL,
	[OTP] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OTP_DETAILS] PRIMARY KEY CLUSTERED 
(
	[PHONE_NUMBER] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Favorite_Vendor_CUSTOMER] FOREIGN KEY([CUSTOMER_ID])
REFERENCES [dbo].[CUSTOMER] ([CUSTOMER_ID])
GO

ALTER TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR] CHECK CONSTRAINT [FK_Customer_Favorite_Vendor_CUSTOMER]
GO

ALTER TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Favorite_Vendor_VENDOR] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO

ALTER TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR] CHECK CONSTRAINT [FK_Customer_Favorite_Vendor_VENDOR]
GO

/*********** Stored Procedures **************************/
GO
CREATE PROCEDURE [dbo].[usp_GetVendorDetails]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT [VENDOR_ID]
      ,[NAME]
      ,[MOBILE_NUMBER]
      ,[EMAIL_ADDRESS]
      ,[ADDRESS]
      ,[PHOTO]
      ,[EMPLOYEE_COUNT]
      ,[BASE_RATE]
      ,[IS_VENDOR_VERIFIED]
      ,[IS_VENDOR_LIVE]
      ,[TIME_SPENT_ON_APP]
      ,[ACTIVE_TIME_PER_DAY]
      ,[DATA_CONSUMPTION]
      ,[CALLS_TO_CUSTOMER_CARE]
FROM [dbo].[VENDOR] (NOLOCK)
WHERE VENDOR_ID = @pVendorId 

END
GO
CREATE PROCEDURE [dbo].[usp_GetOrderDetails]
(
	@pOrderId Varchar(50)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT ORD.ORDER_ID, Cust.CUSTOMER_ID, CUST.NAME AS CUSTOMER_NAME, VS.VENDOR_SERVICE_ID, VEN.VENDOR_ID ,VEN.NAME AS VENDOR_NAME, 
  SVCS.SERVICE_ID AS SERVICE_ID,SVCS.NAME AS SERVICE_NAME , OS.ORDER_STATUS_ID, OS.NAME AS ORDERSTATUS_NAME,
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION ,ORD.SOURCE_ADDRESS_ID, ORD.DESTINATION_ADDRESS_ID,ORD.COMMENTS
  FROM dbo.[ORDER] ORD
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR VEN ON VS.VENDOR_ID= VEN.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID   
WHERE ORDER_ID = @pOrderId 

---- Source Address
 SELECT [Address_ID],[COUNTRY],[STATE],[LATITIUDE] ,[LONGITUDE] ,[LOCALITY],[CITY],[ADDRESS],[PINCODE]
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[SOURCE_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORDER_ID = @pOrderId 

 ---- Destination Address
 SELECT [Address_ID],[COUNTRY],[STATE],[LATITIUDE] ,[LONGITUDE] ,[LOCALITY],[CITY],[ADDRESS],[PINCODE]
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.[ORDER] ORD ON ORD.[DESTINATION_ADDRESS_ID] = Addr.[Address_ID]
 WHERE ORDER_ID = @pOrderId 
END
GO
CREATE PROCEDURE [dbo].[usp_GetVendorServices]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT VS.VENDOR_SERVICE_ID, SVCS.NAME AS SERVICE_NAME, IS_VENDOR_SERVICE_ACTIVE, SVCS.IMAGE_URL
  FROM VENDOR_SERVICES VS 
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID   
WHERE VENDOR_ID = @pVendorId AND SVCS.PARENT_SERVICE_ID IS NULL

END

GO
CREATE PROCEDURE [dbo].[usp_GetVendorSubServices]
(
	@pVendorServiceId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT VS.VENDOR_SERVICE_ID, SVCS.NAME AS SERVICE_NAME, IS_VENDOR_SERVICE_ACTIVE, SVCS.IMAGE_URL
  FROM VENDOR_SERVICES VS 
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID   
WHERE VS.SERVICE_ID IN(SELECT SERVICE_ID FROM SERVICES 
WHERE PARENT_SERVICE_ID = (SELECT SERVICE_ID FROM VENDOR_SERVICES WHERE VENDOR_SERVICE_ID = @pVendorServiceId))

END

GO
CREATE PROCEDURE [dbo].[usp_UpdateOrderStatus]
(
	@pOrderId varchar(50),
	@pOrderStatus int,
	@pComments nvarchar(max)
)
AS
BEGIN

DECLARE @err_message nvarchar(255)
SET NOCOUNT ON;

IF EXISTS (Select NAME from ORDER_STATUS WHERE ORDER_STATUS_ID = @pOrderStatus)
  BEGIN
        UPDATE [dbo].[ORDER]  SET ORDER_STATUS_ID = @pOrderStatus,COMMENTS =@pComments WHERE ORDER_ID = @pOrderId
  END
ELSE
BEGIN
	SET @err_message = 'Invalid Order status'
         RAISERROR (@err_message,10, 1) 	
	END

END

GO

CREATE FUNCTION [dbo].[CheckIsParentServiceId](
@pVendorServiceId Binary(16)
)
RETURNS bit 
AS 
-- Returns the New Order ID
BEGIN
    DECLARE @SERVICE_ID Binary(16); 
	DECLARE @ISPARENTSERVICE bit;   
	SELECT @SERVICE_ID = SERVICE_ID FROM VENDOR_SERVICES WHERE VENDOR_SERVICE_ID = @pVendorServiceId
	IF EXISTS(SELECT SERVICE_ID FROM dbo.[SERVICES] WHERE PARENT_SERVICE_ID = @SERVICE_ID)
	    BEGIN
		    -- The given vendor service id is a parent service.
	      SET @ISPARENTSERVICE = 1;
	    END
	ELSE
	    BEGIN
		  -- The given vendor service id is a Sub service.
	      SET @ISPARENTSERVICE = 0;
	    END

 RETURN @ISPARENTSERVICE;
END;

GO
CREATE PROCEDURE [dbo].[usp_UpdateVendorServices]
(
	@pVendorServiceId Binary(16),
	@pActivateService bit
)
AS
BEGIN

SET NOCOUNT ON;

IF(@pActivateService = 0)
  BEGIN
        IF(dbo.CheckIsParentServiceId(@pVendorServiceId) = 1)
			BEGIN
			 -- This is Parent Id so when Parent service is disabled then disable all the respective sub services as well.
			 -- First Disable Parent service
			  UPDATE VENDOR_SERVICES SET [IS_VENDOR_SERVICE_ACTIVE] = @pActivateService
              WHERE VENDOR_SERVICE_ID = @pVendorServiceId

			  DECLARE @VENDOR_ID Binary(16);
			  SELECT @VENDOR_ID = VENDOR_ID FROM VENDOR_SERVICES WHERE VENDOR_SERVICE_ID = @pVendorServiceId

			  DECLARE @PARENT_SERVICE_ID Binary(16);
			  SELECT @PARENT_SERVICE_ID = SERVICE_ID FROM VENDOR_SERVICES WHERE VENDOR_SERVICE_ID = @pVendorServiceId

			  --Disable SubServices
			  UPDATE VENDOR_SERVICES SET [IS_VENDOR_SERVICE_ACTIVE] = @pActivateService
              WHERE VENDOR_SERVICE_ID IN( SELECT VS.VENDOR_SERVICE_ID  FROM VENDOR_SERVICES VS 
              WHERE VS.SERVICE_ID IN(SELECT SERVICE_ID FROM SERVICES WHERE PARENT_SERVICE_ID = @PARENT_SERVICE_ID)
			  AND VS.VENDOR_ID = @VENDOR_ID)
			END
		ELSE
			BEGIN
			  UPDATE VENDOR_SERVICES SET [IS_VENDOR_SERVICE_ACTIVE] = @pActivateService
              WHERE VENDOR_SERVICE_ID = @pVendorServiceId 
			END
  END
ELSE
  BEGIN
       -- Enable Vendor Parent & Sub services individually.
       UPDATE VENDOR_SERVICES SET [IS_VENDOR_SERVICE_ACTIVE] = @pActivateService
       WHERE VENDOR_SERVICE_ID = @pVendorServiceId 
  END
END

GO
CREATE PROCEDURE [dbo].[usp_UpdateBaseRate]
(
	@pVendorId Binary(16),
	@pBaseRate decimal
)
AS
BEGIN

SET NOCOUNT ON;
  UPDATE [dbo].[VENDOR] SET BASE_RATE = @pBaseRate WHERE VENDOR_ID = @pVendorId
END

GO
CREATE PROCEDURE [dbo].[usp_GetVendorOrders]
(
      @pVENDORID BINARY(16),
      @pORDERSTATUSID INT,
	  @pPAGENO INT,
	  @pRECORDSPERPAGE INT
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE 
            @VSQL NVARCHAR(MAX)
            
SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME, ORD.COMMENTS
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
WHERE VS.VENDOR_ID = @vVENDORID '

IF(@PORDERSTATUSID<>0)
      SET @VSQL = @VSQL + ' AND ORD.ORDER_STATUS_ID = @vORDERSTATUSID '

	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID DESC OFFSET (@vPAGENO-1)*@vRECORDSPERPAGE ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vVENDORID BINARY(16),@vORDERSTATUSID INT, @vPAGENO INT, @vRECORDSPERPAGE INT', @pVENDORID, @pORDERSTATUSID, @pPAGENO, @pRECORDSPERPAGE

END

GO
CREATE PROCEDURE [dbo].[usp_GetVendorOverallRating]
(
    @pVENDORID BINARY(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT ROUND(SUM(VR.SERVICE_QUALITY)/count(*),0) AS QUALITY,ROUND(SUM(VR.PUNCTUALITY)/count(*),0) AS PUNCTUALITY, ROUND(SUM(VR.COURTESY)/count(*),0) AS COURTESY, ROUND(SUM(VR.PRICE)/count(*),0) AS PRICE, ROUND(((SUM(VR.SERVICE_QUALITY)+ SUM(VR.PUNCTUALITY)+SUM(VR.COURTESY)+SUM(VR.PRICE))/count(*))/4,0) AS TOTAL
  FROM VENDOR_RATING VR  
  WHERE VR.VENDOR_ID= @pVENDORID

END

GO

CREATE PROCEDURE [dbo].[usp_GetVendorRatings]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT TOP 25 VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY, VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME,
  ROUND(SUM(VR.SERVICE_QUALITY + VR.PUNCTUALITY + VR.COURTESY + VR.PRICE)/4,0) AS TOTAL
  FROM VENDOR_RATING VR
  INNER JOIN CUSTOMER CUST ON VR.CUSTOMER_ID = CUST.CUSTOMER_ID
  WHERE VR.VENDOR_ID= @pVendorId 
  GROUP BY VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY,VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME
  ORDER BY REVIEW_DATE DESC
END

GO

CREATE PROCEDURE [dbo].[usp_LOGIN]
(
	@pUserId Varchar(50),
	@pPassword nvarchar(10),
	@pMobileNumber varchar(50),
	@pUserType smallint

)
AS
BEGIN

SET NOCOUNT ON;
declare @AuthCode binary(16)

declare @UserID binary(16)
set @authCode = NEWID()
 if (@pUserType = 1)
 BEGIN
 IF @pUserId IS NOT NULL AND LEN(@pUserId) > 0 --username is passed
	BEGIN
		select @UserID= VENDOR_ID from vendor where NAME = @pUserId and PASSWORD = @pPassword
	END
 ELSE IF @pMobileNumber IS NOT NULL AND LEN(@pPassword) >0 
	BEGIN
		select @UserID= VENDOR_ID from vendor where MOBILE_NUMBER = @pMobileNumber and PASSWORD = @pPassword
	END
End 

if(@UserID is not null)
BEGIN
	insert into loggedon_user values(@UserID, @AuthCode)
END
SELECT @AuthCode as AUTH_CODE, @UserID as USERID
END

GO

CREATE PROCEDURE [dbo].[usp_Logout]
(
	@pUserId binary(16),
	@pAuthCode binary(16)
)
AS
BEGIN


SET NOCOUNT ON;

delete from Loggedon_user where user_id = @pUserId and AUTH_code = @pAuthCode
END

GO

CREATE PROCEDURE [dbo].[usp_InsertAuthCode]

AS
BEGIN

SET NOCOUNT ON;
declare @authcode binary(16)
set @authcode = newid()
Insert into auth_code values(@authcode) 
select @authcode as Auth_Code
END

GO
CREATE PROCEDURE [dbo].[usp_ValidateAuthCode]
(
@pAuthCode binary(16),
@pIsDeleteRequired bit
)
AS
BEGIN

SET NOCOUNT ON;
declare @count int
declare @isvalid bit
select @count = count(1) from Auth_Code where code = @pAuthCode
if(@count >0)
BEGIN
if(@pIsDeleteRequired = 1)
BEGIN
delete from Auth_Code where code = @pAuthCode
END
set @isvalid = 1
END
Else
begin 
	set @isvalid =0
end

select @isvalid as IsValid
End

GO

CREATE PROCEDURE [dbo].[usp_ValidateTokenCode]
(
@pTokenCode binary(16),
@pUserId binary(16)
)
AS
BEGIN

SET NOCOUNT ON;
declare @count int
declare @isvalid bit
select @count = count(1) from LOGGEDON_USER where USER_ID = @pUserId and AUTH_CODE = @pTokenCode

if(@count >0)
BEGIN
set @isvalid = 1
END
Else
begin 
	set @isvalid =0
end

select @isvalid as IsValid
End
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
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION, ORD.SOURCE_ADDRESS_ID, ORD.DESTINATION_ADDRESS_ID,ORD.COMMENTS
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
  @pServiceId binary(16),
  @pCustomerId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;
	SELECT SVC.SERVICE_ID ,SVC.NAME AS SERVICE_NAME, V.VENDOR_ID, V.NAME AS VENDOR_NAME,VENDOR_SERVICE_ID, V.BASE_RATE, CV.FAVORITE_ID,
	(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_REVIEWS, dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS
	FROM [dbo].[SERVICES] SVC
	INNER JOIN [dbo].[VENDOR_SERVICES] VS ON VS.SERVICE_ID = SVC.SERVICE_ID
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = VS.VENDOR_ID
	LEFT OUTER JOIN [dbo].[CUSTOMER_FAVORITE_VENDOR] CV ON CV.CUSTOMER_ID = @pCustomerId AND CV.VENDOR_ID = V.VENDOR_ID
	WHERE SVC.SERVICE_ID = @pServiceId AND VS.IS_VENDOR_SERVICE_ACTIVE = 1
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

  INSERT INTO [dbo].[ORDER] VALUES(@OrderId,@pVendorServiceId,@pCustomerId,GetDate(),1,'',@pSourceAddressId,@pDestinationAddressId,null)

  SELECT @OrderId as ORDER_ID
END

GO
CREATE PROCEDURE [dbo].[usp_AddCustomerAddress]
(
  @pCustomerId binary(16), 
  @pAddressId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

  INSERT INTO [dbo].CUSTOMER_ADDRESS VALUES(newid(),@pCustomerId,@pAddressId)
END

GO

CREATE PROCEDURE [dbo].[usp_UpdateCustomerAddress]
(
  @pAddressId binary(16),  
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

  UPDATE [dbo].[ADDRESS] SET COUNTRY = @pCountry, STATE= @pState, LATITIUDE = @pLatitude, 
                         LONGITUDE = @pLongitude,LOCALITY = @pLocality,CITY = @pCity,
                         [ADDRESS]=@pAddress,PINCODE = @Pincode
  WHERE Address_ID = @pAddressId

  SELECT @AddressId as ADDRESS_ID
END


GO

CREATE PROCEDURE [dbo].[usp_DeleteCustomerAddress]
(
  @pCustomerId binary(16),
  @pAddressId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;
 
 DELETE dbo.CUSTOMER_ADDRESS WHERE CUSTOMER_ID = @pCustomerId AND ADDRESS_ID = @pAddressId
 
 DELETE dbo.[ADDRESS] WHERE ADDRESS_ID = @pAddressId
END

GO

CREATE PROCEDURE [dbo].[usp_GetCustomerAddresses]
(
  @pCustomerId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

 SELECT Addr.Address_ID,COUNTRY,STATE,LATITIUDE ,LONGITUDE ,LOCALITY,CITY,ADDRESS,PINCODE
 FROM dbo.[ADDRESS] Addr
 INNER JOIN dbo.CUSTOMER_ADDRESS CA ON CA.[ADDRESS_ID] = Addr.[Address_ID]
 WHERE CA.CUSTOMER_ID = @pCustomerId 
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

CREATE PROCEDURE [dbo].[usp_GetCustomerOrders]
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

	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID OFFSET (@vPAGENO-1)*@vrecordsperpage ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vCustomerId binary(16),@vOrderstatusId int, @vPAGENO INT, @vRECORDSPERPAGE INT', @pCustomerId, @pOrderstatusId, @pPageNo, @pRecordsPerPage

END
GO

CREATE PROCEDURE [dbo].[usp_UpdateCustomer]
(
  @pCustomerId binary(16),
  @pName nvarchar(max),
  @pEmailAddress nvarchar(max),
  @pMobileNumber nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

  UPDATE [dbo].[CUSTOMER] SET NAME = @pName, EMAIL_ADDRESS = @pEmailAddress, MOBILE_NUMBER = @pMobileNumber
  WHERE CUSTOMER_ID = @pCustomerId 

END

GO
CREATE PROCEDURE [dbo].[usp_AddVendorRating]
(
  @pOrderId varchar(50),
  @pCustomerId binary(16),
  @pVendorId binary(16),
  @pServiceQuality decimal(18,2),
  @pPunctuality decimal(18,2),
  @pCourtesy decimal(18,2),
  @pPrice decimal(18,2),
  @pComments nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

  INSERT INTO [dbo].[VENDOR_RATING] VALUES(NewId(),@pServiceQuality,@pPunctuality,@pCourtesy,@pPrice,Getdate(),@pComments,@pOrderId,@pVendorId,@pCustomerId)

END

GO
CREATE PROCEDURE [dbo].[usp_ChangePassword]
(
	@pVendorId binary(16),
	@pPassword nvarchar(max),
	@pOldPassword nvarchar(max)
)
AS
BEGIN

DECLARE @IsOldPasswordCorrect bit
SET NOCOUNT ON;

IF EXISTS (SELECT VENDOR_ID from [dbo].[VENDOR] WHERE VENDOR_ID = @pVendorId AND PASSWORD = @pOldPassword)
  BEGIN
     UPDATE [dbo].[VENDOR]  SET PASSWORD = @pPassword WHERE VENDOR_ID = @pVendorId
	 SET @IsOldPasswordCorrect =1
  END
ELSE
BEGIN
  SET @IsOldPasswordCorrect = 0
  END
   
 SELECT @IsOldPasswordCorrect 
END
GO

CREATE PROCEDURE [dbo].[usp_SetFavoriteVendor]
(
  @pCustomerId binary(16), 
  @pVendorId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

  INSERT INTO [dbo].CUSTOMER_FAVORITE_VENDOR VALUES(newid(), @pVendorId, @pCustomerId)
END

GO

CREATE PROCEDURE [dbo].[usp_GetFavoriteVendors]
(
  @pCustomerId binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

SELECT V.VENDOR_ID, V.NAME AS VENDOR_NAME,
(SELECT COUNT(*) FROM VENDOR_RATING VR WHERE VR.VENDOR_ID = V.VENDOR_ID)AS TOTAL_RATINGS,
dbo.[GetVendorTotalRating](V.VENDOR_ID) AS OVERALL_RATINGS

	FROM [dbo].[CUSTOMER_FAVORITE_VENDOR] CFV
	INNER JOIN [dbo].[VENDOR] V ON V.VENDOR_ID = CFV.VENDOR_ID
	WHERE CFV.CUSTOMER_ID = @pCustomerId
END

GO

USE [Tasko]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateVendor]    Script Date: 01-06-2016 00:36:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateVendor]
(
	@pVendorId binary(16),
	@pName nvarchar(max),
	@pMobileNumber nvarchar(max),  
	@pAddress nvarchar(max),  
	@pEmailAddress nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;

UPDATE [dbo].VENDOR SET NAME = COALESCE(@pName,NAME),
						MOBILE_NUMBER = COALESCE(@pMobileNumber,MOBILE_NUMBER),					    
						ADDRESS = COALESCE(@pAddress, ADDRESS),
						EMAIL_ADDRESS = COALESCE(@pEmailAddress, EMAIL_ADDRESS)
WHERE VENDOR_ID = @pVendorId

END

GO


/****** Object:  StoredProcedure [dbo].[usp_InsertOTPDetails]    Script Date: 07-06-2016 02:09:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_InsertOTPDetails]
@pOtp varchar(20),
@pPhoneNumber varchar(20),
@pEmailId varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @count smallint

	SELECT @count = count(1) FROM OTP_DETAILS WHERE PHONE_NUMBER = @pPhoneNumber

	IF(@count >0)
	BEGIN

	--update 
		UPDATE OTP_DETAILS SET OTP=@pOtp where PHONE_NUMBER = @pPhoneNumber
	END
	ELSE
	BEGIN

		INSERT INTO OTP_DETAILS (PHONE_NUMBER, EMAIL_ID, OTP) VALUES (@pPhoneNumber,@pEmailId, @pOtp)	
	END

END




GO

/****** Object:  StoredProcedure [dbo].[usp_ValidateOTP]    Script Date: 07-06-2016 02:10:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_ValidateOTP]
(
@pPhoneNumber varchar(20),
@pOTP varchar(10)
)
AS
BEGIN

SET NOCOUNT ON;
declare @count int
declare @isvalid bit
select @count = count(1) from OTP_DETAILS where PHONE_NUMBER = @pPhoneNumber and OTP = @pOTP

if(@count >0)
BEGIN
set @isvalid = 1
DELETE FROM OTP_DETAILS where PHONE_NUMBER = @pPhoneNumber and OTP = @pOTP
END
Else
begin 
	set @isvalid =0
end

select @isvalid as IsValid
End

GO


/****** Object:  StoredProcedure [dbo].[usp_AddCustomer]    Script Date: 07-06-2016 02:11:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddCustomer]
(
  @pName nvarchar(max),
  @pEmailId nvarchar(max),
  @pPhoneNumber nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @customerId Binary(16)
DECLARE @authCode Binary(16)
SET @customerId = NEWID()
set @authCode = NEWID()

INSERT INTO CUSTOMER (CUSTOMER_ID, NAME, EMAIL_ADDRESS, MOBILE_NUMBER) VALUES (@customerId, @pName, @pEmailId, @pPhoneNumber)
   INSERT INTO LOGGEDON_USER VALUES(@customerId, @authCode)
   
   SELECT @customerId as USERID, @authCode as AUTH_CODE

END

GO

CREATE PROCEDURE [dbo].[usp_CustomerLoginValidateOTP]
(
@pPhoneNumber varchar(20),
@pOTP varchar(10)
)
AS
BEGIN

	SET NOCOUNT ON;
	declare @count int
	declare @isvalid bit
	declare @customerId binary(16)
	declare @authCode binary(16)
	set @authCode = NEWID()
	select @count = count(1) from OTP_DETAILS where PHONE_NUMBER = @pPhoneNumber and OTP = @pOTP

	if(@count >0)
	BEGIN
		set @isvalid = 1
		select @customerId =  CUSTOMER_ID from CUSTOMER where MOBILE_NUMBER = @pPhoneNumber
		DELETE FROM OTP_DETAILS where PHONE_NUMBER = @pPhoneNumber and OTP = @pOTP
		insert into loggedon_user values(@customerId, @authCode)
	END
	Else
	BEGIN 
		set @isvalid =0
	END

	SELECT @isvalid as IsValid , @customerId as USERID, @authCode as AUTH_CODE
End

GO

CREATE PROCEDURE [dbo].usp_GetCustomerDetails
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
FROM [dbo].[CUSTOMER] (NOLOCK)
WHERE CUSTOMER_ID = @pCustomerId 

END

GO









