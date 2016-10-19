using System;
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
            //AddressInfo addresss = new AddressInfo();
            //addresss.Address = "sdfsdf";
            //addresss.AddressType = "";
            //addresss.City = "hyderabad";
            //addresss.Country = "india";
            //addresss.Lattitude = "0";
            //addresss.Locality = "kphb";
            //addresss.Longitude = "0";
            //addresss.Pincode = "500072";
            //addresss.State = "telangana";
            //VendorData.UpdateVendorLocation(addresss, "6BF4DA7780B4C246A9846F969724C489");
            //CustomerData.GetRecentOrder("D6B65F64F3CFA844BF63D84E3C9B7E13");
            //AdminData.GetVendorOverview("604A0A4E8AB86945AB3CE54B9EDCBCE4");
            //CustomerData.Test("17.3850440", "78.4866710");
           //CustomerData.GetDistance("16.4375", "78.4483", "17.4948", "78.3996", new MessageDetail());
            //CustomerData.GetServiceVendors("2D0D8369F97C7E4D9757F4F1BF39324C", "89F7C09690AEFA4AA080E077151B56D5");
            //CustomerData.SendNotification();
            //VendorData.UpdateOrderStatus("TASKO1000", 2, "");
          ////  AddressInfo addresss = new AddressInfo();
          ////  addresss.Address = "sdfsdf";
          ////  addresss.AddressType = "";
          ////  addresss.City = "hyderabad";
          ////  addresss.Country = "india";
          ////  addresss.Lattitude = "32";
          ////  addresss.Locality = "kphb";
          ////  addresss.Longitude = "43";
          ////  addresss.Pincode = "500072";
          ////  addresss.State = "telangana";
          ////string data=  CustomerData.AddAddress(addresss);
            //bool exists =CustomerData.isCustomerPhoneNumberExits("9490900444");
            //CustomerData.SendNotification();
            //string orderId = "TASKO1000";
            //string vendorId = "70F974CDC6E6664A898A8106C3D3D693";
            //string venodorServiceId = "287EB41076025347AAE5EC48F79BCE15";
            //CustomerData.InternalSendNotification("F3E6D9CBF8EF6A4289E1FC3509076D54", "AIzaSyAaUu7j8DMa83fkODSkDndR87Be2yBPhTg", "another-138523", "testvdvdfv");
            //AdminData.GetAllGCMUsers();
            //CustomerData.InternalSendNotification("F3E6D9CBF8EF6A4289E1FC3509076D54");
            //VendorData.GetVendor("3BCF0E621CC9FA45B644AD360D3B7E29");
            //Vendor updateVendor = new Vendor();
            //updateVendor.Id = "6BF4DA7780B4C246A9846F969724C489";
            //updateVendor.Name = "chandra test";
            //updateVendor.MobileNumber = "0000000000";
            //updateVendor.Gender = 0;
            //updateVendor.AddressDetails = new AddressInfo();
            //updateVendor.AddressDetails.Lattitude = "30.03";
            ////AdminData.InternalSendNotification("");
            ////            AdminData.GetVendorOverview("AFB2B50F2164804C8E6D26A6C4A32982");
            ////            AdminData.GetOrders(1);
            //VendorData.UpdateVendor(updateVendor);

            //            AdminData.GetServicesForVendor("AFB2B50F2164804C8E6D26A6C4A32982");
            Vendor vendor = new Vendor();
            //vendor.ActiveTimePerDay = "08:01:10.0800000";
            vendor.AddressDetails = new AddressInfo();
            vendor.AddressDetails.Address = "test";
            vendor.AddressDetails.City = "Hyderabad";
            vendor.AddressDetails.Country = "India";
            vendor.AddressDetails.Lattitude = "1";
            vendor.AddressDetails.Locality = "KPHB";
            vendor.AddressDetails.Longitude = "2";
            vendor.AddressDetails.Pincode = "500072";
            vendor.AddressDetails.State = "TG";
            vendor.BaseRate = 1000;
            vendor.FacebookUrl ="";
            vendor.EmailAddress = "test@gmail.com";
            vendor.IsVendorLive = true;
            vendor.IsVendorVerified = true;
            vendor.MobileNumber = "9999999999";
            vendor.Name = "Add Test3";
            vendor.NoOfEmployees = 1000;
            vendor.Password = "123456";
            vendor.Photo = string.Empty;
            //vendor.TimeSpentOnApp = "08:01:10.0800000";
            vendor.UserName = "testuser3";
            vendor.AreOrdersBlocked = false;
            vendor.DateOfBirth = DateTime.Now.ToString();
            vendor.Gender = 1;
            vendor.IsBlocked = false;
            vendor.IsPowerSeller = true;
            vendor.MonthlyCharge = 100;
            vendor.VendorServices = new List<ServicesForVendor>();
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "1FC70D5660D30B4399958C38CB8DB2DC", IsActive = true });
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "242CA522CF16284996EDFEF8DB74ED13", IsActive = true });
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "2C17790905B75D46BE3AB2652F2F6DF5", IsActive = false });

                       AdminData.AddVendor(vendor);
            //            //Console.WriteLine(VendorData.ValidateTokenCode("4B050B867497BD45B39827166EFBD176", "74AEA79F14C3BD49A528A2FC8D440D20"));
            //            //Console.WriteLine(VendorData.ValidateAuthCode("E77B16758EDBEB4995B678DB1143AD6C"));
            //            //Console.WriteLine(VendorData.Login("srikanth","12345","",1));
            //            CustomerData.AddCustomer("srikanth test", "srikanth@gmail.com", "99999");
            //            VendorData.ChangePassword("672438796A1D8F4190B50E95C0D133F6", "mchandu123","chandu");

            //            VendorData.UpdateOrderStatus("TASKO1000", 2, "not satisfied");

            //            VendorRating rating = new VendorRating();
            //            rating.ServiceQuality=1;
            //            rating.Punctuality =2;
            //            rating.Price =3;
            //            rating.Courtesy=4;
            //            rating.Comments ="The worest Vendor I have seen";

            //            CustomerData.AddVendorRating("TASKO1010", rating);

            //            Order recentOrder = CustomerData.GetRecentOrder("84402D36621CAB4482B1DDB3C208155A");

            //            CustomerData.AddCustomerAddress("84402D36621CAB4482B1DDB3C208155A", recentOrder.SourceAddress);

            //            CustomerData.UpdateCustomerAddress(recentOrder.SourceAddress);

            //            CustomerData.DeleteCustomerAddress("84402D36621CAB4482B1DDB3C208155A", "71C9213018D3BB42BC10FB151F474A7D");

            //            CustomerData.GetCustomerAddresses("84402D36621CAB4482B1DDB3C208155A");

            //            CustomerData.GetCustomerOrders("7A01099FDD26A04AAB76789E2E1DB435", 1, 1, 10);

            //            CustomerData.ConfirmOrder(recentOrder);

            //            CustomerData.GetServices();

            //            CustomerData.GetServiceVendors("ECBDFEAEBDBE7B429AC7E74C488B52C2","");

            //            /// Get Order Details
            //            Order objOrder = CustomerData.GetOrderDetails(orderId);
            //            if (objOrder != null)
            //            {
            //                Console.WriteLine("***********Get Order Details***********");
            //                Console.WriteLine("OrderId : " + objOrder.OrderId);
            //                Console.WriteLine("CustomerId : " + objOrder.CustomerId);
            //                Console.WriteLine("CustomerName : " + objOrder.CustomerName);
            //                Console.WriteLine("VendorServiceId : " + objOrder.VendorServiceId);
            //                Console.WriteLine("VendorId : " + objOrder.VendorId);
            //                Console.WriteLine("VendorName : " + objOrder.VendorName);
            //                Console.WriteLine("ServiceId : " + objOrder.ServiceId);
            //                Console.WriteLine("ServiceName : " + objOrder.ServiceName);
            //                Console.WriteLine("OrderStatusId : " + objOrder.OrderStatusId);
            //                Console.WriteLine("OrderStatus : " + objOrder.OrderStatus);
            //                Console.WriteLine("RequestedDate : " + objOrder.RequestedDate);
            //                Console.WriteLine("Location : " + objOrder.Location);
            //                Console.ReadLine();
            //            }

            //            //// GetVendor details
            //            Vendor objVendor = VendorData.GetVendor(vendorId);
            //            if (objVendor != null)
            //            {
            //                Console.WriteLine("***********Get Vendor Details***********");
            //                Console.WriteLine("Id : " + objVendor.Id);
            //                Console.WriteLine("Name : " + objVendor.Name);
            //                Console.WriteLine("MobileNumber : " + objVendor.MobileNumber);
            //                Console.WriteLine("BaseRate : " + objVendor.BaseRate);
            //                Console.WriteLine("IsVendorLive : " + objVendor.IsVendorLive);
            //                ////Console.WriteLine("Address : " + objVendor.Address);
            //                //Console.WriteLine("DataConsumption : " + objVendor.DataConsumption);
            //                //Console.WriteLine("CallsToCustomerCare : " + objVendor.CallsToCustomerCare);
            //                Console.WriteLine("IsVendorVerified : " + objVendor.IsVendorVerified);
            //                Console.WriteLine("NoOfEmployees : " + objVendor.NoOfEmployees);
            //                //Console.WriteLine("ActiveTimePerDay : " + objVendor.ActiveTimePerDay);
            //                //Console.WriteLine("TimeSpentOnApp : " + objVendor.TimeSpentOnApp);
            //                Console.ReadLine();
            //            }

            //            //// Get vendor Services
            //            List<VendorService> vendorServices = VendorData.GetVendorServices(vendorId);
            //            Console.WriteLine("***********Get Vendor Services*********** : ");
            //            foreach (VendorService service in vendorServices)
            //            {
            //                Console.WriteLine("Id : " + service.Id);
            //                Console.WriteLine("Name : " + service.Name);
            //                Console.WriteLine("IsLive : " + service.IsActive);
            //            }

            //            Console.ReadLine();

            //            //// Get vendor Services            
            //            List<VendorService> vendorSubServices = VendorData.GetVendorSubServices(venodorServiceId);
            //            Console.WriteLine("***********Get Vendor Sub Services*********** : ");
            //            foreach (VendorService service in vendorSubServices)
            //            {
            //                Console.WriteLine("Id : " + service.Id);
            //                Console.WriteLine("Name : " + service.Name);
            //                Console.WriteLine("IsLive : " + service.IsActive);
            //            }

            //            Console.ReadLine();
            //        }
            //    }
        }
    }
}
