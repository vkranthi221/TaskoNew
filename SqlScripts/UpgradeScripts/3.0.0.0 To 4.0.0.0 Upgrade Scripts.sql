--------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 
CREATE TABLE [dbo].[COUNTRY](
	[Id] [binary](16) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[STATE](
	[Id] [binary](16) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryId] [binary](16) NOT NULL,
 CONSTRAINT [PK_STATE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[STATE]  WITH CHECK ADD  CONSTRAINT [FK_STATE_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO

ALTER TABLE [dbo].[STATE] CHECK CONSTRAINT [FK_STATE_COUNTRY]
GO

CREATE TABLE [dbo].[City](
	[ID] [binary](16) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StateId] [binary](16) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_STATE] FOREIGN KEY([StateId])
REFERENCES [dbo].[STATE] ([Id])
GO

ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_STATE]
GO
CREATE TABLE [dbo].[RateCard](
	[Id] [binary](16) NOT NULL,
	[ServiceId] [binary](16) NOT NULL,
	[CityId] [binary](16) NOT NULL,
	[AmountCharged] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_RateCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RateCard]  WITH CHECK ADD  CONSTRAINT [FK_RateCard_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([ID])
GO

ALTER TABLE [dbo].[RateCard] CHECK CONSTRAINT [FK_RateCard_City]
GO

ALTER TABLE [dbo].[RateCard]  WITH CHECK ADD  CONSTRAINT [FK_RateCard_SERVICES] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[SERVICES] ([SERVICE_ID])
GO

ALTER TABLE [dbo].[RateCard] CHECK CONSTRAINT [FK_RateCard_SERVICES]
GO

CREATE TABLE [dbo].[SOCIALMEDIAPOST](
	[ID] [binary](16) NOT NULL,
	[MESSAGE] [varchar](max) NULL,
	[VIEWS] [int] NULL,
	[VENDOR_ID] [binary](16) NOT NULL,
	[POSTED_DATE] [datetime] NULL,
 CONSTRAINT [PK_SOCIALMEDIAPOST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SOCIALMEDIAPOST]  WITH CHECK ADD  CONSTRAINT [FK_SOCIALMEDIAPOST_VENDOR] FOREIGN KEY([VENDOR_ID])
REFERENCES [dbo].[VENDOR] ([VENDOR_ID])
GO

ALTER TABLE [dbo].[SOCIALMEDIAPOST] CHECK CONSTRAINT [FK_SOCIALMEDIAPOST_VENDOR]
GO

CREATE TABLE [dbo].[SOCIALMEDIAPOSTIMAGE](
	[ID] [binary](16) NOT NULL,
	[POSTID] [binary](16) NOT NULL,
	[IMAGEURL] [varchar](max) NOT NULL,
	[POSTED_DATE] [datetime] NULL,
 CONSTRAINT [PK_SOCIALMEDIAPOSTIMAGE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SOCIALMEDIAPOSTIMAGE]  WITH CHECK ADD  CONSTRAINT [FK_SOCIALMEDIAPOSTIMAGE_SOCIALMEDIAPOST] FOREIGN KEY([POSTID])
REFERENCES [dbo].[SOCIALMEDIAPOST] ([ID])
GO

ALTER TABLE [dbo].[SOCIALMEDIAPOSTIMAGE] CHECK CONSTRAINT [FK_SOCIALMEDIAPOSTIMAGE_SOCIALMEDIAPOST]
GO


CREATE PROCEDURE [dbo].[usp_GetVendorPostsURL]
(
	@pPostId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT IMAGEURL
  FROM SOCIALMEDIAPOSTIMAGE 
WHERE POSTID = @pPostId

END


GO


CREATE TABLE [dbo].[SOCIALMEDIALIKEDCUSTOMER](
	[ID] [binary](16) NOT NULL,
	[POSTID] [binary](16) NOT NULL,
	[CUSTOMERID] [binary](16) NOT NULL,
	[LIKED_DATE] [datetime] NULL,
 CONSTRAINT [PK_SOCIALMEDIALIKEDCUSTOMER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SOCIALMEDIALIKEDCUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_SOCIALMEDIALIKEDCUSTOMER_CUSTOMER] FOREIGN KEY([CUSTOMERID])
REFERENCES [dbo].[CUSTOMER] ([CUSTOMER_ID])
GO

ALTER TABLE [dbo].[SOCIALMEDIALIKEDCUSTOMER] CHECK CONSTRAINT [FK_SOCIALMEDIALIKEDCUSTOMER_CUSTOMER]
GO

ALTER TABLE [dbo].[SOCIALMEDIALIKEDCUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_SOCIALMEDIALIKEDCUSTOMER_SOCIALMEDIAPOST] FOREIGN KEY([POSTID])
REFERENCES [dbo].[SOCIALMEDIAPOST] ([ID])
GO

ALTER TABLE [dbo].[SOCIALMEDIALIKEDCUSTOMER] CHECK CONSTRAINT [FK_SOCIALMEDIALIKEDCUSTOMER_SOCIALMEDIAPOST]
GO




CREATE TABLE [dbo].[CUSTOMERREPORTEDPOST](
	[ID] [binary](16) NOT NULL,
	[CUSTOMER_ID] [binary](16) NOT NULL,
	[POST_ID] [binary](16) NOT NULL,
	[REASON] [varchar](max) NULL,
	[COMMENT] [varchar](max) NULL,
	[REPORTED_DATE] [datetime] NULL,
 CONSTRAINT [PK_CUSTOMERREPORTEDPOST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CUSTOMERREPORTEDPOST]  WITH CHECK ADD  CONSTRAINT [FK_CUSTOMERREPORTEDPOST_CUSTOMER] FOREIGN KEY([CUSTOMER_ID])
REFERENCES [dbo].[CUSTOMER] ([CUSTOMER_ID])
GO

ALTER TABLE [dbo].[CUSTOMERREPORTEDPOST] CHECK CONSTRAINT [FK_CUSTOMERREPORTEDPOST_CUSTOMER]
GO

ALTER TABLE [dbo].[CUSTOMERREPORTEDPOST]  WITH CHECK ADD  CONSTRAINT [FK_CUSTOMERREPORTEDPOST_SOCIALMEDIAPOST] FOREIGN KEY([POST_ID])
REFERENCES [dbo].[SOCIALMEDIAPOST] ([ID])
GO

ALTER TABLE [dbo].[CUSTOMERREPORTEDPOST] CHECK CONSTRAINT [FK_CUSTOMERREPORTEDPOST_SOCIALMEDIAPOST]
GO







/*********** Stored Procedures **************************/
GO

CREATE PROCEDURE [dbo].[usp_AddState]
(
  @pName nvarchar(max)
)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @IsStateAlreadyExist bit

IF NOT EXISTS (SELECT NAME from [dbo].[STATE] WHERE NAME = @pName)
 BEGIN
   INSERT INTO [dbo].[STATE] VALUES (NEWID(), @pName, (select id from COUNTRY))
   SET @IsStateAlreadyExist =0
 END
 ELSE
 BEGIN
   SET @IsStateAlreadyExist =1
 END

 SELECT @IsStateAlreadyExist
END
GO

CREATE PROCEDURE [dbo].[usp_AddCity]
(
  @pName nvarchar(max),
  @pStateId Binary(16) = NULL
)

AS
BEGIN
IF NOT EXISTS (SELECT NAME from [dbo].[City] WHERE NAME = @pName)
 BEGIN
   INSERT INTO [dbo].[City] VALUES (NEWID(), @pName, @pStateId)
 END
END

GO

CREATE PROCEDURE [dbo].[usp_AddRateCard]
(
  @pPrice decimal,
  @pCityId Binary(16) = NULL,
  @pServiceId Binary(16) = NULL
)

AS
BEGIN
IF NOT EXISTS (SELECT Id from [dbo].[RateCard] WHERE CityId = @pCityId AND ServiceId = @pServiceId)
 BEGIN
   INSERT INTO [dbo].[RateCard] VALUES (NEWID(), @pServiceId, @pCityId, @pPrice)
 END
END
GO

CREATE PROCEDURE [dbo].[usp_GetCities]
(
	@pStateId Binary(16)
)
AS
BEGIN
SET NOCOUNT ON;
SELECT ID, Name, StateId
  FROM [dbo].[CITY]

END

GO

Create PROCEDURE [dbo].[usp_GetAllCities]

AS
BEGIN
SET NOCOUNT ON;

SELECT ID, Name, StateId
  FROM CITY  

END
GO

CREATE PROCEDURE [dbo].[usp_GetRateCardsForCity]
(
	@pcityId Binary(16),
	@pServiceId Binary(16)
)
AS
BEGIN
SET NOCOUNT ON;
IF(@pcityId IS NOT NULL AND @pServiceId IS NOT NULL )
BEGIN
SELECT R.Id, R.ServiceId, R.CityId, R.AmountCharged, SVCS.Name AS ServiceName, c.Name as CityName
  FROM RateCard  R
   INNER JOIN dbo.[SERVICES] SVCS ON R.ServiceId = SVCS.SERVICE_ID  and PARENT_SERVICE_ID = @pServiceId
   INNER JOIN dbo.[City] c on R.CityId = c.ID
WHERE CityId = @pcityId
END
END
GO

CREATE PROCEDURE [dbo].[usp_UpdateRateCards]
(
  @pServiceId Binary(16),
  @pCityId Binary(16),
  @pPrice decimal
)

AS
BEGIN

SET NOCOUNT ON;
   UPDATE [dbo].[RateCard] SET AmountCharged = @pPrice WHERE ServiceId =@pServiceId AND CityId = @pCityId
END
GO

CREATE PROCEDURE [dbo].[usp_DeleteRateCards]
(  
  @pRateCardId Binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

   DELETE [dbo].[RateCard] WHERE Id = @pRateCardId
END
GO
CREATE PROCEDURE [dbo].[usp_DeleteCities]
(  
  @pCityId Binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

   DELETE [dbo].[City] WHERE Id = @pCityId
END
GO

CREATE PROCEDURE [dbo].[usp_GetStates]

AS
BEGIN

SET NOCOUNT ON;

SELECT [Id]
      ,[NAME]
  FROM [dbo].[STATE]
END

GO

CREATE PROCEDURE [dbo].[usp_DeleteStates]
(  
  @pStateId Binary(16)
)

AS
BEGIN

SET NOCOUNT ON;

   DELETE [dbo].[STATE] WHERE Id = @pStateId
END
GO

CREATE PROCEDURE [dbo].[usp_AddPost]
(
  @pMessage nvarchar(max),
  @pVendorId binary(16)
)

AS
BEGIN
declare @ID BINARY(16)
SET NOCOUNT ON;
set @ID = NEWID()
   INSERT INTO [dbo].[SOCIALMEDIAPOST] VALUES (@ID, @pMessage, 0, @pVendorId,GETDATE())

   SELECT @ID AS ID
END

GO

CREATE PROCEDURE [dbo].[usp_AddPostURL]
(
  @pImageURL nvarchar(max),
  @pPostId binary(16)
)

AS
BEGIN
SET NOCOUNT ON;
   INSERT INTO [dbo].[SOCIALMEDIAPOSTIMAGE] VALUES (NEWID(), @pPostId, @pImageURL,GETDATE())

END

GO

CREATE PROCEDURE [dbo].[usp_GetVendorPosts]
(
	@pVendorId Binary(16),
	@pPAGENO INT,
	@pRECORDSPERPAGE INT
)
AS
BEGIN

SET NOCOUNT ON;
DECLARE @VSQL NVARCHAR(MAX)
SET @VSQL= 'SELECT SM.ID, SM.MESSAGE, SM.VIEWS, (SELECT COUNT(distinct SC.ID)) AS LIKES, SM.POSTED_DATE, V.PHOTO
  FROM SOCIALMEDIAPOST SM 
  LEFT JOIN SOCIALMEDIALIKEDCUSTOMER SC ON SC.POSTID = SM.ID
  INNER JOIN VENDOR V ON V.VENDOR_ID=SM.VENDOR_ID
WHERE SM.VENDOR_ID = @vVENDORID GROUP BY SM.ID, SM.MESSAGE, SM.VIEWS, SM.POSTED_DATE, V.PHOTO'

IF(@pPAGENO<>0)
	  SET @VSQL = @VSQL +' ORDER BY SM.ID DESC OFFSET (@vPAGENO-1)*@vRECORDSPERPAGE ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
      
EXEC SP_EXECUTESQL @VSQL,N'@vVENDORID BINARY(16), @vPAGENO INT, @vRECORDSPERPAGE INT', @pVendorId, @pPAGENO, @pRECORDSPERPAGE
END

GO




CREATE PROCEDURE [dbo].[usp_UpdatePost]
(
  @pMessage nvarchar(max),
  @pPostId binary(16),
  @pViews int
)

AS
BEGIN
   UPDATE [dbo].[SOCIALMEDIAPOST] SET MESSAGE = @pMessage, VIEWS = @pViews WHERE ID = @pPostId
   DELETE FROM [dbo].[SOCIALMEDIAPOSTIMAGE] WHERE POSTID = @pPostId
END
GO

CREATE PROCEDURE [dbo].[usp_DeletePost]
(
  @pPostId binary(16)
)

AS
BEGIN
   DELETE FROM [dbo].[SOCIALMEDIAPOSTIMAGE] WHERE POSTID = @pPostId
   Delete from [dbo].[SOCIALMEDIAPOST] where ID = @pPostId
END

GO

CREATE PROCEDURE [dbo].[usp_UpdateCustomerLikeForPost]
(
  @pPostId binary(16),
  @pCustomerId binary(16),
  @pIsLiked bit
)

AS
BEGIN
IF @pIsLiked = 0
BEGIN
DELETE FROM [dbo].[SOCIALMEDIALIKEDCUSTOMER] WHERE POSTID = @pPostId AND CUSTOMERID = @pCustomerId
END
ELSE
BEGIN
DECLARE @COUNT AS INT
SET @COUNT = (SELECT COUNT(*) FROM [dbo].[SOCIALMEDIALIKEDCUSTOMER] WHERE POSTID = @pPostId AND CUSTOMERID = @pCustomerId)
IF @COUNT >0 
BEGIN
DELETE FROM [dbo].[SOCIALMEDIALIKEDCUSTOMER] WHERE POSTID = @pPostId AND CUSTOMERID = @pCustomerId
END
INSERT INTO [dbo].[SOCIALMEDIALIKEDCUSTOMER] VALUES (NEWID(), @pPostId, @pCustomerId,GETDATE())
END

END

GO

CREATE PROCEDURE [dbo].[usp_ReportPost]
(
  @pPostId binary(16),
  @pCustomerId binary(16),
  @pReason varchar,
  @pComment varchar
)

AS
BEGIN
INSERT INTO [dbo].[CUSTOMERREPORTEDPOST] VALUES (NEWID(),@pCustomerId, @pPostId,@pReason, @pComment, getdate())
END
GO

CREATE PROCEDURE [dbo].[usp_GetVendorPosts]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT SM.ID, SM.MESSAGE, SM.VIEWS, (SELECT COUNT(distinct SC.ID)) AS LIKES, SM.POSTED_DATE
  FROM SOCIALMEDIAPOST SM 
  INNER JOIN SOCIALMEDIALIKEDCUSTOMER SC ON SC.POSTID = SM.ID
WHERE SM.VENDOR_ID = @pVendorId GROUP BY SM.ID, SM.MESSAGE, SM.VIEWS, SM.POSTED_DATE

END

GO

CREATE PROCEDURE [dbo].[usp_GetPostDetails]
(
	@pPostId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT SM.ID, SM.MESSAGE, SM.VIEWS, (SELECT COUNT(distinct SC.ID)) AS LIKES
  FROM SOCIALMEDIAPOST SM 
  INNER JOIN SOCIALMEDIALIKEDCUSTOMER SC ON SC.POSTID = SM.ID
WHERE SM.ID = @pPostId GROUP BY SM.ID, SM.MESSAGE, SM.VIEWS

END

GO

CREATE PROCEDURE [dbo].[usp_GetPostReports]
(
	@pPostId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT ID, CUSTOMER_ID, POST_ID,REASON,COMMENT,REPORTED_DATE FROM CUSTOMERREPORTEDPOST
WHERE POST_ID = @pPostId

END

GO
CREATE PROCEDURE [dbo].[usp_GetPostLikes]
(
	@pPostId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT CUSTOMERID,LIKED_DATE,C.NAME FROM SOCIALMEDIALIKEDCUSTOMER
INNER JOIN CUSTOMER C ON C.CUSTOMER_ID = CUSTOMERID
WHERE POSTID = @pPostId

END
GO

CREATE PROCEDURE [dbo].[usp_GetAllPosts]
(
	 @pPageNo int,
	  @pRecordsPerPage int
)
AS
BEGIN

SET NOCOUNT ON;
DECLARE @VSQL NVARCHAR(MAX)

SET @VSQL= 'SELECT SM.ID, SM.MESSAGE, SM.VIEWS, (SELECT COUNT(distinct SC.ID)) AS LIKES, SM.POSTED_DATE, V.NAME
  FROM SOCIALMEDIAPOST SM 
  INNER JOIN SOCIALMEDIALIKEDCUSTOMER SC ON SC.POSTID = SM.ID
  INNER JOIN VENDOR V ON V.VENDOR_ID = SM.VENDOR_ID GROUP BY SM.ID, SM.MESSAGE, SM.VIEWS, SM.POSTED_DATE,V.NAME'

   SET @VSQL = @VSQL +' ORDER BY SM.ID DESC OFFSET (@vPAGENO-1)*@vrecordsperpage ROWS FETCH NEXT @vRECORDSPERPAGE ROWS ONLY'
   EXEC SP_EXECUTESQL @VSQL,N'@vPAGENO INT, @vRECORDSPERPAGE INT', @pPageNo, @pRecordsPerPage
END


GO





INSERT INTO COUNTRY VALUES (NEWID(),'India')
GO

IF NOT EXISTS (SELECT * FROM [dbo].[DB_VERSION] WHERE [VERSION] = '4.0.0.0')
BEGIN
     INSERT INTO [dbo].[DB_VERSION] values('4.0.0.0', Getdate())
END
GO

