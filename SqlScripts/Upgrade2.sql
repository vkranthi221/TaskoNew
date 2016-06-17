---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 

ALTER TABLE [dbo].[VENDOR] ADD [USER_NAME] VARCHAR(max) NULL
GO
UPDATE [dbo].[VENDOR] SET [USER_NAME]='taskov1' where Name ='chandra'
GO
UPDATE [dbo].[VENDOR] SET [USER_NAME]='taskov2' where Name ='Srikanth'
ALTER TABLE [dbo].[VENDOR] ALTER COLUMN [USER_NAME] VARCHAR(max) NOT NULL
GO

ALTER PROCEDURE [dbo].[usp_GetVendorDetails]
(
	@pVendorId Binary(16)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT [VENDOR_ID]
      ,[USER_NAME]
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

ALTER PROCEDURE [dbo].[usp_LOGIN]
(
	@pUserName Varchar(max),
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
 IF @pUserName IS NOT NULL AND LEN(@pUserName) > 0 --username is passed
	BEGIN
		select @UserID= VENDOR_ID from vendor where [USER_NAME] = @pUserName and PASSWORD = @pPassword
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
