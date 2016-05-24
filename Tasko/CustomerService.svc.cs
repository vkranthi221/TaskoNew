using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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
        /// <returns>
        /// Response Object
        /// </returns>
        public Response GetServiceVendors(string serviceId)
        {
            Response r = new Response();
            try
            {
                List<ServiceVendor> services = CustomerData.GetServiceVendors(serviceId);

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
