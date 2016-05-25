﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasko.Model;
using Tasko.Repository;

namespace TaskoTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string orderId = "TASKO1000";
            string vendorId = "70F974CDC6E6664A898A8106C3D3D693";
            string venodorServiceId = "287EB41076025347AAE5EC48F79BCE15";
            
            //Console.WriteLine(VendorData.ValidateTokenCode("4B050B867497BD45B39827166EFBD176", "74AEA79F14C3BD49A528A2FC8D440D20"));
            //Console.WriteLine(VendorData.ValidateAuthCode("E77B16758EDBEB4995B678DB1143AD6C"));
            //Console.WriteLine(VendorData.Login("srikanth","12345","",1));

            //VendorData.GetVendorServices("42EAE0A85586BA48B6D81CEB61A98324");

           Order recentOrder = CustomerData.GetRecentOrder("7A01099FDD26A04AAB76789E2E1DB435");
            
           CustomerData.ConfirmOrder(recentOrder);

            CustomerData.GetServices();

            CustomerData.GetServiceVendors("ECBDFEAEBDBE7B429AC7E74C488B52C2");

            /// Get Order Details
            Order objOrder = CustomerData.GetOrderDetails(orderId);
            if(objOrder!=null)
            {
                Console.WriteLine("***********Get Order Details***********");
                Console.WriteLine("OrderId : " + objOrder.OrderId);
                Console.WriteLine("CustomerId : " + objOrder.CustomerId);
                Console.WriteLine("CustomerName : " + objOrder.CustomerName);
                Console.WriteLine("VendorServiceId : " + objOrder.VendorServiceId);
                Console.WriteLine("VendorId : " + objOrder.VendorId);
                Console.WriteLine("VendorName : " + objOrder.VendorName);
                Console.WriteLine("ServiceId : " + objOrder.ServiceId);
                Console.WriteLine("ServiceName : " + objOrder.ServiceName);
                Console.WriteLine("OrderStatusId : " + objOrder.OrderStatusId);
                Console.WriteLine("OrderStatus : " + objOrder.OrderStatus);
                Console.WriteLine("RequestedDate : " + objOrder.RequestedDate);
                Console.WriteLine("Location : " + objOrder.Location);                
                Console.ReadLine();
            }

            //// GetVendor details
            Vendor objVendor = VendorData.GetVendor(vendorId);
            if (objVendor != null)
            {
                Console.WriteLine("***********Get Vendor Details***********");
                Console.WriteLine("Id : " + objVendor.Id);
                Console.WriteLine("Name : " + objVendor.Name);
                Console.WriteLine("MobileNumber : " + objVendor.MobileNumber);
                Console.WriteLine("BaseRate : " + objVendor.BaseRate);
                Console.WriteLine("IsVendorLive : " + objVendor.IsVendorLive);
                Console.WriteLine("Address : " + objVendor.Address);
                Console.WriteLine("DataConsumption : " + objVendor.DataConsumption);
                Console.WriteLine("CallsToCustomerCare : " + objVendor.CallsToCustomerCare);
                Console.WriteLine("IsVendorVerified : " + objVendor.IsVendorVerified);
                Console.WriteLine("NoOfEmployees : " + objVendor.NoOfEmployees);
                Console.WriteLine("ActiveTimePerDay : " + objVendor.ActiveTimePerDay);
                Console.WriteLine("TimeSpentOnApp : " + objVendor.TimeSpentOnApp);                
                Console.ReadLine();
            }

            //// Get vendor Services
            List<VendorService> vendorServices = VendorData.GetVendorServices(vendorId);
            Console.WriteLine("***********Get Vendor Services*********** : ");
            foreach (VendorService service in vendorServices)
            {
                Console.WriteLine("Id : " + service.Id);
                Console.WriteLine("Name : " + service.Name);
                Console.WriteLine("IsLive : " + service.IsActive);
            }

            Console.ReadLine();

            //// Get vendor Services            
            List<VendorService> vendorSubServices = VendorData.GetVendorSubServices(venodorServiceId);
            Console.WriteLine("***********Get Vendor Sub Services*********** : ");
            foreach (VendorService service in vendorSubServices)
            {
                Console.WriteLine("Id : " + service.Id);
                Console.WriteLine("Name : " + service.Name);
                Console.WriteLine("IsLive : " + service.IsActive);
            }

            Console.ReadLine();
        }
    }
}
