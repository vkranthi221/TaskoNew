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
using Tasko.Common;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                   AdminData.AddService(service);
                   r.Error = false;
                   r.Status = 200;
                   r.Message = CommonMessages.SUCCESS;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateService(service);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DisableService(serviceId, status);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                   bool isServiceInUse = AdminData.DeleteService(serviceId);
                   if (isServiceInUse)
                   {
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
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }
            }
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
        /// Gets the orders by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetOrdersByService(string serviceId, bool? isOffline)
        {
            Response r = new Response();
            try
            {
                 bool isTokenValid = TokenHelper.ValidateToken();
                 if (isTokenValid)
                 {
                     bool offline = isOffline.HasValue ? isOffline.Value : false;
                     List<OrderSummary> services = AdminData.GetOrdersByService(serviceId, offline);

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
        /// Gets the vendors by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorsByService(string serviceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        
        public Response GetServiceOverview(string serviceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    ServiceOverview serviceOverview = AdminData.GetServiceOverview(serviceId);
                    if (serviceOverview != null)
                    {
                        r.Data = serviceOverview;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.NO_PAYMENTS_EXIST_FOR_SERVICE;
                    }
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
                        r.Message = CommonMessages.VENDOR_ALREADY_EXISTS;

                    }
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
        /// Updates Services For Vendor.
        /// </summary>
        /// <param name="services">Services for Vendor.</param>
        /// <returns>Response Object</returns>
        public Response UpdateServicesForVendor(string vendorId, List<ServicesForVendor> services)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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
        /// Gets the vendor overview
        /// </summary>
        /// <param name="vendorId">Vendor Id.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorOverview(string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        public Response GetVendorsByStatus(int vendorStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        public Response UpdateVendorDetails(Vendor vendor)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateVendorDetails(vendor);
                    r.Data = null;
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.VENDOR_UPDATED;
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

        /// <summary>
        /// Updates the vendor documents.
        /// </summary>
        /// <param name="vendorDocuments">The vendor documents.</param>
        /// <returns>Response Object</returns>
        public Response UpdateVendorDocuments(VendorDocuments vendorDocuments)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    if (vendorDocuments != null)
                    {
                        AdminData.UpdateVendorDocuments(vendorDocuments);
                        r.Data = null;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.VENDOR_DOCUMENTS_UPDATED;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = "Vendor Documents should not be null, Please check the parameter name as it is case sensitive";
                    }
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

        /// <summary>
        /// Gets the vendor documents.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetVendorDocuments(string vendorId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorDocuments vendorDocuments = AdminData.GetVendorDocuments(vendorId);
                    if (vendorDocuments != null)
                    {
                        r.Data = vendorDocuments;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.VENDOR_DOCUMENTS_NOTFOUND;
                    }
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

        # region Customers
        public Response GetAllCustomersByStatus(int customerStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<Customer> customers = AdminData.GetCustomersByStatus(customerStatus);
                    r.Error = false;
                    r.Status = 200;

                    if (customers != null && customers.Count > 0)
                    {
                        r.Data = customers;                     
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Message = CommonMessages.NO_CUSTOMERS;
                    }
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

        public Response GetCustomerRatingsForOrders(string customerId, int noOfRecords) 
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<CustomerRating> customerRatings = AdminData.CustomerRatingsForOrders(customerId, noOfRecords);
                    r.Data = customerRatings;
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
                    r.Error = false;
                    r.Status = 200;
                    if (customerAddresses != null && customerAddresses.Count > 0)
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = customerAddresses;
                    }
                    else
                    {
                        r.Message = CommonMessages.CUSTOMER_ADDRESS_NOT_FOUND;
                    }
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
                r.Status = 400;
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
            }
            return r;
        }

        public Response GetCustomerOverview(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    CustomerOverview customerOverview = AdminData.GetCustomerOverview(customerId);
                    if (customerOverview != null)
                    {
                        r.Data = customerOverview;
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = CommonMessages.CUSTOMER_NOT_FOUND;
                    }
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

        # endregion

        #region General
        #endregion

        #region Orders
        public Response GetOrders(int orderStatusId, bool? isOffline)
        {
            Response r = new Response();
            try
            {
                if (!isOffline.HasValue)
                {
                    isOffline = false;
                }

                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<OrderSummary> objOrders = AdminData.GetOrders(orderStatusId, isOffline.Value);

                    if (objOrders != null && objOrders.Count > 0)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = objOrders;
                    }
                    else
                    {
                        r.Error = false;
                        r.Message = CommonMessages.NO_ORDERS;
                        r.Status = 200;
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
                    r.Error = false;
                    r.Status = 200;

                    if (objOrder != null)
                    {  
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = objOrder;
                    }
                    else
                    {   
                        r.Message = CommonMessages.ORDER_NOT_FOUND;
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
                bool isTokenValid = TokenHelper.ValidateToken();
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
        /// Gets the dashboard meters.
        /// </summary>
        /// <returns>Response Object</returns>
        public Response GetDashboardMeters()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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
        /// Gets the dashboard recent activities.
        /// </summary>
        /// <returns></returns>
        public Response GetDashboardRecentActivities()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        #region Payments
        /// <summary>
        /// Adds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns>Response Object</returns>
        public Response AddPayment(Payment payment)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.AddPayment(payment);
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
        /// Adds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns>Response Object</returns>
        public Response UpdatePayment(Payment payment)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdatePayment(payment);
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
        /// Gets all payments by status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>Response object</returns>
        public Response GetAllPaymentsByStatus(string status)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<Payment> payments = AdminData.GetAllPaymentsByStatus(status);

                    if (payments != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = payments;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_PAYMENTS_FOUND;
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
        /// Gets the payment.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>
        /// Response object
        /// </returns>
        public Response GetPayment(string paymentId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    Payment payment = AdminData.GetPayment(paymentId);

                    if (payment != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = payment;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_PAYMENT_FOUND;
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
        /// Gets the payment invoice.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>Response Object</returns>
        public Response GetPaymentInvoice(string paymentId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    VendorPaymentInvoice paymentInvoice = AdminData.GetPaymentInvoice(paymentId);

                    if (paymentInvoice != null)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = paymentInvoice;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_PAYMENTS_FOUND;
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
        /// Gets all vendors summary.
        /// </summary>
        /// <returns>Response object</returns>
        public Response GetAllVendorsSummary()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<VendorSummary> vendors = AdminData.GetAllVendorsSummary();

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

        #region Users
        public Response AddUser(User user)
        {
            Response r = new Response();
            string userId = string.Empty;
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    userId = AdminData.AddUser(user);
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

        public Response GetAllUsers()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<User> users = AdminData.GetAllUsers();

                    if (users != null && users.Count > 0)
                    {
                        r.Error = false;
                        r.Message = CommonMessages.SUCCESS;
                        r.Status = 200;
                        r.Data = users;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = CommonMessages.NO_USERS;
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

        public Response GetUserDetails(string userId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                User objUser = null;
                if (isTokenValid)
                {
                    objUser = AdminData.GetUserDetails(userId);
                    r.Error = false;
                    r.Status = 200;
                    if (objUser != null)
                    {  
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = objUser;
                    }
                    else
                    {   
                        r.Message = CommonMessages.USER_NOT_FOUND;
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

        public Response DeleteUser(string userId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DeleteUser(userId);

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
            catch (UserException userException)
            {
                r.Message = userException.Message;
            }
            catch (Exception ex)
            {
                r.Message = CommonMessages.FAIL;
                r.Error = true;
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

        public Response Login(string userName, string password)
        {
            Response r = new Response();
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string authCode = headers["Auth_Code"];
                bool isAuthCodeValid = AdminData.ValidateAuthCode(authCode, true);
                if (isAuthCodeValid)
                {
                    LoginInfo loginInfo = AdminData.LoginAdminUser(userName, password);
                    if (!string.IsNullOrEmpty(loginInfo.UserId))
                    {
                        r.Message = CommonMessages.SUCCESS;
                    }
                    else
                    {
                        r.Message = CommonMessages.INVALID_CREDENTIALS;
                    }

                    r.Data = loginInfo;
                    r.Error = false;
                    r.Status = 200;
                    
                }
                else
                {
                    r.Error = true;
                    r.Status = 400;
                    r.Message = CommonMessages.INVALID_AUTHCODE;
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

        public Response UpdateUserStatus(string userId, bool isActive)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateUserStatus(userId, isActive);
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.SUCCESS;
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
                r.Data = new ErrorDetails { Message = ex.Message, StackTrace = ex.StackTrace };
                r.Status = 400;
                r.Error = true;
                r.Message = CommonMessages.FAIL;
            }

            return r;
        }
        #endregion

        #region Complaints

        public Response GetComplaints(int complaintStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        public Response UpdateComplaint(Complaint complaint)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
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

        public Response GetAllComplaints(int complaintStatus)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<Complaint> complaints = AdminData.GetAllComplaints(complaintStatus);
                    if(complaints != null && complaints.Count >0)
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

        #region Notifications
        
        public Response GetAllGCMUsers()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<GcmUser> objUsers = null;
                if (isTokenValid)
                {
                    objUsers = AdminData.GetAllGCMUsers();
                    r.Status = 200;
                    r.Error = false;

                    if (objUsers != null)
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = objUsers;
                    }
                    else
                    {   
                        r.Message = CommonMessages.USERS_NOT_FOUND;
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

        #region Offline Vendor Request
        public Response GetOffileVendorRequests()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<OfflineVendorRequest> requests = null;
                if (isTokenValid)
                {
                    requests = AdminData.GetOffileVendorRequests();
                    r.Status = 200;
                    r.Error = false;
                    if (requests != null)
                    {   
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = requests;
                    }
                    else
                    {   
                        r.Message = CommonMessages.REQUESTS_NOT_FOUND;
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

        #region Regions
        public Response AddState(State state)
        {
            Response r = new Response();
            
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    if (AdminData.AddState(state))
                    {
                        r.Error = true;
                        r.Status = 400;
                        r.Message = "State already exists";
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

        public Response AddCities(List<City> cities)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.AddCities(cities);
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

        public Response GetCities(string stateId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<City> cities = AdminData.GetCities(stateId);
                    if (cities != null)
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = cities;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = "Cities not found";
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

        public Response DeleteCities(List<string> cities)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DeleteCities(cities);
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

        public Response GetStates()
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken(); ;
                if (isTokenValid)
                {
                    List<State> states = AdminData.GetStates();
                    if (states != null)
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = states;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = "States not found";
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
        public Response DeleteStates(List<string> states)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DeleteStates(states);
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

        #region Rate Cards
        public Response AddRateCards(List<RateCard> rateCards)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.AddRateCards(rateCards);
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

        public Response GetRateCardsForCity(string cityId, string parentServiceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    List<RateCard> rateCards = AdminData.GetRateCardsForCity(cityId, parentServiceId);
                    if (rateCards != null)
                    {
                        r.Error = false;
                        r.Status = 200;
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = rateCards;
                    }
                    else
                    {
                        r.Error = true;
                        r.Message = "Rate Card not found for city";
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

        public Response UpdateRateCards(List<RateCard> rateCards)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateRateCards(rateCards);
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

        public Response DeleteRateCards(List<string> rateCards)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                if (isTokenValid)
                {
                    AdminData.DeleteRateCards(rateCards);
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

        #region Social Media
        public Response GetPostDetails(string postId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                SocialMediaPost post = null;
                if (isTokenValid)
                {
                    post = AdminData.GetPostDetails(postId);
                    r.Error = false;
                    r.Status = 200;
                    if (post != null)
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = post;
                    }
                    else
                    {
                        r.Message = "Post not found";
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

        public Response GetPostReports(string postId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<PostReport> reports = null;
                if (isTokenValid)
                {
                    reports = AdminData.GetPostReports(postId);
                    r.Error = false;
                    r.Status = 200;
                    if (reports != null)
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = reports;
                    }
                    else
                    {
                        r.Message = "Reports not found";
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

        public Response GetPostLikes(string postId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<PostLikes> likes = null;
                if (isTokenValid)
                {
                    likes = AdminData.GetPostLikes(postId);
                    r.Error = false;
                    r.Status = 200;
                    if (likes != null)
                    {
                        r.Message = CommonMessages.SUCCESS;
                        r.Data = likes;
                    }
                    else
                    {
                        r.Message = "Likes not found";
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

        public Response GetAllPosts(short pageNumber, short recordsPerPage)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = TokenHelper.ValidateToken();
                List<SocialMediaPost> posts = null;
                if (isTokenValid)
                {
                    posts = AdminData.GetAllPosts(pageNumber, recordsPerPage);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (posts != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = posts;
                }
                else
                {
                    r.Error = true;
                    r.Message = string.IsNullOrEmpty(r.Message) ? "No Posts Available" : r.Message;
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
        #endregion

    }
}
