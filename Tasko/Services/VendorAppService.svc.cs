using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using Tasko.Common;
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
                if (!string.IsNullOrEmpty(authCode) && VendorData.ValidateAuthCode(authCode, true))
                {
                    loginInfo = VendorData.Login(username, password, mobilenumber, userType); // 1 is vendor
                    if (loginInfo.UserId == null)
                    {
                        r.Message = CommonMessages.INVALID_CREDENTIALS;
                    }
                }
                else
                {
                    r.Message = CommonMessages.INVALID_AUTHCODE;
                }

                if (loginInfo != null && loginInfo.UserId != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.LOGIN_SUCCESSFULL;
                    r.Status = 200;
                    r.Data = loginInfo;
                }
                else
                {
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
                bool isTokenValid = TokenHelper.ValidateToken();
                Vendor objVendor = null;
                if (isTokenValid)
                {
                    objVendor = VendorData.GetVendor(vendorId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (objVendor != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = objVendor;
                }
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.VENDOR_NOT_FOUND : r.Message;
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
        /// Gets the vendor services.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorServices(string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<VendorService> vendorServices = null;
                if (isTokenValid)
                {
                    vendorServices = VendorData.GetVendorServices(vendorId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (vendorServices != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = vendorServices;
                }
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.NO_SERVICES_AVAILABLE : r.Message;
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
        /// Gets the vendor sub services.
        /// </summary>
        /// <param name="vendorServiceId">The vendor service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorSubServices(string vendorServiceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<VendorService> vendorSubServices = null;
                if (isTokenValid)
                {
                    vendorSubServices = VendorData.GetVendorSubServices(vendorServiceId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (vendorSubServices != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = vendorSubServices;
                }
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.NO_SUB_SERVICES_AVAILABLE : r.Message;
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
                bool isTokenValid = false;

                Comments = Comments == null ? string.Empty : Comments;

                //// if webOperationContext is null it means call made by TaskoService
                isTokenValid = WebOperationContext.Current == null ? true : TokenHelper.ValidateToken();

                try
                {
                    if (isTokenValid)
                    {
                        VendorData.UpdateOrderStatus(orderId, orderStatus, Comments);
                        Order order = CustomerData.GetOrderDetails(orderId);
                        if (order != null && !order.IsOffline)
                        {
                            r = SendNotification(order, orderId);
                        }
                        r.Data = order;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_TOKEN_CODE;
                        r.Error = true;
                        r.Status = 400;
                    }
                }
                catch
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? CommonMessages.ERROR_UPDATING_ORDER_STATUS : r.Message;
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
        /// Updates the vendor services.
        /// </summary>
        /// <param name="vendorServices">The vendor services.</param>
        /// <returns>Response Object</returns>
        public Response UpdateVendorServices(List<VendorService> vendorServices)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorData.UpdateVendorServices(vendorServices);

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
                r.Message = CommonMessages.ERROR_UPDATING_VENDOR_SERVICES;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorData.UpdateVendorBaseRate(vendorId, baseRate);

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
                r.Message = CommonMessages.ERROR_UPDATING_VENDOR_BASE_RATE;
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
                r.Message = CommonMessages.ERROR_LOGGING_OUT;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<VendorRating> objVendorRatings = VendorData.GetVendorRatings(vendorId);
                    if (objVendorRatings != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = objVendorRatings;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_RATINGS_FOR_VENDOR;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorOverallRating objVendorRatings = VendorData.GetVendorOverallRatings(vendorId);

                    if (objVendorRatings != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = objVendorRatings;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_RATINGS_FOR_VENDOR;
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
        public Response GetVendorOrders(string vendorId, string orderStatusId, int pageNumber, int recordsPerPage)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<OrderSummary> objOrders = VendorData.GetVendorOrders(vendorId, orderStatusId, pageNumber, recordsPerPage);

                    if (objOrders != null && objOrders.Count > 0)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = objOrders;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_ORDERS_FOR_VENDOR;
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

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public Response ChangePassword(string vendorId, string password, string oldPassword, bool chkOld)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    bool isOldPasswordValid = VendorData.ChangePassword(vendorId, password, oldPassword);

                    if (isOldPasswordValid)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_OLD_PASSWORD;
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
        /// Updates Vendor details
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns>Response</returns>
        public Response UpdateVendor(Vendor vendor)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorData.UpdateVendor(vendor);

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

        public Response UpdateVendorLocation(string vendorId, AddressInfo addressInfo)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    if (addressInfo != null)
                    {
                        VendorData.UpdateVendorLocation(addressInfo, vendorId);
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
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

        public void SendNotification(OrderSummary order)
        {
            MessageDetail message = new MessageDetail();
            string messageData = string.Empty;
            message.OrderId = order.OrderId;
            message.Orderstatus = -1;
            message.VendorName = order.VendorName;
            message.ServiceName = order.ServiceName;
            messageData = JsonConvert.SerializeObject(message);

            Response response = InternalSendNotification(order.CustomerId, string.Empty, messageData, ConfigurationManager.AppSettings["CustomerAPIKey"].ToString());
            if (response != null && response.Message == CommonMessages.SUCCESS)
            {
                //// update the order as notified .
                VendorData.UpdateOrderIsNotified(order.OrderId);
            }
        }

        #region Notifications
        public Response StoreVendorGCMUser(string name, string vendorId, string gcmRedId)
        {
            Response r = new Response();
            string userId = string.Empty;
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    userId = VendorData.StoreUser(name, vendorId, gcmRedId, string.Empty);
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

        private Response SendNotification(Order order, string OrderId)
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
                    message.VendorName = order.VendorName;
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
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
                     message.CustomerName = order.CustomerName;
                    message.VendorName = order.VendorName;
                    message.OrderId = OrderId;
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(order.CustomerId, string.Empty, messageData, ConfigurationManager.AppSettings["CustomerAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderConfirmed:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.VendorPhone = VendorData.GetVendorPhone(order.VendorId);
                    message.Comments = order.Comments;
                     message.CustomerName = order.CustomerName;
                    message.VendorName = order.VendorName;
                    
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderCancelled:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                     message.CustomerName = order.CustomerName;
                    message.VendorName = order.VendorName;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderWorkCompleted:
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderRejected:
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderMissed:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                     message.CustomerName = order.CustomerName;
                    message.VendorName = order.VendorName;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(order.CustomerId, string.Empty, messageData, ConfigurationManager.AppSettings["CustomerAPIKey"].ToString());
                    break;
                case (int)Tasko.Common.TaskoEnum.OrderStatus.OrderCompleted:
                    message.OrderId = OrderId;
                    message.Orderstatus = order.OrderStatusId;
                    message.Comments = order.Comments;
                     message.CustomerName = order.CustomerName;
                    message.VendorName = order.VendorName;
                    //messageData = new JavaScriptSerializer().Serialize(message);
                    messageData = JsonConvert.SerializeObject(message);
                    r = InternalSendNotification(string.Empty, order.VendorId, messageData, ConfigurationManager.AppSettings["VendorAPIKey"].ToString());
                    break;
                default:
                    break;
                //1 requested, 
            }
            return r;
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
                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=0&data.message=" + message +
                                  "&data.time=" + System.DateTime.Now.ToString() +
                                  "&registration_id=" + gcmUser.GcmRegId;
                // MESSAGE CONTENT
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // CREATE REQUEST
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                Request.Method = "post";
                Request.KeepAlive = false;
                Request.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
                ////Request.Headers.Add(string.Format("Sender: id={0}", senderId));

                Request.ContentLength = byteArray.Length;

                Stream dataStream = Request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // SEND MESSAGE
                try
                {
                    WebResponse Response = Request.GetResponse();
                    HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
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
                        StreamReader Reader = new StreamReader(Response.GetResponseStream());
                        r.Message = CommonMessages.SUCCESS;
                        r.Error = false;
                        r.Status = 200;
                        r.Data = Reader.ReadToEnd();
                        Reader.Close();
                    }

                    return r;
                }
                catch (Exception e)
                {
                    r.Message = "Error";
                    r.Error = true;
                    r.Status = 400;
                }
            }
            else
            {
                r.Message = CommonMessages.USER_NOT_FOUND;
                r.Error = true;
                r.Status = 400;
            }

            return r;
        }
        #endregion
    }
}
