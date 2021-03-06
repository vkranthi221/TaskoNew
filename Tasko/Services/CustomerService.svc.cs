using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using Tasko.Common;
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.ORDER_NOT_FOUND : r.Message;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.ORDER_NOT_FOUND : r.Message;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
        public Response GetServiceVendors(string serviceId, string customerId, string latitude, string longitude)
        {
            decimal distanceCovered = Convert.ToDecimal(ConfigurationManager.AppSettings["DistanceCovered"]);
            return GetServiceVendors(serviceId, customerId, latitude, longitude, distanceCovered, true);
        }

        /// <summary>
        /// Confirms the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response ConfirmOrder(Order order, bool? isOffline)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                string OrderId = string.Empty;
                string messageData = string.Empty;

                if (isTokenValid)
                {
                    OrderId = CustomerData.ConfirmOrder(order, isOffline);
                    if (!string.IsNullOrEmpty(OrderId))
                    {
                        order.OrderId = OrderId;
                        if (isOffline.HasValue && isOffline.Value)
                        {
                            string message = "Customer " + order.CustomerName + " is looking for " + order.ServiceName + " service from you. Customer mobile number is " + order.CustomerMobileNumber + ".Please check Tasko App for more details.";
                            string sURL = "http://www.metamorphsystems.com/index.php/api/bulk-sms?username=" + "taskoapp" + "&password=" + "Apple123" +
                                            "&from=" + "TTASKO" + "&to=" + order.VendorMobileNumber + "&message=" + message + "&sms_type=" + 2;
                            SendMessage(message, sURL);
                        }
                        else
                        {
                            r = SendNotification(order, OrderId, true);
                        }

                        SendEmail(order);
                    }
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
                    r.Data = OrderId;
                }  
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.ORDER_NOT_CONFIRMED : r.Message;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        private void SendEmail(Order order)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("taskoorder@gmail.com");
                mail.To.Add("animesh@tasko.in,chandra.varma@tasko.in");
                mail.Subject = "New Order " + order.OrderId + " is placed for " + order.ServiceName + " service";
                StringBuilder body = new StringBuilder();
                body.Append("Order Details:");
                body.Append("\n Customer Name: " + order.CustomerName);
                body.Append("\n Customer Contact Number: " + order.CustomerMobileNumber);
                if (order.DestinationAddress != null)
                {
                    body.Append("\n Customer Address:" + order.DestinationAddress.Address + order.DestinationAddress.City);
                }
                body.Append("\n Vendor Name: " + order.VendorName);
                body.Append("\n Vendor Number: " + order.VendorMobileNumber);
                mail.Body = body.ToString();

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential("taskoorder@gmail.com", "tasko$123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }
            }
        }

        public void GetDistance(string latitude, string longitude, string customerLatitude, string customerLongitude, MessageDetail message)
        {
            string requestUri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + latitude + "," + longitude + "&destinations=" + customerLatitude + "," + customerLongitude;
            WebRequest request = HttpWebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseStringData = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(responseStringData))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseStringData);
                string distanceXpath = "DistanceMatrixResponse/row/element/distance/text";
                XmlNode distance = xmlDoc.SelectSingleNode(distanceXpath);
                if (distance != null && !string.IsNullOrEmpty(distance.InnerText))
                {
                     message.CustomerDistance = distance.InnerText.Remove(distance.InnerText.IndexOf(" "));
                }

                string durationXpath = "DistanceMatrixResponse/row/element/duration/text";
                XmlNode duration = xmlDoc.SelectSingleNode(durationXpath);
                if (duration != null && !string.IsNullOrEmpty(duration.InnerText))
                {
                    message.CustomerETA = duration.InnerText;
                }
            }
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
        public Response GetCustomerOrders(string customerId, string orderStatus, int pageNumber, int recordsPerPage)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.ORDERS_NOT_FOUND : r.Message;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                    bool isTokenValid = TokenHelper.ValidateToken();
                    if (isTokenValid)
                    {
                        CustomerData.AddCustomerAddress(customerId, addressInfo);
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
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.CUSTOMER_DETAILS_INVALID;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                if (addressInfo != null)
                {
                    bool isTokenValid = TokenHelper.ValidateToken();
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
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.CUSTOMER_ADDRESS_INVALID;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                if (!string.IsNullOrEmpty(customerId) && !string.IsNullOrEmpty(addressId))
                {
                    bool isTokenValid = TokenHelper.ValidateToken();
                    if (isTokenValid)
                    {
                        CustomerData.DeleteCustomerAddress(customerId, addressId);
                        r.Message = CommonMessages.SUCCESS;
                        r.Error = false;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_DETAILS;
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
                    if (!string.IsNullOrEmpty(r.Message))
                    {
                        r.Error = true;
                        r.Status = 400;
                    }
                    else
                    {
                        r.Error = false;
                        r.Message = CommonMessages.CUSTOMER_ADDRESS_NOT_FOUND;
                        r.Status = 200;
                    }
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
        /// Update the vendor rating.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="vendorRating">The vendor rating.</param>
        /// <returns>Response Object</returns>
        public Response UpdateVendorRating(string orderId, VendorRating vendorRating)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.UpdateVendorRating(orderId, vendorRating);
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    bool isFavouriteVendorAlreadySet = CustomerData.SetFavoriteVendor(customerId, vendorId);

                    if (!isFavouriteVendorAlreadySet)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Message = CommonMessages.VENDOR_PRESENT_IN_FAVORITE_LIST;
                        r.Error = true;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    favoriteVendors = CustomerData.GetFavoriteVendors(customerId);
                    r.Message = CommonMessages.SUCCESS;
                    r.Data = favoriteVendors;
                    r.Error = false;
                    r.Status = 200;
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    r.Error = true;
                    r.Status = 400;
                }                
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
        public Response GenerateOTP(string emailId, string phoneNumber, bool checkUserExistence)
        {
            Response r = new Response();
            bool isCustomerExists = false;
            try
            {
                r.Message = CommonMessages.ERROR_GENERATING_OTP;
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, false))
                {
                    isCustomerExists = CustomerData.isCustomerPhoneNumberExits(phoneNumber);

                    if (checkUserExistence == true && isCustomerExists == false)
                    {
                        r.Message = CommonMessages.CUSTOMER_DOESNOT_EXISTS;
                        r.Error = false;
                        r.Status = 200;
                        return r;
                    }
                    else if (checkUserExistence == false && isCustomerExists == true)
                    {
                        r.Message = CommonMessages.CUSTOMER_ALREADY_EXISTS;
                        r.Error = false;
                        r.Status = 200;
                        return r;
                    }

                    //if customer exists
                    string otp = InternalGetOTP(phoneNumber);
                    if (!string.IsNullOrEmpty(otp))
                    {
                        CustomerData.InsertOTPDetails(otp, phoneNumber, emailId);
                        r.Message = CommonMessages.SUCCESS;
                        r.Error = false;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
                    if (loginInfo != null && !string.IsNullOrEmpty(loginInfo.UserId))
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.PHONE_NUMEBR_EXITS;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
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
                        r.Message = CommonMessages.INVALID_OTP_PHONENUMBER;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                r.Error = false;
                r.Status = 200;
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Message = CommonMessages.AUTHENTICATION_FAILED;
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };

            }
            return r;
        }

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetCustomerDetails(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                Customer objCustomer = null;
                if (isTokenValid)
                {
                    objCustomer = CustomerData.GetCustomer(customerId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (objCustomer != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = objCustomer;
                }
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.CUSTOMER_NOT_FOUND : r.Message;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        /// <summary>
        /// Deletes the favorite vendor.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        public Response DeleteFavoriteVendor(string customerId, string vendorId)
        {
            Response r = new Response();
            try
            {
                if (!string.IsNullOrEmpty(customerId) && !string.IsNullOrEmpty(vendorId))
                {
                    bool isTokenValid = TokenHelper.ValidateToken();
                    if (isTokenValid)
                    {
                        CustomerData.DeleteFavoriteVendor(customerId, vendorId);
                        r.Message = CommonMessages.SUCCESS;
                        r.Error = false;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_TOKEN_CODE;
                        r.Error = true;
                        r.Status = 400;
                    }                    
                }
                else
                {
                    r.Message = CommonMessages.INVALID_DETAILS;
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Status = 400;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        #region Complaints

        public Response AddComplaint(Complaint complaint)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    string complaintId = CustomerData.AddComplaint(complaint);
                    if (!string.IsNullOrEmpty(complaintId))
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Error = false;
                        r.Data = complaintId;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.ERROR_ADDING_COMPLAINT;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    r.Status = 400;
                }

            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response AddComplaintChat(ComplaintChat complaintChat)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<ComplaintChat> complaintChats = new List<ComplaintChat>();
                    complaintChats.Add(complaintChat);
                    CustomerData.AddComplaintChat(complaintChats, complaintChat.ComplaintId);

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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
                r.Status = 400;
            }

            return r;
        }

        public Response GetCustomerComplaints(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<Complaint> complaints = CustomerData.GetCustomerComplaints(customerId);
                    if (complaints != null && complaints.Count > 0)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = complaints;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.COMPLAINT_NOT_FOUND;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    r.Error = true;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

        #region Maps
        public Response GetNearbyVendors(string latitude, string longitude)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<VendorSummary> vendors = null;
                if (isTokenValid)
                {
                    vendors = VendorData.GetActiveVendorLocations();
                    if (vendors != null)
                    {
                        bool nearVendorFound = false;
                        foreach (VendorSummary vendorSummary in vendors)
                        {
                            string requestUri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + latitude + "," + longitude + "&destinations=" + vendorSummary.Latitude + "," + vendorSummary.Longitude;

                            WebRequest request = HttpWebRequest.Create(requestUri);
                            WebResponse response = request.GetResponse();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            string responseStringData = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(responseStringData))
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(responseStringData);
                                string xpath = "DistanceMatrixResponse/row/element/distance/text";
                                XmlNode distance = xmlDoc.SelectSingleNode(xpath);
                                if (distance != null && !string.IsNullOrEmpty(distance.InnerText))
                                {
                                    string actualDistance = distance.InnerText.Remove(distance.InnerText.IndexOf(" "));
                                    if (!string.IsNullOrEmpty(actualDistance))
                                    {
                                        nearVendorFound = true;
                                        vendorSummary.Distance = Convert.ToDecimal(actualDistance);
                                    }
                                }

                                string durationXpath = "DistanceMatrixResponse/row/element/duration/text";
                                XmlNode duration = xmlDoc.SelectSingleNode(durationXpath);
                                if (duration != null && !string.IsNullOrEmpty(duration.InnerText))
                                {
                                    vendorSummary.ETA = duration.InnerText;
                                }
                            }
                        }

                        if (nearVendorFound)
                        {
                            r.Error = false;
                            r.Message = CommonMessages.SUCCESS;
                            r.Status = 200;

                            decimal distanceCovered = Convert.ToDecimal(ConfigurationManager.AppSettings["DistanceCovered"]);
                            r.Data = vendors.Where(i => i.Distance <= distanceCovered).ToList();
                        }
                        else
                        {
                            r.Error = true;
                            r.Message = CommonMessages.NO_NEARBY_VENDORS;
                            r.Status = 400;
                        }
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.VENDORS_NOT_FOUND : r.Message;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

        #region Notifications
        public Response StoreCustomerGCMUser(string name, string customerId, string gcmRedId)
        {
            Response r = new Response();
            string userId = string.Empty;
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    userId = VendorData.StoreUser(name, string.Empty, gcmRedId, customerId);
                    if (string.IsNullOrEmpty(userId))
                    {
                        r.Data = userId;
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.USER_NAME_EXISTS;

                    }
                    else
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    r.Data = userId;
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        
        #endregion

        #region Offline Vendors
        public Response SaveOfflineVendorRequest(string customerId, string serviceId, string area)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.SaveOfflineVendorRequest(customerId, serviceId, area);
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response GetOfflineServiceVendors(string serviceId, string customerId, string latitude, string longitude)
        {
            decimal distanceCovered = Convert.ToDecimal(ConfigurationManager.AppSettings["OfflineDistanceCovered"]);
            return GetServiceVendors(serviceId, customerId, latitude, longitude, distanceCovered, false);
        }
        #endregion

        #region Social Media
        public Response UpdateCustomerLikeForPost(string postId, string customerId, bool isLiked)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.UpdateCustomerLikeForPost(postId, customerId, isLiked);
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response ReportPost(string postId, string customerId, string reason, string comment)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.ReportPost(postId, customerId, reason, comment);
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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Internals the get otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Gets the OTP</returns>
        private string InternalGetOTP(string phoneNumber)
        {
            string message = InternalGenerateOTP(phoneNumber);
            string sURL = "http://www.metamorphsystems.com/index.php/api/bulk-sms?username=" + "taskoapp" + "&password=" + "Apple123" +
                            "&from=" + "TTASKO" + "&to=" + phoneNumber + "&message=" + "Your OTP is " + message + "&sms_type=" + 2;
            return SendMessage(message, sURL);
        }

        private static string SendMessage(string message, string sURL)
        {
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
                return message;
            }
            catch
            {
                return message;
            }
        }

        /// <summary>
        /// Internals the generate otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Returns OTP</returns>
        private string InternalGenerateOTP(string phoneNumber)
        {
            string chars = "0123456789";
            string otp = string.Empty;
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                otp += chars[random.Next(chars.Length)];
            }

            return otp;
        }

        private static Response InternalSendNotification(string customerId, string vendorId, string message, string apiKey)
        {
            Response r = new Response();
            GcmUser gcmUser = null;
            if (!string.IsNullOrEmpty(customerId))
            {
                gcmUser = VendorData.GetGCMUserDetails(string.Empty, customerId);
            }
            else
            {
                gcmUser = VendorData.GetGCMUserDetails(vendorId, string.Empty);
            }

            if (gcmUser != null)
            {
                //string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=0&data.message=" + message +
                  //                "&data.time=" + System.DateTime.Now.ToString() +
                    //              "&registration_id=" + gcmUser.GcmRegId;
                // MESSAGE CONTENT
                //byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // CREATE REQUEST
                //HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                //Request.Method = "post";
                //Request.KeepAlive = false;
                //Request.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                //Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
                ////Request.Headers.Add(string.Format("Sender: id={0}", senderId));

                //Request.ContentLength = byteArray.Length;

                //Stream dataStream = Request.GetRequestStream();
                //dataStream.Write(byteArray, 0, byteArray.Length);
                //dataStream.Close();

                //var applicationID = "AIzaSyAyVxRCUPF1PYe8yS-18u4rOSs6IASxbzE";
                //var deviceId = "AIzaSyAyVxRCUPF1PYe8yS-18u4rOSs6IASxbzE";
                //string deviceId = "fUuUMUeUbOY:APA91bEdsr5xGNZGao6wKTi_rzCZriNOMl2bwyIjODmAH5M2Ml8hj7lLQX5oguKfErYUvfFlCBm1JBBC_2fjpKC9wQNRTinuH5KkpTcfCT775-fx-wzRhp-ojdsbIWwWvbzf14hjCqYS";
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = gcmUser.GcmRegId,
                    notification = new
                    {
                        body = message,
                        title = "Tasko Notification",
                    },
                    priority = "high"
                };

                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", apiKey));
                tRequest.ContentLength = byteArray.Length;
                try
                {
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            //using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            //using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            //{
                            //    String sResponseFromServer = tReader.ReadToEnd();
                            //    //Response.Write(sResponseFromServer);
                            //}
                            HttpStatusCode ResponseCode = ((HttpWebResponse)tResponse).StatusCode;
                            if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                            {
                                r.Message = "Unauthorized - need new token";
                                r.Error = true;
                                r.Status = 400;
                            }
                            else if (!ResponseCode.Equals(HttpStatusCode.OK))
                            {
                                r.Message = CommonMessages.RESPONSE_WRONG;
                                r.Error = true;
                                r.Status = 400;
                            }
                            else
                            {
                                StreamReader Reader = new StreamReader(tResponse.GetResponseStream());
                                r.Message = CommonMessages.SUCCESS;
                                r.Error = false;
                                r.Status = 200;
                                r.Data = Reader.ReadToEnd();
                                Reader.Close();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    r.Message = "Error";
                    r.Error = true;
                    r.Status = 400;
                }

                // SEND MESSAGE
                //try
                //{
                //    WebResponse Response = Request.GetResponse();
                //    HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                //    if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                //    {
                //        r.Message = "Unauthorized - need new token";
                //        r.Error = true;
                //        r.Status = 400;
                //    }
                //    else if (!ResponseCode.Equals(HttpStatusCode.OK))
                //    {
                //        r.Message = CommonMessages.RESPONSE_WRONG;
                //        r.Error = true;
                //        r.Status = 400;
                //    }
                //    else
                //    {
                //        StreamReader Reader = new StreamReader(Response.GetResponseStream());
                //        r.Message = CommonMessages.SUCCESS;
                //        r.Error = false;
                //        r.Status = 200;
                //        r.Data = Reader.ReadToEnd();
                //        Reader.Close();
                //    }

                //    return r;
                //}
                //catch (Exception e)
                //{
                //    r.Message = "Error";
                //    r.Error = true;
                //    r.Status = 400;
                //}
            }
            else
            {
                r.Message = CommonMessages.USER_NOT_FOUND;
                r.Error = true;
                r.Status = 400;
            }

            return r;
        }
        private Response SendNotification(Order order, string OrderId, bool saveDetails)
        {
            Response r = new Response();
            MessageDetail message = new MessageDetail();
            string messageData = string.Empty;
            switch (order.OrderStatusId)
            {
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderPending:
                    message.CustomerAddress = order.DestinationAddress;
                    message.CustomerLocation = order.Location;
                    message.CustomerName = order.CustomerName;
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.ServiceName = order.ServiceName;
                    message.CustomerPhone = order.CustomerMobileNumber;
                    message.Comments = order.Comments;
                    ////message.OrderMessage = "";
                    GetDistance(order.SourceAddress.Lattitude, order.SourceAddress.Longitude, order.DestinationAddress.Lattitude, order.DestinationAddress.Longitude, message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderAccepted:
                    message.CustomerLatitude = order.DestinationAddress.Lattitude;
                    message.CustomerLongitude = order.DestinationAddress.Longitude;
                    message.CustomerPhone = CustomerData.GetCustomerPhone(order.CustomerId);
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(order.CustomerId, string.Empty, messageData, ConfigurationManager.AppSettings["CustomerAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderConfirmed:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.VendorPhone = VendorData.GetVendorPhone(order.VendorId);
                    message.Comments = order.Comments;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderCancelled:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderWorkCompleted:
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderMissed:
                    message.OrderId = OrderId;
                    message.Comments = order.Comments;
                    message.Orderstatus = order.OrderStatusId;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(order.CustomerId, string.Empty, messageData, ConfigurationManager.AppSettings["CustomerAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderCompleted:
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderRejected:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                default:
                    break;
                //1 requested, 
            }

            if (message != null && saveDetails && !string.IsNullOrEmpty(message.CustomerETA) && message.CustomerAddress != null)
            {
                CustomerData.UpdateCustomerOrderDetails(message.CustomerETA, message.CustomerDistance, message.OrderId, order.VendorId);
            }
            return r;
        }
        private static Response GetServiceVendors(string serviceId, string customerId, string latitude, string longitude, decimal distanceCovered, bool isOnline)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<ServiceVendor> services = null;
                if (isTokenValid)
                {
                    services = CustomerData.GetServiceVendors(serviceId, customerId);
                    bool nearVendorFound = false;
                    if (services != null)
                    {
                        foreach (ServiceVendor serviceVendor in services)
                        {
                            decimal vendorLatitude = 0;
                            decimal vendorLongitude = 0;
                            if(isOnline)
                            {
                                vendorLatitude = serviceVendor.Latitude;
                                vendorLongitude = serviceVendor.Longitude;
                            }
                            else
                            {
                                vendorLatitude = serviceVendor.HomeLatitude;
                                vendorLongitude = serviceVendor.HomeLongitude;
                            }

                            // This means that vendor is logged out. So we are updating his distance to negative value.
                            if (vendorLatitude != 0 && vendorLongitude != 0)
                            {
                                if (serviceVendor.IsEntireCityAccessible)
                                {
                                    XmlDocument xDoc = new XmlDocument();
                                    xDoc.Load("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");

                                    XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
                                    XmlNode xNode = xNodelst.Item(0);
                                    //string adress = xNode.SelectSingleNode("formatted_address").InnerText;
                                    //string area = xNode.SelectSingleNode("address_component[3]/long_name").InnerText;
                                    string customerCity = xNode.SelectSingleNode("address_component[4]/long_name").InnerText;
                                    if (string.IsNullOrEmpty(customerCity) || string.IsNullOrEmpty(serviceVendor.VendorCity) || customerCity.ToLower() != serviceVendor.VendorCity.ToLower())
                                    {
                                        // setting this to false so that this vendor will not be returned. we are not saving in the db. this is just a temp change to restrict him from returning
                                        serviceVendor.IsEntireCityAccessible = false;
                                    }
                                    else
                                    {
                                        nearVendorFound = true;
                                    }
                                    //string district = xNode.SelectSingleNode("address_component[5]/long_name").InnerText;
                                }
                                else
                                {
                                    string requestUri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + latitude + "," + longitude + "&destinations=" + vendorLatitude + "," + vendorLongitude;

                                    WebRequest request = HttpWebRequest.Create(requestUri);
                                    WebResponse response = request.GetResponse();
                                    StreamReader reader = new StreamReader(response.GetResponseStream());
                                    string responseStringData = reader.ReadToEnd();
                                    if (!string.IsNullOrEmpty(responseStringData))
                                    {
                                        XmlDocument xmlDoc = new XmlDocument();
                                        xmlDoc.LoadXml(responseStringData);
                                        string xpath = "DistanceMatrixResponse/row/element/distance/text";
                                        XmlNode distance = xmlDoc.SelectSingleNode(xpath);
                                        if (distance != null && !string.IsNullOrEmpty(distance.InnerText))
                                        {
                                            string actualDistance = distance.InnerText.Remove(distance.InnerText.IndexOf(" "));
                                            if (!string.IsNullOrEmpty(actualDistance))
                                            {
                                                nearVendorFound = true;
                                                serviceVendor.Distance = Convert.ToDecimal(actualDistance);
                                            }
                                        }

                                        string durationXpath = "DistanceMatrixResponse/row/element/duration/text";
                                        XmlNode duration = xmlDoc.SelectSingleNode(durationXpath);
                                        if (duration != null && !string.IsNullOrEmpty(duration.InnerText))
                                        {
                                            serviceVendor.ETA = duration.InnerText;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                serviceVendor.Distance = -1;
                                serviceVendor.IsEntireCityAccessible = false;
                            }
                        }
                    }

                    if (nearVendorFound)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;

                        List<ServiceVendor> vendors = new List<ServiceVendor>();
                        if (services.Any(i => i.VendorId == "2C086E5F59A0C44AAC70475E6613FF4E"))
                        {
                            vendors.Add(services.FirstOrDefault(i => i.VendorId == "2C086E5F59A0C44AAC70475E6613FF4E"));
                        }

                        vendors.AddRange(services.Where(i => i.VendorId != "2C086E5F59A0C44AAC70475E6613FF4E"));
                        r.Data = vendors.Where(i => (i.Distance <= distanceCovered && i.Distance != -1) || i.IsEntireCityAccessible).ToList();
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_NEARBY_VENDORS;
                        r.Status = 400;
                    }
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                    r.Status = 400;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

    }
}
