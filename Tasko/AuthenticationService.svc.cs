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
        private static string AppId = "E90D7ECB2935419DB04BE3436FC6537A";
        private static string TokenId = "";
        private static User user = new User() { UserName = "krishnag", PassWord = "admin123", Name = "Krishna", Id = "1000", MobileNumber = "9738349780" };
        //public Response GetToken()
        //{
        //    Response r = new Response();
        //    IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
        //    WebHeaderCollection headers = request.Headers;
        //    string appId = headers["X-APIKey"];
        //    if (appId == AppId)
        //    {
        //        TokenId = Guid.NewGuid().ToString();
        //        r.Error = false;
        //        r.Message = "Authentication Successful";
        //        r.Status = 200;
        //        r.Data = TokenId;
        //    }
        //    else
        //    {
        //        r.Error = true;
        //        r.Message = "Invalid Api Id";
        //        r.Status = 400;
        //    }

        //    return r;
        //}

        public Response GetAuthCode()
        {
            Response r = new Response();
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string authCode = string.Empty;
            string appId = headers["X-APIKey"];
            if (appId == AppId)
            {
                //authCode = Guid.NewGuid().ToString();
                authCode  = VendorData.InsertAuthCode();
                r.Error = false;
                r.Message = "Authentication Successful";
                r.Status = 200;
                r.Data = authCode;
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
        public Response Login(string username, string password, string mobilenumber, Int16 userType)
        {
            
            Response r = new Response();
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string token = string.Empty;
            //string authCode = string.Empty;
            string authCode = headers["Auth_Code"];
            //IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            //WebHeaderCollection headers = request.Headers;
            //string token = headers["X-APIToken"];
            if (!string.IsNullOrEmpty(authCode))
            {
                if (VendorData.ValidateAuthCode(authCode) == true)
                    token = VendorData.Login(username, password, mobilenumber, userType); // 1 is vendor
                if (string.IsNullOrEmpty(token))
                {
                    r.Message = "Invalid Credentials";
                }
            }
            else
            {
                r.Message = "Invalid AuthCode";
            }


            //string Token = VendorData.Login(username, password, mobilenumber, userType); // 1 is vendor
            //if (token == TokenId&& (user.UserName==username || user.MobileNumber == mobilenumber) && user.PassWord==password)
            //{
            //    r.Error = false;
            //    r.Message = "Login Successful";
            //    r.Status = 200;
            //    r.Data = user.Id;
            //}
            //else
            //{
            //    r.Error = true;
            //    r.Message = "Invalid Credentials";
            //    r.Status = 400;
            //}

            if (!string.IsNullOrEmpty(token))
            {
                r.Error = false;
                r.Message = "Login Successful";
                r.Status = 200;
                r.Data = authCode;
            }
            else
            {
                r.Error = true;
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
            if (token == TokenId && user.Id == id)
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
            r.Message = "Vendor not found";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            Vendor objVendor = null;
            if (VendorData.ValidateTokenCode(tokenCode, userId))
            {
                objVendor = VendorData.GetVendor(vendorId);
            }
            else 
            {
                r.Message = "Invalid AuthCode";
            }
            //Vendor objVendor = VendorData.GetVendor(vendorId);

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
                //r.Message = "Vendor not found";
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
            r.Message = "Order not found";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            Order objOrder = null;
            if (VendorData.ValidateTokenCode(tokenCode, userId))
            {
                objOrder = VendorData.GetOrderDetails(orderId);
            }
            else 
            {
                r.Message = "Invalid token code";
            }

            //Order objOrder = VendorData.GetOrderDetails(orderId);

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
            r.Message = "No services available";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            List<VendorService> vendorServices = null;
            if (VendorData.ValidateTokenCode(tokenCode, userId))
            {
                vendorServices = VendorData.GetVendorServices(vendorId);
            }
            else
            {
                r.Message = "Invalid token code";
            }

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
            r.Message = "No services available";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            List<VendorService> vendorSubServices = null;
            if(VendorData.ValidateTokenCode(tokenCode, userId))
            {
                 vendorSubServices = VendorData.GetVendorSubServices(vendorServiceId);
            }
            else
            {
                r.Message = "Invalid token code";
            }
            //List<VendorService> vendorSubServices = VendorData.GetVendorSubServices(vendorServiceId);

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
                //r.Message = "No services available";
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
            r.Message = "Error on updating OrderStatus";
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];

            try
            {
                if (VendorData.ValidateTokenCode(tokenCode, userId))
                {
                    VendorData.UpdateOrderStatus(orderId, orderStatus);
                }
                else
                {
                    r.Message = "Invalid token code";
                }

                r.Error = false;
                r.Message = "success";
                r.Status = 200;
            }
            catch
            {
                r.Error = true;
                //r.Message = "Error on updating OrderStatus";
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

        /// <summary>
        /// Updates the vendor base rate.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="baseRate">The base rate.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response UpdateVendorBaseRate(string vendorId, double baseRate)
        {
            Response r = new Response();
            try
            {
                VendorData.UpdateVendorBaseRate(vendorId, baseRate);

                r.Error = false;
                r.Message = "success";
                r.Status = 200;
            }
            catch
            {
                r.Error = true;
                r.Message = "Error on updating Vendor Base Rate";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="authCode"></param>
        /// <returns>Response</returns>
        public Response Logout(string userId, string authCode)
        {
            Response r = new Response();
            try
            {
                VendorData.Logout(userId, authCode);

                r.Error = false;
                r.Message = "success";
                r.Status = 200;
            }
            catch
            {
                r.Error = true;
                r.Message = "Error on logout";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the Vendor Ratings
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetVendorRatings(string vendorId)
        {
            Response r = new Response();

            List<VendorRating> objVendorRatings = VendorData.GetVendorRatings(vendorId);

            if (objVendorRatings != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = objVendorRatings;
            }
            else
            {
                r.Error = true;
                r.Message = "No ratings for vendor";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the Vendor overall Ratings
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetVendorOverallRatings(string vendorId)
        {
            Response r = new Response();

            VendorOverallRating objVendorRatings = VendorData.GetVendorOverallRatings(vendorId);

            if (objVendorRatings != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = objVendorRatings;
            }
            else
            {
                r.Error = true;
                r.Message = "No ratings for vendor";
                r.Status = 400;
            }

            return r;
        }

        /// <summary>
        /// Gets the Vendor orders
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="orderStatusId">The order status id.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetVendorOrders(string vendorId, int orderStatusId)
        {
            Response r = new Response();

            List<Order> objOrders = VendorData.GetVendorOrders(vendorId, orderStatusId);

            if (objOrders != null)
            {
                r.Error = false;
                r.Message = "success";
                r.Status = 200;
                r.Data = objOrders;
            }
            else
            {
                r.Error = true;
                r.Message = "No ratings for vendor";
                r.Status = 400;
            }

            return r;
        }
    }


}
