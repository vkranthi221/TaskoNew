----------------------------------------------------------------------------------------------------------
--------------------------- All Copy Rights are reserved to Tasko.in--------------------------------------
USE [Tasko]
GO
----------------------------------------------------------------------------------------------------------

DROP TABLE [dbo].[CUSTOMER_RATING]
Go
DROP TABLE [dbo].[VENDOR_ISSUES]
Go
DROP TABLE [dbo].[VENDOR_PROOF]
Go
DROP TABLE [dbo].[ISSUES]
Go
DROP TABLE [dbo].[VENDOR_RATING]
Go
DROP TABLE [dbo].[ID_PROOFS]
Go
DROP TABLE [dbo].[ORDER]
Go
DROP TABLE [dbo].[ORDER_STATUS]
Go
DROP TABLE [dbo].[CUSTOMER]
Go
DROP TABLE [dbo].[VENDOR_SERVICES]
Go
DROP TABLE [dbo].[VENDOR]
Go
DROP TABLE [dbo].[SERVICES]
Go
DROP PROCEDURE [dbo].[usp_GetOrderDetails]
GO
DROP PROCEDURE [dbo].[usp_GetVendorDetails]
GO
DROP PROCEDURE [dbo].[usp_GetVendorServices]
GO
DROP PROCEDURE [dbo].[usp_GetVendorSubServices]
GO
DROP PROCEDURE [dbo].[usp_UpdateVendorServices]
GO
DROP PROCEDURE [dbo].[usp_UpdateBaseRate]
GO
DROP FUNCTION [dbo].[CheckIsParentServiceId]
GO
DROP FUNCTION [dbo].[GenerateOrderID]
GO
DROP PROCEDURE [dbo].usp_GetVendorOrders
GO
DROP PROCEDURE [dbo].usp_GetVendorOverallRating
GO
DROP PROCEDURE [dbo].usp_GetVendorRatings
GO
DROP PROCEDURE [dbo].usp_UpdateOrderStatus
GO
DROP TABLE [dbo].[LOGGEDON_USER]
GO
DROP TABLE [dbo].[Auth_Code]
GO
DROP PROCEDURE [dbo].[usp_LOGIN]
GO
DROP PROCEDURE [dbo].[usp_Logout]
GO
DROP PROCEDURE [dbo].[usp_InsertAuthCode]
GO
DROP PROCEDURE [dbo].[usp_ValidateAuthCode]
GO
DROP PROCEDURE [dbo].[usp_ValidateTokenCode]
GO
DROP TABLE [dbo].[ADDRESS]
GO
DROP PROCEDURE [dbo].[usp_GetServices]
GO
DROP PROCEDURE [dbo].[usp_GetRecentOrder]
GO
DROP PROCEDURE [dbo].[usp_GetServiceVendors]
GO
DROP PROCEDURE [dbo].[usp_AddAddress]
GO
DROP PROCEDURE [dbo].[usp_ConfirmOrder]
GO
DROP PROCEDURE [dbo].[usp_UpdateCustomer]
GO
DROP PROCEDURE [dbo].[usp_GetCustomerOrders]
GO
DROP TABLE [dbo].[CUSTOMER_ADDRESS]
GO
DROP PROCEDURE [dbo].[usp_AddCustomerAddress]
GO
DROP PROCEDURE [dbo].[usp_UpdateCustomerAddress]
GO
DROP PROCEDURE [dbo].[usp_DeleteCustomerAddress]
GO
DROP PROCEDURE [dbo].[usp_GetCustomerAddresses]
GO
DROP PROCEDURE [dbo].[usp_AddVendorRating]