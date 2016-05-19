---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 
    
SELECT * FROM [dbo].[SERVICES]
GO
SELECT * FROM [dbo].[ID_PROOFS]
GO
SELECT * FROM [dbo].[ORDER_STATUS]
GO

------------ Vendor TestData -----------
--  VendorId Should be binary not int,
--  Name and Number should be unique, 
--  mobile number should not be varchar(max) change it to nVarchar(10)
  
INSERT INTO [dbo].[Vendor] values(NEWID(),'chandra','9985466195','12345','KPHB,VivekanandaNagar',null,10,50.00,1,1,Getdate(),Getdate(),10.00,123)
INSERT INTO [dbo].[Vendor] values(NEWID(),'Srikanth','1234567890','12345','KPHB,HMT Hills',null,10,100.00,1,1,Getdate(),Getdate(),10.00,123)
SELECT * FROM [dbo].[Vendor]

INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Electrician'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='Srikanth'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Plumber'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Tube Lights'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='FAN and Cooler'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='AC'),1)
SELECT * FROM [dbo].VENDOR_SERVICES

INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji','shivaji@gmail.com','1234567890')
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji123','shivaji123@gmail.com','9999999999')
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji456','shivaji456@gmail.com','9876543210')
SELECT * FROM [dbo].Customer

INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Tube Lights')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Plumber')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb')
SELECT * FROM [dbo].[ORDER]

INSERT INTO [dbo].VENDOR_RATING values((select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra'),
2,2,3,1,
getdate(),
'Service is good', (
select ORDER_ID from [dbo].[Order] 
where VENDOR_SERVICE_ID in(SELECT VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES
where VENDOR_ID IN (SELECT VENDOR_ID FROM [dbo].VENDOR WHERE NAME='chandra') 
and SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Tube Lights'))))

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1001'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
2,2,2,2,
getdate(),
'Service is not provided in time', ('TASKO1002'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1003'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1004'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
3,3,3,3,
getdate(),
'Service is provided in time', ('TASKO1005'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
4,4,4,4,
getdate(),
'Service is provided in time', ('TASKO1006'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
5,5,5,5,
getdate(),
'Service is not provided in time', ('TASKO1007'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,2,3,4,
getdate(),
'Service is not provided in time', ('TASKO1008'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
2,2,3,4,
getdate(),
'Service is in time', ('TASKO1009'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].VENDOR_RATING values(newId(),
5,1,3,4,
getdate(),
'Service is Good', ('TASKO1010'))
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].CUSTOMER_RATING VALUES((SELECT CUSTOMER_ID FROM [dbo].[ORDER] WHERE CUSTOMER_ID IN (SELECT CUSTOMER_ID FROM [dbo].Customer WHERE NAME='Shivaji')),(SELECT ORDER_ID FROM [dbo].[order] WHERE CUSTOMER_ID IN(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji')),4,'Good Customer')
SELECT * FROM [dbo].CUSTOMER_RATING
