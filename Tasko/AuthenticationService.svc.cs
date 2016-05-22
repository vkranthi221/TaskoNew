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
using System.ServiceModel.Channels;

namespace Tasko
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Gets the uthCode.
        /// </summary>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetAuthCode()
        {
            Response r = new Response();
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                string authCode = string.Empty;
                authCode = VendorData.InsertAuthCode();
                r.Error = false;
                r.Message = "Authentication Successful";
                r.Status = 200;
                r.Data = authCode;

            }
            catch (Exception ex)
            {
                r.Message = "Authentication failed";
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };

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
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string token = string.Empty;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode))
                {
                    if (VendorData.ValidateAuthCode(authCode))
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

                if (!string.IsNullOrEmpty(token))
                {
                    r.Error = false;
                    r.Message = "Login Successful";
                    r.Status = 200;
                    r.Data = token;
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                }

            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };

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
            try
            {
                bool isTokenValid = ValidateToken();
                Vendor objVendor = null;
                if (isTokenValid)
                {
                    objVendor = VendorData.GetVendor(vendorId);
                }
                else
                {
                    r.Message = "Invalid AuthCode";
                }

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

            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
            try
            {
                bool isTokenValid = ValidateToken();
                Order objOrder = null;
                if (isTokenValid)
                {
                    objOrder = VendorData.GetOrderDetails(orderId);
                }
                else
                {
                    r.Message = "Invalid token code";
                }

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
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
            try
            {
                bool isTokenValid = ValidateToken();
                List<VendorService> vendorServices = null;
                if (isTokenValid)
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
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
            try
            {
                bool isTokenValid = ValidateToken();
                List<VendorService> vendorSubServices = null;
                if (isTokenValid)
                {
                    vendorSubServices = VendorData.GetVendorSubServices(vendorServiceId);
                }
                else
                {
                    r.Message = "Invalid token code";
                }

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
                    r.Message = "No sub services available";
                    r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
                bool isTokenValid = ValidateToken();
                try
                {
                    if (isTokenValid)
                    {
                        VendorData.UpdateOrderStatus(orderId, orderStatus);
                        r.Error = false;
                        r.Message = "success";
                        r.Status = 200;
                    }
                    else
                    {
                        r.Message = "Invalid token code";
                        r.Error = true;
                        r.Status = 400;
                    }
                }
                catch
                {
                    r.Error = true;
                    r.Message = "Error on updating OrderStatus";
                    r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    VendorData.UpdateVendorServices(vendorServices);

                    r.Error = false;
                    r.Message = "success";
                    r.Status = 200;
                }
                else
                {
                    r.Message = "Invalid token code";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch(Exception ex)
            {
                r.Error = true;
                r.Message = "Error on updating Vendor Services";
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
                 bool isTokenValid = ValidateToken();
                 if (isTokenValid)
                 {
                     VendorData.UpdateVendorBaseRate(vendorId, baseRate);

                     r.Error = false;
                     r.Message = "success";
                     r.Status = 200;
                 }
                 else
                 {
                     r.Message = "Invalid token code";
                     r.Error = true;
                     r.Status = 400;
                 }
            }
            catch(Exception ex)
            {
                r.Error = true;
                r.Message = "Error on updating Vendor Base Rate";
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
                r.Status = 400;
            }


            return r;
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <returns>Response</returns>
        public Response Logout()
        {
            Response r = new Response();
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string tokenCode = headers["Token_Code"];
                string userId = headers["User_Id"];
                bool isTokenValid = VendorData.ValidateTokenCode(tokenCode, userId);
                if (isTokenValid)
                {
                    VendorData.Logout(userId, tokenCode);

                    r.Error = false;
                    r.Message = "success";
                    r.Status = 200;
                }
                else
                {
                    r.Message = "Invalid token code";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch(Exception ex)
            {
                r.Error = true;
                r.Message = "Error on logout";
                r.Status = 400;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
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
                }
                else
                {
                    r.Message = "Invalid token code";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
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
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
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
                }
                else
                {
                    r.Message = "Invalid token code";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }
            return r;
        }

        /// <summary>
        /// Gets the Vendor orders
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="orderStatusId">The order status id.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">records per page.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetVendorOrders(string vendorId, int orderStatusId, int pageNumber, int recordsPerPage)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<Order> objOrders = VendorData.GetVendorOrders(vendorId, orderStatusId, pageNumber, recordsPerPage);

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
                        r.Message = "No orders for vendor";
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = "Invalid token code";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch(Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }
            return r;
        }

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <returns>bool value</returns>
        private static bool ValidateToken()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string tokenCode = headers["Token_Code"];
            string userId = headers["User_Id"];
            bool isTokenValid = VendorData.ValidateTokenCode(tokenCode, userId);
            return isTokenValid;
        }
    }


}
