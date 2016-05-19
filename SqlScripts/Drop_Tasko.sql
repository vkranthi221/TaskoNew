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
Drop FUNCTION [dbo].[GenerateOrderID]
Go
DROP PROCEDURE [dbo].[usp_GetOrderDetails]
GO
DROP PROCEDURE [dbo].[usp_GetVendorDetails]
GO
DROP PROCEDURE [dbo].[usp_GetVendorServices]
GO
DROP PROCEDURE [dbo].[usp_GetVendorSubServices]
GO
DROP PROCEDURE [dbo].usp_GetVendorOrders
GO
DROP PROCEDURE [dbo].usp_GetVendorOverallRating
GO
DROP PROCEDURE [dbo].usp_GetVendorRatings
GO
DROP PROCEDURE [dbo].usp_UpdateOrderStatus