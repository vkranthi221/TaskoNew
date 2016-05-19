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
	[ORDER_ID] VARCHAR(50) NOT NULL,
	[VENDOR_SERVICE_ID] Binary(16) NOT NULL,
	[CUSTOMER_ID] Binary(16) NOT NULL,
	[REQUESTED_DATE] datetime NOT NULL,
	[ORDER_STATUS_ID] int NOT NULL,
	[ORDER_LOCATION] VARCHAR(MAX) NULL,
    CONSTRAINT [ORDER_PK] PRIMARY KEY CLUSTERED([ORDER_ID]))
GO

/****** Object:  ForeignKey [FK_Order_OrderStatus]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [ORDER_ORDER_STATUS_FK] FOREIGN KEY([ORDER_STATUS_ID])
REFERENCES [dbo].[ORDER_STATUS] ([ORDER_STATUS_ID])
GO
ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [ORDER_ORDER_STATUS_FK]
GO

/****** Object:  ForeignKey [ORDER_CUSTOMER_FK]    Script Date: 05/12/2016 08:57:10 ******/
ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [ORDER_CUSTOMER_FK] FOREIGN KEY([CUSTOMER_ID])
REFERENCES [dbo].[CUSTOMER] ([CUSTOMER_ID])
GO
ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [ORDER_CUSTOMER_FK]
GO

/****** Object:  ForeignKey [ORDER_VENDOR_SERVICES_FK]    Script Date: 05/12/2016 08:57:10 ******/
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
  ORD.REQUESTED_DATE ,ORD.ORDER_LOCATION 
  FROM dbo.[ORDER] ORD
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN VENDOR VEN ON VS.VENDOR_ID= VEN.VENDOR_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
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
	@pOrderStatus int 
)
AS
BEGIN

DECLARE @err_message nvarchar(255)
SET NOCOUNT ON;

IF EXISTS (Select NAME from ORDER_STATUS WHERE ORDER_STATUS_ID = @pOrderStatus)
  BEGIN
        UPDATE [dbo].[ORDER]  SET ORDER_STATUS_ID = @pOrderStatus WHERE ORDER_ID = @pOrderId
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
            
SET @VSQL= 'SELECT ORD.ORDER_ID, ORD.REQUESTED_DATE, SVCS.NAME AS SERVICENAME, OS.NAME AS ORDERSTATUSNAME
  FROM dbo.[ORDER] ORD
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN dbo.[SERVICES] SVCS ON VS.SERVICE_ID = SVCS.SERVICE_ID 
  INNER JOIN ORDER_STATUS OS ON ORD.ORDER_STATUS_ID = OS.ORDER_STATUS_ID  
WHERE VS.VENDOR_ID = @vVENDORID '

IF(@PORDERSTATUSID<>0)
      SET @VSQL = @VSQL + ' AND ORD.ORDER_STATUS_ID = @vORDERSTATUSID '

	  SET @VSQL = @VSQL +' ORDER BY ORD.ORDER_ID OFFSET (@vPAGENO-1)*@vRECORDSPERPAGE ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
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
  INNER JOIN DBO.[ORDER] ORD ON ORD.ORDER_ID = VR.ORDER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  WHERE VS.VENDOR_ID= @pVENDORID

END

GO

CREATE PROCEDURE [dbo].[usp_GetVendorRatings]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY, VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME,
round(sum(VR.SERVICE_QUALITY + VR.PUNCTUALITY + VR.COURTESY + VR.PRICE)/4,0) AS TOTAL
  FROM VENDOR_RATING VR
  INNER JOIN dbo.[ORDER] ORD ON ORD.ORDER_ID = VR.ORDER_ID
  INNER JOIN VENDOR_SERVICES VS ON ORD.VENDOR_SERVICE_ID = VS.VENDOR_SERVICE_ID
  INNER JOIN CUSTOMER CUST ON ORD.CUSTOMER_ID = CUST.CUSTOMER_ID
  WHERE VS.VENDOR_ID= @pVendorId
  Group by VR.VENDOR_RATING_ID, VR.SERVICE_QUALITY, VR.PUNCTUALITY, VR.COURTESY,VR.PRICE, VR.REVIEW_DATE, VR.COMMENTS, CUST.NAME
END

GO