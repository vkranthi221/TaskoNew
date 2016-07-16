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

        /// <summary>
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        /// * @api {post} a1/GetServiceOverview Get Service Overview
        /// * @apiName GetServiceOverview
        /// * @apiGroup Admin
        /// *
        /// * @apiHeader {string} Token_Code Token Code
        /// * @apiHeader {string} User_Id User Id
        /// * @apiHeader {string} Content-Type application/json
        /// *
        /// * @apiHeaderExample {json} Header-Example:
        /// *  {
        /// *    "Token_Code": "Unique Token code that is generated after login" ,
        /// *    "User_Id": "Logged in User ID",
        /// *    "Content-Type": "application/json"
        /// *  }
        /// * @apiParam {string} serviceId Service Id.
        /// *
        /// * @apiParamExample {json} Param-Example:
        /// * {
        /// *   "serviceId":"6786E5D449D6B74396E8ADAEA1C17E37"
        /// * }
        /// *
        /// * @apiSuccessExample Success-Response:
        /// {
        /// "Data": {
        /// "__type": "ServiceOverview:#Tasko.Model",
        /// "BiggestPayment": 600,
        /// "MonthlyPayments": 3750,
        /// "ServiceId": "43FFEE168D9E3C4B9FC28B263AA403F7",
        /// "ServiceName": "Microwave Service",
        /// "TotalPayments": 3750,
        /// "WeeklyPayments": 3750
        /// },
        /// "Error": false,
        /// "Message": "Success",
        /// "Status": 200
        /// }
        /// * @apiError INVALID_TOKEN_CODE Invalid token code.
        /// *
        /// * @apiErrorExample Error-Response:
        /// {
        /// "Data": null,
        /// "Error": true,
        /// "Message": "Invalid token code",
        /// "Status": 400
        /// }
        /// * @apiError NO_SERVICES_EXIST No Payments found for the selected service.
        /// *
        /// * @apiErrorExample Error-Response:
        /// {
        /// "Data": null,
        /// "Error": true,
        /// "Message": "No Payments found for the selected service",
        /// "Status": 400
        /// }
        public Response GetServiceOverview(string serviceId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
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

        public Response UpdateVendorDetails(Vendor vendor)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
                if (isTokenValid)
                {
                    AdminData.UpdateVendorDetails(vendor);
                    r.Data = null;
                    r.Error = false;
                    r.Status = 200;
                    r.Message = CommonMessages.NO_VENDORS;
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
                   List<Customer> customers = AdminData.GetCustomersByStatus(customerStatus);
                   r.Data = customers;
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

        public Response GetCustomerRatingsForOrders(string customerId, int noOfRecords) 
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
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

        public Response GetCustomerOverview(string customerId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
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
                bool isTokenValid = ValidateToken();
                User objUser = null;
                if (isTokenValid)
                {
                    objUser = AdminData.GetUserDetails(userId);
                }
                else
                {
                    r.Message = CommonMessages.INVALID_TOKEN_CODE;
                }

                if (objUser != null)
                {
                    r.Error = false;
                    r.Message = CommonMessages.SUCCESS;
                    r.Status = 200;
                    r.Data = objUser;
                }
                else
                {
                    r.Error = true;
                    r.Message = CommonMessages.USER_NOT_FOUND;
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

        public Response DeleteUser(string userId)
        {
            Response r = new Response();
            try
            {
                bool isTokenValid = ValidateToken();
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
            catch (Exception ex)
            {
                r.Message = CommonMessages.FAIL;
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
                bool isTokenValid = AdminData.ValidateAuthCode(authCode, true);
                if (isTokenValid)
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

        #region Complaints

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
