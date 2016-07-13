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
DROP TABLE [dbo].[CUSTOMER_FAVORITE_VENDOR]
GO
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
DROP PROCEDURE [dbo].[usp_UpdateVendorService]
GO
DROP PROCEDURE [dbo].[usp_UpdateVendor]
GO
DROP PROCEDURE [dbo].[usp_InsertOTPDetails]
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
DROP TABLE [dbo].[OTP_DETAILS]
GO
DROP PROCEDURE [dbo].[usp_ValidateOTP]
GO
DROP PROCEDURE [dbo].[usp_AddCustomer]
GO
DROP PROCEDURE [dbo].[usp_GetCustomerDetails]
GO
DROP PROCEDURE [dbo].[usp_CustomerLoginValidateOTP]
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
GO
DROP PROCEDURE [dbo].[usp_ChangePassword]
GO
DROP PROCEDURE [dbo].[usp_SetFavoriteVendor]
GO
DROP PROCEDURE [dbo].[usp_GetFavoriteVendors]
GO
DROP FUNCTION [dbo].[GetVendorTotalRating]
GO
DROP PROCEDURE [dbo].[usp_DeleteFavoriteVendor]
GO
DROP PROCEDURE [dbo].[usp_AddService]
GO
DROP PROCEDURE [dbo].[usp_UpdateService]
GO
DROP PROCEDURE [dbo].[usp_DisableService]
GO
DROP PROCEDURE [dbo].[usp_DeleteService]
GO
DROP PROCEDURE [dbo].[usp_GetALLServices]
GO
DROP PROCEDURE [dbo].[usp_GetOrdersByService]
GO
DROP PROCEDURE [dbo].[usp_GetVendorsByService]
GO
DROP TABLE [dbo].[ACTIVITY]
Go
DROP PROCEDURE [dbo].[usp_AddActivity]
GO
DROP PROCEDURE [dbo].[usp_GetDashboardMeters]
GO
DROP PROCEDURE [dbo].[usp_GetDashboardRecentActivities]
GO
DROP PROCEDURE [dbo].[usp_GetDashboardRecentOrdersByStatus]
GO
DROP PROCEDURE [dbo].[usp_AddVendor]
GO
DROP PROCEDURE [dbo].[usp_AddVendorService]
GO
DROP PROCEDURE [dbo].[usp_DeleteVendorServices]
GO
DROP PROCEDURE [dbo].[usp_GetServicesForVendor]
GO
DROP PROCEDURE [dbo].[usp_GetVendorOverview]
GO
DROP TABLE [dbo].[COMPLAINT]
GO
DROP PROCEDURE [dbo].[usp_DeactivateVendorServices]
GO
DROP PROCEDURE [dbo].[usp_GetVendorsByStatus]
GO
DROP TABLE [dbo].[PAYMENTS]
GO
DROP FUNCTION [dbo].[GeneratePaymentId]
GO
DROP PROCEDURE [dbo].[usp_AddPayment]
GO
DROP PROCEDURE [dbo].[usp_UpdatePayment]
GO
DROP PROCEDURE [dbo].[usp_GetAllPaymentsByStatus]
GO
DROP PROCEDURE [dbo].[usp_GetAllCustomersByStatus]
GO
DROP PROCEDURE [dbo].[usp_GetCustomerRatingForOrders]
GO
DROP PROCEDURE [dbo].[usp_UpdateVendorDetails]
GO
DROP PROCEDURE [dbo].[usp_GetCustomerOverview]
GO
DROP PROCEDURE [dbo].[usp_GetPayment]
GO
DROP PROCEDURE [dbo].[usp_GetVendorAddress]
GO
DROP PROCEDURE [dbo].[usp_GetServiceOverview]
GO
DROP PROCEDURE [dbo].[usp_AddUser]
GO
DROP PROCEDURE [dbo].[usp_DeleteUser]
GO
DROP PROCEDURE [dbo].[usp_GetAllUsers]
GO
DROP PROCEDURE [dbo].[usp_LoginAdminUser]
GO
DROP TABLE [dbo].[USER]

