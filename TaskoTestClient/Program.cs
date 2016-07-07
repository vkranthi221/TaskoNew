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
            string orderId = "TASKO1000";
            string vendorId = "70F974CDC6E6664A898A8106C3D3D693";
            string venodorServiceId = "287EB41076025347AAE5EC48F79BCE15";
            //VendorData.GetVendor("3BCF0E621CC9FA45B644AD360D3B7E29");
            //Vendor updateVendor = new Vendor();
            //updateVendor.Id = "9919728A25404C4A8BE6858C02CC8577";
            //updateVendor.Name="test6";
            //updateVendor.MobileNumber ="0000000000";
            //updateVendor.Gender = 0;

            //VendorData.UpdateVendor(updateVendor);

            AdminData.GetServicesForVendor("AFB2B50F2164804C8E6D26A6C4A32982");
            Vendor vendor = new Vendor();
            //vendor.ActiveTimePerDay = "08:01:10.0800000";
            vendor.AddressDetails = new AddressInfo();
            vendor.AddressDetails.Address="test";
            vendor.AddressDetails.City ="Hyderabad";
            vendor.AddressDetails.Country = "India";
            vendor.AddressDetails.Lattitude ="1";
            vendor.AddressDetails.Locality = "KPHB";
            vendor.AddressDetails.Longitude ="2";
            vendor.AddressDetails.Pincode = "500072";
            vendor.AddressDetails.State ="TG";
            vendor.BaseRate = 1000;
            //vendor.CallsToCustomerCare =1;
            //vendor.DataConsumption=50;
            vendor.EmailAddress="test@gmail.com";
            vendor.IsVendorLive=true;
            vendor.IsVendorVerified=true;
            vendor.MobileNumber="9999999999";
            vendor.Name="Add Test3";
            vendor.NoOfEmployees=1000;
            vendor.Password="123456";
            vendor.Photo= null;
            //vendor.TimeSpentOnApp = "08:01:10.0800000";
            vendor.UserName="testuser3";
            vendor.VendorDetails = new VendorDetails();
            vendor.VendorDetails.AreOrdersBlocked = false;
            vendor.DateOfBirth= DateTime.Now.ToString();
            vendor.Gender=1;
            vendor.VendorDetails.IsBlocked=false;
            vendor.VendorDetails.IsPowerSeller=true;
            vendor.VendorDetails.MonthlyCharge=100;
            vendor.VendorServices= new List<ServicesForVendor>();
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "016685E608593F4BBF09875C208940B1", IsActive = true });
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "01B618DD27746D48ACAE77E8C7A083F2", IsActive = true });
            vendor.VendorServices.Add(new ServicesForVendor { ServiceId = "12A0AE40BAEFB140AB2F6BFC6CC5E5D8", IsActive = false });

            AdminData.AddVendor(vendor);
            //Console.WriteLine(VendorData.ValidateTokenCode("4B050B867497BD45B39827166EFBD176", "74AEA79F14C3BD49A528A2FC8D440D20"));
            //Console.WriteLine(VendorData.ValidateAuthCode("E77B16758EDBEB4995B678DB1143AD6C"));
            //Console.WriteLine(VendorData.Login("srikanth","12345","",1));
            CustomerData.AddCustomer("srikanth test", "srikanth@gmail.com", "99999");
            VendorData.ChangePassword("672438796A1D8F4190B50E95C0D133F6", "mchandu123","chandu");

            VendorData.UpdateOrderStatus("TASKO1000", 2, "not satisfied");

            VendorRating rating = new VendorRating();
            rating.ServiceQuality=1;
            rating.Punctuality =2;
            rating.Price =3;
            rating.Courtesy=4;
            rating.Comments ="The worest Vendor I have seen";

            CustomerData.AddVendorRating("TASKO1010", rating);

            Order recentOrder = CustomerData.GetRecentOrder("84402D36621CAB4482B1DDB3C208155A");

            CustomerData.AddCustomerAddress("84402D36621CAB4482B1DDB3C208155A", recentOrder.SourceAddress);

            CustomerData.UpdateCustomerAddress(recentOrder.SourceAddress);

            CustomerData.DeleteCustomerAddress("84402D36621CAB4482B1DDB3C208155A", "71C9213018D3BB42BC10FB151F474A7D");

            CustomerData.GetCustomerAddresses("84402D36621CAB4482B1DDB3C208155A");

            CustomerData.GetCustomerOrders("7A01099FDD26A04AAB76789E2E1DB435", 1, 1, 10);

            CustomerData.ConfirmOrder(recentOrder);

            CustomerData.GetServices();

            CustomerData.GetServiceVendors("ECBDFEAEBDBE7B429AC7E74C488B52C2","");

            /// Get Order Details
            Order objOrder = CustomerData.GetOrderDetails(orderId);
            if (objOrder != null)
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
                ////Console.WriteLine("Address : " + objVendor.Address);
                //Console.WriteLine("DataConsumption : " + objVendor.DataConsumption);
                //Console.WriteLine("CallsToCustomerCare : " + objVendor.CallsToCustomerCare);
                Console.WriteLine("IsVendorVerified : " + objVendor.IsVendorVerified);
                Console.WriteLine("NoOfEmployees : " + objVendor.NoOfEmployees);
                //Console.WriteLine("ActiveTimePerDay : " + objVendor.ActiveTimePerDay);
                //Console.WriteLine("TimeSpentOnApp : " + objVendor.TimeSpentOnApp);
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
