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
IF(@pStateId IS NOT NULL)
BEGIN
SELECT ID, Name, StateId
  FROM CITY  
WHERE StateId = @pStateId
END
ELSE
BEGIN
SELECT ID, Name, StateId
  FROM [dbo].[CITY]
END
END

GO

CREATE PROCEDURE [dbo].[usp_GetRateCardsForCity]
(
	@pcityId Binary(16)
)
AS
BEGIN
SET NOCOUNT ON;
IF(@pcityId IS NOT NULL)
BEGIN
SELECT Id, ServiceId, CityId, AmountCharged, SVCS.Name AS ServiceName
  FROM RateCard  
   INNER JOIN dbo.[SERVICES] SVCS ON ServiceId = SVCS.SERVICE_ID   
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

IF NOT EXISTS (SELECT * FROM [dbo].[DB_VERSION] WHERE [VERSION] = '4.0.0.0')
BEGIN
     INSERT INTO [dbo].[DB_VERSION] values('4.0.0.0', Getdate())
END
GO