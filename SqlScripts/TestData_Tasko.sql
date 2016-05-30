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
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='Srikanth'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Microwave Service'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Carpentry'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='AC Service'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='AC Installation'),1)
SELECT * FROM [dbo].VENDOR_SERVICES

INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji','shivaji@gmail.com','1234567890')
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji123','shivaji123@gmail.com','9999999999')
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji456','shivaji456@gmail.com','9876543210')
SELECT * FROM [dbo].Customer


INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','10','200','kphb','Hyderabad','plot no 101, vivekanandaNagar','500081')
INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','40','600','HMT HILLS','Hyderabad','plot no 404, BaghyaNagar','500072')
INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','80','90','DSNR','Hyderabad','plot no 202, DilsukhNagar','500068')

INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Electrician')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE NAME='Requested'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL)
SELECT * FROM [dbo].[ORDER]

INSERT INTO [dbo].VENDOR_RATING values((select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra'),
2,2,3,1,
getdate(),
'Service is good', 'TASKO1000')

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

INSERT INTO [dbo].[CUSTOMER_FAVORITE_VENDOR] VALUES (NEWID(), (select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji'))

SELECT * FROM [dbo].[CUSTOMER_FAVORITE_VENDOR]