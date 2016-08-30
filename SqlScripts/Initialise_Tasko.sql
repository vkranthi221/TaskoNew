---------------------------------------------------------------------------------------------------------- 
--------------------------- All Copy Rights are reserved to Tasko.in-------------------------------------- 
USE [Tasko] 
GO 
---------------------------------------------------------------------------------------------------------- 
    
-------- Services TestData --------------
INSERT INTO [dbo].[Services] values(NEWID(),'Electrician',null,'http://api.tasko.in/serviceimages/electrician.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Microwave Service',null,'http://api.tasko.in/serviceimages/Microwave_Service.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Refrigerator Service',null,'http://api.tasko.in/serviceimages/Refrigerator_Service.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Pest Control',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'Carpentry',null,'http://api.tasko.in/serviceimages/carpenter.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Water Purifier Installtion',null,null,0)
INSERT INTO [dbo].[Services] values(NEWID(),'House Cleaning',null,'http://api.tasko.in/serviceimages/house_services.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'AC Installation',null,'http://api.tasko.in/serviceimages/ac_services.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Fully Automatic Washing Machine Service',null,'http://api.tasko.in/serviceimages/Washing_Machine_Service.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'AC Service',null,'http://api.tasko.in/serviceimages/ac_services.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Semi-Automatic Washing Machine Service',null,'http://api.tasko.in/serviceimages/Washing_Machine_Service.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Bike Service',null,'http://api.tasko.in/serviceimages/Bike_Service.png',0)
INSERT INTO [dbo].[Services] values(NEWID(),'Mixer Grinder Repair',null,'http://api.tasko.in/serviceimages/Mixer_Grinder_Repair.png',0)
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
INSERT INTO [dbo].[ORDER_STATUS] values(1, 'CustomerRequested')
INSERT INTO [dbo].[ORDER_STATUS] values(2, 'VendorAccepted')
INSERT INTO [dbo].[ORDER_STATUS] values(3, 'VendorRejected')
INSERT INTO [dbo].[ORDER_STATUS] values(4, 'CustomerAccepted')
INSERT INTO [dbo].[ORDER_STATUS] values(5, 'OrderCompleted')
INSERT INTO [dbo].[ORDER_STATUS] values(6, 'CustomerCancelled')
INSERT INTO [dbo].[ORDER_STATUS] values(7, 'VendorCancelled')
SELECT * FROM [dbo].[ORDER_STATUS]

INSERT INTO [dbo].[USER] VALUES(NEWID(),'admin','Administrator', 'admin', 'admin@Tasko.in', 1234567890,1,getdate(),1)


  
