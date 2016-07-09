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

namespace Tasko.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {
        #region Services
        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>Response Object</returns>
        public Response AddService(Service service)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                   AdminData.AddService(service);
                   r.Error = false;
                   r.Status = 200;
                   r.Message = CommonMessages.SUCCESS;
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;           
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>Response Object</returns>
        public Response UpdateService(Service service)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateService(service);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Disables the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>Response Object</returns>
        public Response DisableService(string serviceId, short status)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DisableService(serviceId, status);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Response Object</returns>
        public Response DeleteService(string serviceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                   bool isServiceInUse = AdminData.DeleteService(serviceId);
                   if (isServiceInUse)
                   {
                       r.Error = true;
                       r.Status = 400;
                       r.Message = CommonMessages.SERVICE_IN_USE;
                   }
                   else
                   {
                       r.Error = false;
                       r.Status = 200;
                       r.Message = CommonMessages.SUCCESS;
                   }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>Response Object</returns>
        public Response GetAllServices()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<ServiceDetail> services = AdminData.GetAllServices();

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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;           
        }

        /// <summary>
        /// Gets the orders by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetOrdersByService(string serviceId)
        {
            Response r = new Response();
            try
            {
                 bool isTokenValid = ValidateToken();
                 if (isTokenValid)
                 {
                     List<OrderSummary> services = AdminData.GetOrdersByService(serviceId);

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
                         r.Message = CommonMessages.ORDERS_NOT_FOUND;
                         r.Status = 400;
                     }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Gets the vendors by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorsByService(string serviceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<VendorSummary> vendors = AdminData.GetVendorsByService(serviceId);

                    if (vendors != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = vendors;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.VENDORS_NOT_FOUND;
                        r.Status = 400;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }       

        #endregion

        #region Vendors
        /// <summary>
        /// Adds the vendor.
        /// </summary>
        /// <param name="vendor">Vendor.</param>
        /// <returns>Response Object</returns>
        public Response AddVendor(Vendor vendor)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    string vendorId = AdminData.AddVendor(vendor);
                    if (!string.IsNullOrEmpty(vendorId))
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.ADD_VENDOR_FAILED;

                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Get Services For Vendor.
        /// </summary>
        /// <param name="vendorId">Vendor Id.</param>
        /// <returns>Response Object</returns>
        public Response GetServicesForVendor(string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<ServicesForVendor> servicesForVendor = AdminData.GetServicesForVendor(vendorId);
                    if (servicesForVendor != null)
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = servicesForVendor;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.SERVICES_NOT_FOUND;
                        r.Status = 40;
                        r.Data = null;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Updates Services For Vendor.
        /// </summary>
        /// <param name="services">Services for Vendor.</param>
        /// <returns>Response Object</returns>
        public Response UpdateServicesForVendor(string vendorId, List<ServicesForVendor> services)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateServicesForVendor(vendorId, services);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        
        /// <summary>
        /// Gets the vendor overview
        /// </summary>
        /// <param name="vendorId">Vendor Id.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorOverview(string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    VendorOverview vendorOverview = AdminData.GetVendorOverview(vendorId);
                    if (vendorOverview != null)
                    {
                        r.Data = vendorOverview;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.VENDOR_NOT_FOUND;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response GetVendorsByStatus(int vendorStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<VendorSummary> vendors = AdminData.GetVendorsByStatus(vendorStatus);
                    if (vendors != null && vendors.Count > 0)
                    {
                        r.Data = vendors;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Data = null;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.NO_VENDORS;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

        # region Customers
        public Response GetAllCustomersByStatus(int customerStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    AdminData.GetVendorsByStatus(customerStatus);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                    r.Message = CommonMessages.NO_CUSTOMERS;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
	
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

        # endregion
        #region General
        #endregion

        #region Orders
        public Response GetOrders(int orderStatusId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<OrderSummary> objOrders = AdminData.GetOrders(orderStatusId);

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
                        r.Message = CommonMessages.NO_ORDERS;
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

        public Response AddComplaint(Complaint complaint)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                Order objOrder = null;
                if (isTokenValid)
                {
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
                    ////r.Error = true;
                    ////r.Message = CommonMessages.ORDER_NOT_FOUND;
                    ////r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response GetComplaints(int complaintStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                Order objOrder = null;
                if (isTokenValid)
                {
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
                    ////r.Error = true;
                    ////r.Message = CommonMessages.ORDER_NOT_FOUND;
                    ////r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        public Response UpdateComplaint(Complaint complaint)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                Order objOrder = null;
                if (isTokenValid)
                {
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
                    ////r.Error = true;
                    ////r.Message = CommonMessages.ORDER_NOT_FOUND;
                    ////r.Status = 400;
                }
            }
            catch (Exception ex)
            {
                r.Error = true;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }
        #endregion

        #region Customers
        #endregion

        #region Dashboard
        /// <summary>
        /// Gets the dashboard recent orders by status.
        /// </summary>
        /// <param name="orderStatusId">The order status identifier.</param>
        /// <returns>Response Object</returns>        
        public Response GetDashboardRecentOrdersByStatus(int orderStatusId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<OrderSummary> recentOrders = AdminData.GetDashboardRecentOrdersByStatus(orderStatusId);

                    if (recentOrders != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = recentOrders;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.ORDERS_NOT_FOUND;
                        r.Status = 400;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r; 
        }

        /// <summary>
        /// Gets the dashboard meters.
        /// </summary>
        /// <returns>Response Object</returns>
        public Response GetDashboardMeters()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    DashboardMeter dashboardMeter = AdminData.GetDashboardMeters();

                    if (dashboardMeter != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = dashboardMeter;
                    }                    
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        /// <summary>
        /// Gets the dashboard recent activities.
        /// </summary>
        /// <returns></returns>
        public Response GetDashboardRecentActivities()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    List<RecentActivities> recentActivities = AdminData.GetDashboardRecentActivities();

                    if (recentActivities != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = recentActivities;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_RECENT_ACTIVITIES;
                        r.Status = 400;
                    }
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }

            return r;
        }

        #endregion

        #region Payments

        #endregion

        #region Private Methods
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

            //return true;
        }
        #endregion
    }
}
