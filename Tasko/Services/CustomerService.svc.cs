using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tasko.Interfaces;
using Tasko.Model;
using Tasko.Repository;

namespace Tasko
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
                    r.Message = "success";
                    r.Status = 200;
                    r.Data = services;
                }
                else
                {
                    r.Error = true;
                    r.Message = "Services not found";
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
                    r.Message = "success";
                    r.Status = 200;
                    r.Data = services;
                }
                else
                {
                    r.Error = true;
                    r.Message = "Vendors are not found for the selected service";
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
                    r.Message = "Invalid token code";
                }

                if (!string.IsNullOrEmpty(OrderId))
                {
                    r.Error = false;
                    r.Message = "success";
                    r.Status = 200;
                    r.Data = "OrderId: " + OrderId;
                }
                else
                {
                    r.Error = true;
                    r.Message = "Order not Confirmed";
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
                    r.Message = "success";
                    r.Status = 200;
                }
                else
                {
                    r.Message = "Invalid token code";
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
                    r.Message = "Invalid token code";
                }

                if (orderSummary != null && orderSummary.Count > 0)
                {
                    r.Error = false;
                    r.Message = "success";
                    r.Status = 200;
                    r.Data = orderSummary;
                }
                else
                {
                    r.Error = true;
                    r.Message = "Orders not found";
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
                bool isTokenValid = ValidateToken();               
                if (isTokenValid)
                {
                    CustomerData.AddCustomerAddress(customerId, addressInfo);
                    r.Error = false;
                    r.Message = "success";
                    r.Status = 200;
                }
                else
                {
                    r.Message = "Invalid token code";
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
                    r.Message = "success";
                    r.Status = 200;
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                    r.Message = "Invalid token code";
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
                    r.Message = "success";
                }
                else
                {
                    r.Message = "Invalid token code";
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
                    r.Message = "Invalid token code";
                }

                if (customerAddresses != null && customerAddresses.Count > 0)
                {
                    r.Message = "success";
                    r.Data = customerAddresses;
                }
                else
                {
                    r.Message = "Customer Addresses not found";
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
                    r.Message = "Success";
                }
                else
                {
                    r.Message = "Invalid token code";
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
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    CustomerData.GetFavoriteVendors(customerId);
                    r.Message = "Success";
                }
                else
                {
                    r.Message = "Invalid token code";
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
