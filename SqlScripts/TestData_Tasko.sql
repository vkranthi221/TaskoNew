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

INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','10','200','kphb','Hyderabad','plot no 101, vivekanandaNagar','500081', 'Home')
INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','40','600','HMT HILLS','Hyderabad','plot no 404, BaghyaNagar','500072' , 'Home')
INSERT INTO [dbo].[ADDRESS] VALUES(newId(),'India','Telangana','80','90','DSNR','Hyderabad','plot no 202, DilsukhNagar','500068' , 'Office')

------------ Vendor TestData -----------
--  VendorId Should be binary not int,
--  Name and Number should be unique, 
--  mobile number should not be varchar(max) change it to nVarchar(10)
  

INSERT INTO [dbo].[Vendor] values(NEWID(),'chandra','chandra','9985466195','12345','mchandu123@gmail.com',(select ADDRESS_ID from [dbo].[ADDRESS] WHERE LOCALITY='kphb'),null,10,50.00,1,1,Getdate(),Getdate(),10.00,123,
GETDATE(), 0,0,0,300,1,GETDATE(), null,'chandu','10 years', null)
INSERT INTO [dbo].[Vendor] values(NEWID(),'srikanth','Srikanth','1234567890','12345','sree@gmail.com',(select ADDRESS_ID from [dbo].[ADDRESS] WHERE LOCALITY='HMT HILLS'),null,10,100.00,1,1,Getdate(),Getdate(),10.00,123,
GETDATE(), 0,0,0,300,1,GETDATE(), null,'sri','9 years', null)
SELECT * FROM [dbo].[Vendor]


INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Electrician'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='Srikanth'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Microwave Service'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='Carpentry'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='AC Service'),1)
INSERT INTO [dbo].VENDOR_SERVICES values(newId(),(select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(select Service_Id from [dbo].[SERVICES] WHERE NAME='AC Installation'),1)
SELECT * FROM [dbo].VENDOR_SERVICES

INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji','shivaji@gmail.com','1234567890', 1)
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji123','shivaji123@gmail.com','9999999999',1)
INSERT INTO [dbo].CUSTOMER values(newid(),'Shivaji456','shivaji456@gmail.com','9876543210',1)
SELECT * FROM [dbo].Customer

INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Electrician')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL, 100,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,150,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL,200,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,250,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,300,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,350,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL,400,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,450,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,500,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='DSNR'),(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),NULL,550,null,null,null)
INSERT INTO [dbo].[ORDER] values(dbo.GenerateOrderID(),(select VENDOR_SERVICE_ID from [dbo].VENDOR_SERVICES where VENDOR_ID in (select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth') AND SERVICE_ID IN (SELECT SERVICE_ID FROM [dbo].[SERVICES] WHERE NAME='Microwave Service')) ,(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji123'),Getdate(),(SELECT ORDER_STATUS_Id FROM [dbo].ORDER_STATUS WHERE order_status_id='1'),'kphb',(SELECT address_ID FROM [dbo].Address WHERE Locality='kphb'),(SELECT address_ID FROM [dbo].Address WHERE Locality='HMT HILLS'),NULL,600,null,null,null)
SELECT * FROM [dbo].[ORDER]

INSERT INTO [dbo].VENDOR_RATING values(newid(),
2,2,3,1,
getdate(),
'Service is good', 'TASKO1000', (select VENDOR_ID from [dbo].Vendor WHERE NAME='chandra'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1001'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
2,2,2,2,
getdate(),
'Service is not provided in time', ('TASKO1002'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1003'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,1,1,1,
getdate(),
'Service is not provided in time', ('TASKO1004'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
3,3,3,3,
getdate(),
'Service is provided in time', ('TASKO1005'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
4,4,4,4,
getdate(),
'Service is provided in time', ('TASKO1006'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
5,5,5,5,
getdate(),
'Service is not provided in time', ('TASKO1007'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
1,2,3,4,
getdate(),
'Service is not provided in time', ('TASKO1008'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
2,2,3,4,
getdate(),
'Service is in time', ('TASKO1009'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)

INSERT INTO [dbo].VENDOR_RATING values(newId(),
5,1,3,4,
getdate(),
'Service is Good', ('TASKO1010'),(select VENDOR_ID from [dbo].Vendor WHERE NAME='Srikanth'), (select CUSTOMER_ID from [dbo].CUSTOMER WHERE NAME='Shivaji123'), 500)
SELECT * FROM [dbo].VENDOR_RATING

INSERT INTO [dbo].CUSTOMER_RATING VALUES((SELECT CUSTOMER_ID FROM [dbo].[ORDER] WHERE CUSTOMER_ID IN (SELECT CUSTOMER_ID FROM [dbo].Customer WHERE NAME='Shivaji')),(SELECT ORDER_ID FROM [dbo].[order] WHERE CUSTOMER_ID IN(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji')),4,'Good Customer')
SELECT * FROM [dbo].CUSTOMER_RATING

INSERT INTO [dbo].[CUSTOMER_FAVORITE_VENDOR] VALUES (NEWID(), (select Vendor_Id from [dbo].Vendor WHERE NAME='chandra'),(SELECT CUSTOMER_ID FROM [dbo].CUSTOMER WHERE NAME='Shivaji'))

SELECT * FROM [dbo].[CUSTOMER_FAVORITE_VENDOR]