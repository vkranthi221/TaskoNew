using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tasko.Interfaces;
using Tasko.Model;
using Tasko.Repository;

namespace Tasko.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
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
                    objOrder = CustomerData.GetOrderDetails(orderId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (objOrder != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = objOrder;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.ORDER_NOT_FOUND;
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
        /// Gets the recent order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public Response GetRecentOrder(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                Order objOrder = null;
                if (isTokenValid)
                {
                    objOrder = CustomerData.GetRecentOrder(customerId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (objOrder != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = objOrder;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.ORDER_NOT_FOUND;
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
        /// Gets the services.
        /// </summary>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetServices()
        {
            Response r = new Response();
            try
            {
                List<Service> services = CustomerData.GetServices();

                if (services != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = services;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.SERVICES_NOT_FOUND;
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
        /// Gets the service vendors.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetServiceVendors(string serviceId, string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                List<ServiceVendor> services = null;
                if (isTokenValid)
                {
                    services = CustomerData.GetServiceVendors(serviceId, customerId);
                }

                if (services != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = services;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.VENDORS_NOT_FOUND;
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
        /// Confirms the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response ConfirmOrder(Order order)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                string OrderId = string.Empty;
                if (isTokenValid)
                {
                    OrderId = CustomerData.ConfirmOrder(order);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (!string.IsNullOrEmpty(OrderId))
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = "OrderId: " + OrderId;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.ORDER_NOT_CONFIRMED;
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
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response UpdateCustomer(Customer customer)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.UpdateCustomer(customer);

                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
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
        /// Gets the customer orders.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderStatus">The order status.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetCustomerOrders(string customerId, int orderStatus, int pageNumber, int recordsPerPage)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                List<OrderSummary> orderSummary = null;
                if (isTokenValid)
                {
                    orderSummary = CustomerData.GetCustomerOrders(customerId, orderStatus, pageNumber, recordsPerPage);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (orderSummary != null && orderSummary.Count > 0)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = orderSummary;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.ORDERS_NOT_FOUND;
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
        /// Adds the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressInfo">The address information.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response AddCustomerAddress(string customerId, AddressInfo addressInfo)
        {
            Response r = new Response();
            try
            {
                if (addressInfo != null && !string.IsNullOrEmpty(customerId))
                {
                    bool isTokenValid = ValidateToken();
                    if (isTokenValid)
                    {
                        CustomerData.AddCustomerAddress(customerId, addressInfo);
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    }
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.INVALID_DATA;
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
        /// Updates the customer address.
        /// </summary>
        /// <param name="addressInfo">The address information.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response UpdateCustomerAddress(AddressInfo addressInfo)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.UpdateCustomerAddress(addressInfo);
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
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
        /// Deletes the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response DeleteCustomerAddress(string customerId, string addressId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.DeleteCustomerAddress(customerId, addressId);
                    r.Message = CommonMessages.SUCCESS;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Gets the customer addresses.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetCustomerAddresses(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                List<AddressInfo> customerAddresses = null;
                if (isTokenValid)
                {
                    customerAddresses = CustomerData.GetCustomerAddresses(customerId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (customerAddresses != null && customerAddresses.Count > 0)
                {
                    r.Message = CommonMessages.SUCCESS;
                    r.Data = customerAddresses;
                }
                else
                {
                    r.Message = CommonMessages.CUSTOMER_ADDRESS_NOT_FOUND;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Adds the vendor rating.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="vendorRating">The vendor rating.</param>
        /// <returns>Response Object</returns>
        public Response AddVendorRating(string orderId, VendorRating vendorRating)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.AddVendorRating(orderId, vendorRating);
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
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
        /// Sets the vendor as favorite vendor for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response SetFavoriteVendor(string customerId, string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.SetFavoriteVendor(customerId, vendorId);
                    r.Message = CommonMessages.SUCCESS;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Gets the favorite vendors for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetFavoriteVendors(string customerId)
        {
            List<FavoriteVendor> favoriteVendors = new List<FavoriteVendor>();
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    favoriteVendors = CustomerData.GetFavoriteVendors(customerId);
                    r.Message = CommonMessages.SUCCESS;
                    r.Data = favoriteVendors;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Generates the otp.
        /// </summary>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Response Object</returns>
        public Response GenerateOTP(string emailId, string phoneNumber)
        {
            Response r = new Response();
            try
            {
                r.Message = CommonMessages.ERROR_GENERATING_OTP;
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, false))
                {
                    string otp = InternalGetOTP(phoneNumber);
                    if (!string.IsNullOrEmpty(otp))
                    {
                        CustomerData.InsertOTPDetails(otp, phoneNumber, emailId);
                    }

                    r.Message = CommonMessages.SUCCESS;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Validates the otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <returns>Response Object</returns>
        public Response ValidateOTP(string phoneNumber, string OTP)
        {
            Response r = new Response();
            try
            {
                r.Message = CommonMessages.ERROR_VALIDATING_OTP;
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, false))
                {
                    if (CustomerData.ValidateOTP(phoneNumber, OTP))
                    {
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_OTP;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Signs up.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Response Object</returns>
        public Response SignUp(string name, string emailId, string phoneNumber)
        {
            // Add Customer
            Response r = new Response();
            try
            {
                r.Message = CommonMessages.ERROR_ADDING_CUSTOMER;
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, true))
                {
                    LoginInfo loginInfo = CustomerData.AddCustomer(name, emailId, phoneNumber);
                    r.Data = loginInfo;
                    r.Message = CommonMessages.SUCCESS;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                r.Error = false;
                r.Status = 200;
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
        /// Logins the user.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <returns>Response Object</returns>
        public Response Login(string phoneNumber, string OTP)
        {
            // return customr id after login
            Response r = new Response();
            bool isValid = false;
            try
            {
                r.Message = "Error In Logon. Invalid Phone Number Or OTP";
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, true))
                {
                    LoginInfo loginInfo = CustomerData.LoginValidateOTP(phoneNumber, OTP, ref isValid);
                    r.Data = loginInfo;
                    if (isValid)
                    {
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Message = "Invalid Phone Number Or OTP";
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                r.Error = false;
                r.Status = 200;
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
                if (appId == ConfigurationManager.AppSettings["AppId"])
                {
                    string authCode = string.Empty;
                    authCode = VendorData.InsertAuthCode();
                    r.Error = false;
                    r.Message = CommonMessages.AUTHENTICATION_SUCCESSFULL;
                    r.Status = 200;
                    r.Data = authCode;
                }
                else
                {
                    r.Message = CommonMessages.AUTHENTICATION_FAILED;
                    r.Error = true;
                }
            }
            catch (Exception ex)
            {
                r.Message = CommonMessages.AUTHENTICATION_FAILED;
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };

            }
            return r;
        }

        #region Private Methods
        /// <summary>
        /// Internals the get otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Gets the OTP</returns>
        private string InternalGetOTP(string phoneNumber)
        {
            string otp = InternalGenerateOTP(phoneNumber);
            string sURL = "http://www.metamorphsystems.com/index.php/api/bulk-sms?username=" + "taskoapp" + "&password=" + "Apple123" +
                            "&from=" + "TTASKO" + "&to=" + phoneNumber + "&message=" + "Your OTP is "+ otp + "&sms_type=" + 2;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Method = "POST";
            request.AllowWriteStreamBuffering = true;
            CredentialCache.DefaultNetworkCredentials.UserName = "taskoapp";
            CredentialCache.DefaultNetworkCredentials.Password = "Apple123";
            CredentialCache.DefaultNetworkCredentials.Domain = "http://www.metamorphsystems.com";
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            catch
            {
                return string.Empty;
            }

            return otp;
        }

        /// <summary>
        /// Internals the generate otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Returns OTP</returns>
        private string InternalGenerateOTP(string phoneNumber)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string otp = string.Empty;
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                otp += chars[random.Next(chars.Length)];
            }

            return otp;
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
            if (!string.IsNullOrEmpty(tokenCode) && !string.IsNullOrEmpty(userId))
            {
                bool isTokenValid = VendorData.ValidateTokenCode(tokenCode, userId);
                return isTokenValid;
            }

            return false;
        }
        #endregion
    }
}
