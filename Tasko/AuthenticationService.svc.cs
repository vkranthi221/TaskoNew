using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tasko.Common;
using Tasko.Model;
using Tasko.BL;
using Tasko.Repository;

namespace Tasko
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        private static string AppId = "E90D7ECB-2935-419D-B04B-E3436FC6537A";
        private static string TokenId = "";
        private static User user = new User() { UserName = "krishnag", PassWord = "admin123", Name = "Krishna", Id = "1000", MobileNumber = "9738349780" };
        public Response GetToken()
        {
            Response r = new Response();
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string appId = headers["X-APIKey"];
            if (appId == AppId)
            {
                TokenId = Guid.NewGuid().ToString();
                r.Error = false;
                r.Message = "Authentication Successful";
                r.Status = 200;
                r.Data = TokenId;
            }
            else
            {
                r.Error = true;
                r.Message = "Invalid Api Id";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="mobilenumber">The mobilenumber.</param>
        /// <returns>Response Object</returns>
        public Response Login(string username, string password, string mobilenumber)
        {
            Response r = new Response();
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string token = headers["X-APIToken"];
            if (token == TokenId&& (user.UserName==username || user.MobileNumber == mobilenumber) && user.PassWord==password)
            {
                r.Error = false;
                r.Message = "Login Successful";
                r.Status = 200;
                r.Data = user.Id;
            }
            else
            {
                r.Error = true;
                r.Message = "Invalid Credentials";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetUserDetails(string id)
        {
            Response r = new Response();
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string token = headers["X-APIToken"];
            if (token == TokenId && user.Id == id )
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = user;
            }
            else
            {
                r.Error = true;
                r.Message = "User not found";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the vendor details.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorDetails(string vendorId)
        {
            Response r = new Response();

            Vendor objVendor = VendorData.GetVendor(vendorId);

            if (objVendor != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = objVendor;
            }
            else
            {
                r.Error = true;
                r.Message = "Vendor not found";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetOrderDetails(string orderId)
        {
            Response r = new Response();

            Order objOrder = VendorData.GetOrderDetails(orderId);

            if (objOrder != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = objOrder;
            }
            else
            {
                r.Error = true;
                r.Message = "Order not found";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the vendor services.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorServices(string vendorId)
        {
            Response r = new Response();

            List<VendorService> vendorServices = VendorData.GetVendorServices(vendorId);

            if (vendorServices != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = vendorServices;
            }
            else
            {
                r.Error = true;
                r.Message = "No services available";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the vendor sub services.
        /// </summary>
        /// <param name="vendorServiceId">The vendor service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorSubServices(string vendorServiceId)
        {
            Response r = new Response();

            List<VendorService> vendorSubServices = VendorData.GetVendorSubServices(vendorServiceId);

            if (vendorSubServices != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = vendorSubServices;
            }
            else
            {
                r.Error = true;
                r.Message = "No services available";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderStatus">The order status.</param>
        /// <returns>Response Object</returns>
        public Response UpdateOrderStatus(string orderId, short orderStatus)
        {
            Response r = new Response();

            try
            {
                VendorData.UpdateOrderStatus(orderId, orderStatus);

                r.Error = false;
                r.Message = "success";
                r.Status = 200;
            }
            catch
            {
                r.Error = true;
                r.Message = "Error on updating OrderStatus";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Updates the vendor services.
        /// </summary>
        /// <param name="vendorServices">The vendor services.</param>
        /// <returns>Response Object</returns>
        public Response UpdateVendorServices(List<VendorService> vendorServices)
        {
            Response r = new Response();

            try
            {
                VendorData.UpdateVendorServices(vendorServices);

                r.Error = false;
                r.Message = "success";
                r.Status = 200;
            }
            catch
            {
                r.Error = true;
                r.Message = "Error on updating Vendor Services";
                r.Status = 400;
            }

            return r;
        }
    }
}
