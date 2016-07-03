---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 
    
-------- Services TestData --------------
INSERT INTO [dbo].[Services] values(NEWID(),'Electrician',null,'http://api.tasko.in/serviceimages/electrician.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Microwave Service',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Refrigerator Service',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Pest Control',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Carpentry',null,'http://api.tasko.in/serviceimages/carpenter.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Water Purifier Installtion',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'House Cleaning',null,'http://api.tasko.in/serviceimages/house_services.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'AC Installation',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Fully Automatic Washing Machine Service',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'AC Service',null,'http://api.tasko.in/serviceimages/ac_services.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Semi-Automatic Washing Machine Service',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Bike Service',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Mixer Grinder Repair',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Water Purifier Service',null,null,0)
INSERT INTO [dbo].[Services] values(newid(), 'Plumber',null, 'http://api.tasko.in/serviceimages/plumber.png',0)

SELECT * FROM [dbo].[Services]
  
------------ ID Proof TestData -----------
INSERT INTO [dbo].[ID_PROOFS] values(NEWID(),'PAN Card')
INSERT INTO [dbo].[ID_PROOFS] values(NEWID(),'Passport')
INSERT INTO [dbo].[ID_PROOFS] values(NEWID(),'Aadhar Card')
INSERT INTO [dbo].[ID_PROOFS] values(NEWID(),'Voter Id')
SELECT * FROM [dbo].[ID_PROOFS]

----- Order Status TestData-----
INSERT INTO [dbo].[ORDER_STATUS] values(1, 'Requested')
INSERT INTO [dbo].[ORDER_STATUS] values(2, 'Pending')
INSERT INTO [dbo].[ORDER_STATUS] values(3, 'Accepted')
INSERT INTO [dbo].[ORDER_STATUS] values(4, 'Confirmed')
INSERT INTO [dbo].[ORDER_STATUS] values(5, 'Cancelled')
INSERT INTO [dbo].[ORDER_STATUS] values(6, 'Completed')
INSERT INTO [dbo].[ORDER_STATUS] values(7, 'Cancelled By Vendor')
INSERT INTO [dbo].[ORDER_STATUS] values(8, 'Cancelled By Customer')
SELECT * FROM [dbo].[ORDER_STATUS]




  
