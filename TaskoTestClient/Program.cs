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
