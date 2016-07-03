USE [Tasko]

ALTER TABLE [dbo].[SERVICES] ADD [STATUS] int NULL
GO
UPDATE [dbo].[SERVICES] SET [STATUS]=0 
GO
ALTER TABLE [dbo].[SERVICES] ALTER COLUMN [STATUS] int NOT NULL
GO

CREATE PROCEDURE [dbo].[usp_AddService]
(
  @pName nvarchar(max),
  @pImageUrl nvarchar(max),
  @pParentServiceId Binary(16),
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
CREATE PROCEDURE [dbo].[usp_UpdateService]
(
  @pServiceId Binary(16),
  @pName nvarchar(max),
  @pImageUrl nvarchar(max),
  @pStatus int
)

AS
BEGIN

SET NOCOUNT ON;
   UPDATE [dbo].[SERVICES] SET NAME = @pName, IMAGE_URL = @pImageUrl, [Status]=@pStatus WHERE SERVICE_ID =@pServiceId
END

GO
CREATE PROCEDURE [dbo].[usp_DisableService]
(
  @pServiceId Binary(16),
  @pStatus int
)

AS
BEGIN

SET NOCOUNT ON;
   UPDATE [dbo].[SERVICES] SET [Status]=@pStatus WHERE SERVICE_ID =@pServiceId
END

GO
CREATE PROCEDURE [dbo].[usp_DeleteService]
(  
  @pServiceId Binary(16)
)

AS
BEGIN

SET NOCOUNT ON;
DECLARE @IsServiceInUse bit

IF NOT EXISTS (SELECT SERVICE_ID from [dbo].[VENDOR_SERVICES] WHERE SERVICE_ID = @pServiceId)
 BEGIN
   DELETE [dbo].[SERVICES] WHERE SERVICE_ID = @pServiceId
   SET @IsServiceInUse =0
 END
 ELSE
 BEGIN
   SET @IsServiceInUse =1
 END

 SELECT @IsServiceInUse
END

GO
ALTER PROCEDURE [dbo].[usp_GetServices]

AS
BEGIN

SET NOCOUNT ON;

SELECT [SERVICE_ID]
      ,[NAME]
      ,[PARENT_SERVICE_ID]
      ,[IMAGE_URL]
  FROM [dbo].[SERVICES]
  WHERE [PARENT_SERVICE_ID] IS NULL AND [STATUS]=0
END

GO
CREATE PROCEDURE [dbo].[usp_GetALLServices]

AS
BEGIN

SET NOCOUNT ON;

SELECT SV.[SERVICE_ID]
      ,[NAME]
      ,[PARENT_SERVICE_ID]
      ,[IMAGE_URL]
	  ,[STATUS]
	  ,COUNT(VS.SERVICE_ID) AS NumberOfVendors
  FROM [dbo].[SERVICES] SV
  LEFT OUTER JOIN [dbo].[VENDOR_SERVICES] VS ON SV.SERVICE_ID = VS.SERVICE_ID
END

