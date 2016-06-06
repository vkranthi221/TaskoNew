using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel.Web;
using Tasko.Interfaces;
using Tasko.Model;
using Tasko.Repository;

namespace Tasko.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class VendorAppService : IVendorAppService
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
                WebHeaderCollection headers = request.Headers;
                string appId = headers["X-APIKey"];
                if (appId == ConfigurationManager.AppSettings["VendorAppId"])
                {
                    string authCode = string.Empty;
                    authCode = VendorData.InsertAuthCode();
                    r.Error = false;
                    r.Message = "Authentication Successful";
                    r.Status = 200;
                    r.Data = authCode;
                }
                else
                {
                    r.Message = "Authentication failed";
                    r.Error = true;
                }
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
                LoginInfo loginInfo = null;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode))
                {
                    loginInfo = VendorData.Login(username, password, mobilenumber, userType); // 1 is vendor
                    if (loginInfo == null)
                    {
                        r.Message = "Invalid Credentials";
                    }
                }
                else
                {
                    r.Message = "Invalid AuthCode";
                }

                if (loginInfo != null)
                {
                    r.Error = false;
                    r.Message = "Login Successful";
                    r.Status = 200;
                    r.Data = loginInfo;
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
        /// <param name="Comments"></param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response UpdateOrderStatus(string orderId, short orderStatus, string Comments)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                try
                {
                    if (isTokenValid)
                    {
                        VendorData.UpdateOrderStatus(orderId, orderStatus, Comments);
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
                    List<OrderSummary> objOrders = VendorData.GetVendorOrders(vendorId, orderStatusId, pageNumber, recordsPerPage);

                    if (objOrders != null && objOrders.Count > 0)
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
        /// Changes the password.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response ChangePassword(string vendorId, string password)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    VendorData.ChangePassword(vendorId, password);
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
            catch (Exception ex)
            {
                r.Error = true;
                r.Status = 400;
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
