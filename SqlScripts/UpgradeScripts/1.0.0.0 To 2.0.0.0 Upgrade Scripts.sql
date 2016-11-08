---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 

---------------------------------------------------------------------------------------------------------- 

CREATE PROCEDURE [dbo].[usp_IsVendorExists]
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

