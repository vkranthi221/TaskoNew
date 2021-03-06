﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Tasko.Common;
using Tasko.Model;

namespace Tasko.Repository
{
    /// <summary>
    /// AdminData Repository class
    /// </summary>
    public static class AdminData
    {
        #region Services
        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="service">The service.</param>        
        public static void AddService(Service service)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, service.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pImageUrl", DbType.String, service.ImageURL));
            if (string.IsNullOrWhiteSpace(service.ParentServiceId))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pParentServiceId", DbType.Binary, null));
            }
            else
            {
                BinaryConverter.IsValidGuid(service.ParentServiceId, TaskoEnum.IdType.ParentServiceId);
                objParameters.Add(SqlHelper.CreateParameter("@pParentServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(service.ParentServiceId)));
            }

            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, service.Status));
            SqlHelper.ExecuteNonQuery("dbo.usp_AddService", objParameters.ToArray());
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void UpdateService(Service service)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(service.Id, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(service.Id)));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, service.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pImageUrl", DbType.String, service.ImageURL));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, service.Status));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateService", objParameters.ToArray());
        }

        /// <summary>
        /// Disables the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="status">The status.</param>
        public static void DisableService(string serviceId, short status)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, status));
            SqlHelper.ExecuteNonQuery("dbo.usp_DisableService", objParameters.ToArray());
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Is service is in Use or not</returns>
        public static bool DeleteService(string serviceId)
        {
            bool isServiceInUse = false;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));            
            isServiceInUse = (bool)SqlHelper.ExecuteScalar("dbo.usp_DeleteService", objParameters.ToArray());
            return isServiceInUse;
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>list of services</returns>
        public static List<ServiceDetail> GetAllServices()
        {
            List<ServiceDetail> services = new List<ServiceDetail>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetAllServices", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    ServiceDetail serviceDetail = new ServiceDetail();
                    serviceDetail.Service.Id = BinaryConverter.ConvertByteToString((byte[])row["SERVICE_ID"]);
                    serviceDetail.Service.Name = row["NAME"].ToString();
                    if (!(row["PARENT_SERVICE_ID"] is System.DBNull))
                    {
                        serviceDetail.Service.ParentServiceId = BinaryConverter.ConvertByteToString((byte[])row["PARENT_SERVICE_ID"]);
                    }

                    serviceDetail.Service.Status = Convert.ToInt16(row["STATUS"]);
                    serviceDetail.Service.ImageURL = row["IMAGE_URL"].ToString();
                    serviceDetail.TotalOrders = Convert.ToInt16(row["TOTAL_ORDERS"]);
                    serviceDetail.TotalVendors = Convert.ToInt16(row["TOTAL_VENDORS"]);
                    services.Add(serviceDetail);
                }
            }

            return services.Count > 0 ? services : null;
        }

        /// <summary>
        /// Gets the orders by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>list of Order summary</returns>
        public static List<OrderSummary> GetOrdersByService(string serviceId, bool isOffline)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            objParameters.Add(SqlHelper.CreateParameter("@pIsOffline", DbType.Int16, isOffline));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetOrdersByService", objParameters.ToArray());
            List<OrderSummary> orders = new List<OrderSummary>();

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.OrderId = reader["ORDER_ID"].ToString();
                order.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                order.ServiceName = reader["SERVICE_NAME"].ToString();
                order.ServiceId = serviceId;
                order.OrderStatus = reader["ORDER_STATUS_NAME"].ToString();
                order.CustomerName = reader["CUSTOMER_NAME"].ToString();
                order.VendorName = reader["VENDOR_NAME"].ToString();
                orders.Add(order);
            }

            reader.Close();

            return orders.Count > 0 ? orders : null;
        }

        /// <summary>
        /// Gets the vendors by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>list of vendors</returns>
        public static List<VendorSummary> GetVendorsByService(string serviceId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorsByService", objParameters.ToArray());
            List<VendorSummary> vendors = new List<VendorSummary>();

            while (reader.Read())
            {
                VendorSummary objVendor = new VendorSummary();
                objVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USER_NAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.UniqueId = Convert.ToInt32(reader["VENDOR_REF_ID"]);
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objVendor.IsVendorLive = Convert.ToBoolean(reader["IS_VENDOR_LIVE"]);
                vendors.Add(objVendor);
            }

            reader.Close();

            return vendors.Count > 0 ? vendors : null;
        }

        /// <summary>
        /// Gets the service overview.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Service overview object</returns>
        public static ServiceOverview GetServiceOverview(string serviceId)
        {
            ServiceOverview serviceOverview = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.String, BinaryConverter.ConvertStringToByte(serviceId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetServiceOverview", objParameters.ToArray());
            while (reader.Read())
            {
                serviceOverview = new ServiceOverview();
                if (!(reader["TOTAL_PAYMENTS"] is System.DBNull))
                {
                    serviceOverview.TotalPayments = Convert.ToDecimal(reader["TOTAL_PAYMENTS"]);
                }

                if (!(reader["WEEKLY_PAYMENTS"] is System.DBNull))
                {
                    serviceOverview.WeeklyPayments = Convert.ToDecimal(reader["WEEKLY_PAYMENTS"]);
                }

                if (!(reader["BIGGEST_PAYMENT"] is System.DBNull))
                {
                    serviceOverview.BiggestPayment = Convert.ToDecimal(reader["BIGGEST_PAYMENT"]);
                }

                if (!(reader["MONTHLY_PAYMENTS"] is System.DBNull))
                {
                    serviceOverview.MonthlyPayments = Convert.ToDecimal(reader["MONTHLY_PAYMENTS"]);
                }

                serviceOverview.ServiceName = (reader["SERVICE_NAME"]).ToString();
                serviceOverview.ServiceId = serviceId;
            }

            reader.Close();
            return serviceOverview;
        }

        #endregion

        #region Vendor

        /// <summary>
        /// Adds the Vendor.
        /// </summary>
        /// <param name="vendor">The Vendor to add</param>
        public static string AddVendor(Vendor vendor)
        {
            if (!IsVendorExists(vendor))
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                //// add the vendor address 
                string vendorAddressId = CustomerData.AddAddress(vendor.AddressDetails);

                objParameters.Add(SqlHelper.CreateParameter("@pBaseRate", DbType.Double, vendor.BaseRate));
                objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, vendor.EmailAddress));
                objParameters.Add(SqlHelper.CreateParameter("@pIsVendorLive", DbType.Boolean, vendor.IsVendorLive));
                objParameters.Add(SqlHelper.CreateParameter("@pIsVendorVerified", DbType.Boolean, vendor.IsVendorVerified));
                objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, vendor.MobileNumber));
                objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, vendor.Name));
                objParameters.Add(SqlHelper.CreateParameter("@pNoOfEmployees", DbType.Int32, vendor.NoOfEmployees));
                objParameters.Add(SqlHelper.CreateParameter("@pUserName", DbType.String, vendor.UserName));
                objParameters.Add(SqlHelper.CreateParameter("@pAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorAddressId)));
                objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, vendor.Password));
                objParameters.Add(SqlHelper.CreateParameter("@pDOB", DbType.DateTime, Convert.ToDateTime(vendor.DateOfBirth)));
                objParameters.Add(SqlHelper.CreateParameter("@pGender", DbType.Int16, vendor.Gender));
                objParameters.Add(SqlHelper.CreateParameter("@pPhoto", DbType.String, vendor.Photo));
                objParameters.Add(SqlHelper.CreateParameter("@pAreOrdersBlocked", DbType.Boolean, vendor.AreOrdersBlocked));
                objParameters.Add(SqlHelper.CreateParameter("@pIsBlocked", DbType.Boolean, vendor.IsBlocked));
                objParameters.Add(SqlHelper.CreateParameter("@pMonthlyCharge", DbType.Decimal, vendor.MonthlyCharge));
                objParameters.Add(SqlHelper.CreateParameter("@pIsPowerSeller", DbType.Boolean, vendor.IsPowerSeller));
                objParameters.Add(SqlHelper.CreateParameter("@pVendorAlsoKnownAs", DbType.String, vendor.VendorAlsoKnownAs));
                objParameters.Add(SqlHelper.CreateParameter("@pExperience", DbType.String, vendor.Experience));
                objParameters.Add(SqlHelper.CreateParameter("@pFacebookUrl", DbType.String, vendor.FacebookUrl));
                byte[] vendorId = (byte[])SqlHelper.ExecuteScalar("dbo.usp_AddVendor", objParameters.ToArray());

                string id = string.Empty;
                if (vendor.VendorServices != null && vendorId != null)
                {
                    id = BinaryConverter.ConvertByteToString(vendorId);
                    AddVendorServices(vendor.VendorServices, id);
                }

                return id;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the services of the vendor
        /// </summary>
        /// <param name="vendorId">The Vendor Id to get services</param>
        public static List<ServicesForVendor> GetServicesForVendor(string vendorId)
        {
            List<ServicesForVendor> services = new List<ServicesForVendor>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.String, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetServicesForVendor", objParameters.ToArray());
            while (reader.Read())
            {
                ServicesForVendor vendorService = new ServicesForVendor();
                vendorService.ServiceId = BinaryConverter.ConvertByteToString((byte[])reader["SERVICE_ID"]);
                vendorService.ServiceName = reader["SERVICE_NAME"].ToString();
                services.Add(vendorService);
            }

            reader.Close();
            return services.Count > 0 ? services : null;
        }

        /// <summary>
        /// Updates the services of the vendor
        /// </summary>
        /// <param name="vendorId">vendor Id</param>
        /// <param name="services">Services if vendor</param>
        /// <exception cref="Tasko.Model.UserException">Invalid Service Id</exception>
        public static void UpdateServicesForVendor(string vendorId, List<ServicesForVendor> services)
        {
            DeactivateAllVendorServices(vendorId);
            foreach (ServicesForVendor vendorService in services)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                
                BinaryConverter.IsValidGuid(vendorService.ServiceId, TaskoEnum.IdType.ServiceId);
                objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorService.ServiceId)));
                objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
                SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendorService", objParameters.ToArray());
            }
        }

        /// <summary>
        /// Deactivates all vendor services.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <exception cref="Tasko.Model.UserException">Invalid Vendor Id</exception>
        public static void DeactivateAllVendorServices(string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeactivateVendorServices", objParameters.ToArray());
        }

        public static VendorOverview GetVendorOverview(string vendorId)
        {
            VendorOverview vendorOverview = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.String, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOverview", objParameters.ToArray());
            while (reader.Read())
            {
                vendorOverview = new VendorOverview();
                vendorOverview.OrdersToday = Convert.ToInt32(reader["ORDERS_TODAY"]);
                vendorOverview.OrdersThisWeek = Convert.ToInt32(reader["ORDERS_THIS_WEEK"]);
                vendorOverview.TotalOrders = Convert.ToInt32(reader["TOTAL_ORDERS"]);
                if (reader["TOTAL_ORDER_AMOUNT"] != null && !reader["TOTAL_ORDER_AMOUNT"].Equals(DBNull.Value))
                {
                    vendorOverview.TotalOrderAmount = Convert.ToDecimal(reader["TOTAL_ORDER_AMOUNT"]);
                }
                if (reader["WEEK_ORDER_AMOUNT"] != null && !reader["WEEK_ORDER_AMOUNT"].Equals(DBNull.Value))
                {
                    vendorOverview.WeeklyOrderAmount = Convert.ToDecimal(reader["WEEK_ORDER_AMOUNT"]);
                }
                if (reader["BIGGEST_ORDER_AMOUNT"] != null && !reader["BIGGEST_ORDER_AMOUNT"].Equals(DBNull.Value))
                {
                    vendorOverview.HighestOrderAmount = Convert.ToDecimal(reader["BIGGEST_ORDER_AMOUNT"]);
                }
                if (reader["AVERAGE_MONTHLY"] != null && !reader["AVERAGE_MONTHLY"].Equals(DBNull.Value))
                {
                    vendorOverview.AverageMonthlyAmount = Convert.ToDecimal(reader["AVERAGE_MONTHLY"]);
                }
                vendorOverview.Name = reader["VENDOR_NAME"].ToString();
            }

            reader.Close();
            return vendorOverview;
        }

        public static List<VendorSummary> GetVendorsByStatus(int vendorStatus)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorStatus", DbType.Int32, vendorStatus));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorsByStatus", objParameters.ToArray());
            List<VendorSummary> vendors = new List<VendorSummary>();

            while (reader.Read())
            {
                VendorSummary objVendor = new VendorSummary();
                objVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USER_NAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objVendor.IsVendorLive = Convert.ToBoolean(reader["IS_VENDOR_LIVE"]);
                vendors.Add(objVendor);
            }

            reader.Close();

            return vendors.Count > 0 ? vendors : null;
        }

        public static void UpdateVendorDetails(Vendor vendor)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            ////Address
            if (vendor.AddressDetails != null && !string.IsNullOrEmpty(vendor.AddressDetails.AddressId))
            {
                CustomerData.UpdateAddress(vendor.AddressDetails);
            }
            
            BinaryConverter.IsValidGuid(vendor.Id, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendor.Id)));

            if (!string.IsNullOrEmpty(vendor.Name))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, vendor.Name));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, DBNull.Value));
            }

            // Mobile Number
            if (!string.IsNullOrEmpty(vendor.MobileNumber))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, vendor.MobileNumber));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, DBNull.Value));
            }

            // EmailAddress
            if (!string.IsNullOrEmpty(vendor.EmailAddress))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, vendor.EmailAddress));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, DBNull.Value));
            }

            if (vendor.Gender <= 1)
            {
                objParameters.Add(SqlHelper.CreateParameter("@pGender", DbType.String, vendor.Gender));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pGender", DbType.String, DBNull.Value));
            }

            if (vendor.DateOfBirth != null)
            {
                DateTime dob = Convert.ToDateTime(vendor.DateOfBirth);
                if (dob.Date.ToString() != "0001")
                {
                    objParameters.Add(SqlHelper.CreateParameter("@pDOB", DbType.String, vendor.DateOfBirth));
                }
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pDOB", DbType.String, DBNull.Value));
            }

            if (!string.IsNullOrEmpty(vendor.Photo))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pPhoto", DbType.String, vendor.Photo));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pPhoto", DbType.String, DBNull.Value));
            }
                        
            objParameters.Add(SqlHelper.CreateParameter("@pAreOrdersBlocked", DbType.Boolean, vendor.AreOrdersBlocked));
            objParameters.Add(SqlHelper.CreateParameter("@pIsBlocked", DbType.Boolean, vendor.IsBlocked));
            objParameters.Add(SqlHelper.CreateParameter("@pIsPowerSeller", DbType.Boolean, vendor.IsPowerSeller));
            objParameters.Add(SqlHelper.CreateParameter("@pMonthlyCharge ", DbType.Decimal, vendor.MonthlyCharge));
            objParameters.Add(SqlHelper.CreateParameter("@pFacebookUrl", DbType.String, vendor.FacebookUrl));
            objParameters.Add(SqlHelper.CreateParameter("@pIsVendorVerified", DbType.Boolean, vendor.IsVendorVerified));

            objParameters.Add(SqlHelper.CreateParameter("@pBaseRate", DbType.Double, vendor.BaseRate));
            objParameters.Add(SqlHelper.CreateParameter("@pNoOfEmployees", DbType.Int32, vendor.NoOfEmployees));
            objParameters.Add(SqlHelper.CreateParameter("@pVendorAlsoKnownAs", DbType.String, vendor.VendorAlsoKnownAs));
            objParameters.Add(SqlHelper.CreateParameter("@pExperience", DbType.String, vendor.Experience));
            
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendorDetails", objParameters.ToArray());
        }

        public static void UpdateVendorDocuments(VendorDocuments vendorDocuments)
        {
            if (vendorDocuments != null)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();

                BinaryConverter.IsValidGuid(vendorDocuments.VendorId, TaskoEnum.IdType.VendorId);
                objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorDocuments.VendorId)));
                objParameters.Add(SqlHelper.CreateParameter("@pPhotoDocTypeId", DbType.Int16, vendorDocuments.PhotoIdProofId));
                objParameters.Add(SqlHelper.CreateParameter("@pPhotoDocTypeNumber", DbType.String, vendorDocuments.PhotoIdProofNumber));

                objParameters.Add(SqlHelper.CreateParameter("@pAddressProofDocTypeId", DbType.Int16, vendorDocuments.AddressProofId));
                objParameters.Add(SqlHelper.CreateParameter("@pAddressProofDocTypeNumber", DbType.String, vendorDocuments.AddressProofNumber));
                objParameters.Add(SqlHelper.CreateParameter("@pPendingDocTypeId", DbType.Int16, vendorDocuments.PendingDocumentId));

                objParameters.Add(SqlHelper.CreateParameter("@pIsPassportSizePhoto", DbType.Boolean, vendorDocuments.IsPassportSizePhoto));
                objParameters.Add(SqlHelper.CreateParameter("@pIsRegistrationFeePaid", DbType.Boolean, vendorDocuments.IsRegistrationFeePaid));
                objParameters.Add(SqlHelper.CreateParameter("@pIsBkgrndChkInitiated", DbType.Boolean, vendorDocuments.IsBackgroundVerificationInitiated));

                SqlHelper.ExecuteNonQuery("dbo.usp_InsertUpdateVendorDocuments", objParameters.ToArray());
            }
        }

        public static VendorDocuments GetVendorDocuments(string vendorId)
        {
            VendorDocuments vendorDocuments = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorDocuments", objParameters.ToArray());
            while (reader.Read())
            {
                vendorDocuments = new VendorDocuments();
                vendorDocuments.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                vendorDocuments.VendorName = Convert.ToString(reader["VENDOR_NAME"]);
                vendorDocuments.Id = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_DOCUMENT_ID"]);
                vendorDocuments.PhotoIdProofId = Convert.ToInt16(reader["PHOTOIDPROOF_DOCUMENT_TYPE_ID"].ToString());
                vendorDocuments.PhotoIdProofName = ((Tasko.Common.TaskoEnum.DocumentProofs)vendorDocuments.PhotoIdProofId).ToString();
                vendorDocuments.PhotoIdProofNumber = Convert.ToString(reader["PHOTOIDPROOF_DOCUMENT_NUMBER"]);
                vendorDocuments.AddressProofId = Convert.ToInt16(reader["ADDRESSPROOF_DOCUMENT_TYPE_ID"]);
                vendorDocuments.AddressProofName = ((Tasko.Common.TaskoEnum.DocumentProofs)vendorDocuments.AddressProofId).ToString();
                vendorDocuments.AddressProofNumber = Convert.ToString(reader["ADDRESSPROOF_DOCUMENT_NUMBER"]);
                vendorDocuments.PendingDocumentId = Convert.ToInt16(reader["PENDING_DOCUMENT_TYPE_ID"]);
                vendorDocuments.PendingDocumentName = ((Tasko.Common.TaskoEnum.DocumentProofs)vendorDocuments.PendingDocumentId).ToString();
                vendorDocuments.IsPassportSizePhoto = Convert.ToBoolean(reader["PASSPORT_SIZE_PHOTO"]);
                vendorDocuments.IsRegistrationFeePaid = Convert.ToBoolean(reader["REGISTRATION_FEE_PAID"]);
                vendorDocuments.IsBackgroundVerificationInitiated = Convert.ToBoolean(reader["BACKGROUND_VERIFICATION_INITIATED"]);
            }

            return vendorDocuments;
        }

        #endregion

        #region Customers
        public static List<Customer> GetCustomersByStatus(int customerStatus)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, customerStatus));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllCustomersByStatus", objParameters.ToArray());
            List<Customer> customers = new List<Customer>();

            while (reader.Read())
            {
                Customer objCustomer = new Customer();
                objCustomer.Id = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                objCustomer.Name = reader["NAME"].ToString();
                objCustomer.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objCustomer.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objCustomer.RegisteredDate = Convert.ToDateTime(reader["REGISTERED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                customers.Add(objCustomer);
            }

            reader.Close();

            return customers.Count > 0 ? customers : null;
        }

        public static CustomerOverview GetCustomerOverview(string customerId)
        {
            CustomerOverview customerOverview = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.String, BinaryConverter.ConvertStringToByte(customerId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetCustomerOverview", objParameters.ToArray());
            while (reader.Read())
            {
                customerOverview = new CustomerOverview();

                customerOverview.TotalOrders = Convert.ToInt32(reader["Total_Orders"]);
                customerOverview.WeeklyOrders = Convert.ToInt32(reader["Weekly_Orders"]);
                customerOverview.TodayOrders = Convert.ToInt32(reader["Today_Orders"]);

                if (!(reader["Total_Payments"] is System.DBNull))
                {
                    customerOverview.TotalPayments = Convert.ToDecimal(reader["Total_Payments"]);
                }

                if (!(reader["Weekly_Payments"] is System.DBNull))
                {
                    customerOverview.WeeklyPayments = Convert.ToDecimal(reader["Weekly_Payments"]);
                }

                if (!(reader["Biggest_Payments"] is System.DBNull))
                {
                    customerOverview.BiggestPayments = Convert.ToDecimal(reader["Biggest_Payments"]);
                }

                if (!(reader["Monthly_Payments"] is System.DBNull))
                {
                    customerOverview.MonthlyPayments = Convert.ToDecimal(reader["Monthly_Payments"]);
                }

                customerOverview.Name = (reader["Name"]).ToString();
            }

            reader.Close();
            return customerOverview;
        }

        /// <summary>
        /// Customers the ratings for orders.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="noOfRecords">The no of records.</param>
        /// <returns>list of the Customer Ratings</returns>
        public static List<CustomerRating> CustomerRatingsForOrders(string customerId, int noOfRecords)
        {
            List<CustomerRating> customerRatings = new List<CustomerRating>();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pNoOfRecords", DbType.Int32, noOfRecords));
            IDataReader reader = SqlHelper.GetDataReader("dbo.[usp_GetCustomerRatingForOrders]", objParameters.ToArray());
            while (reader.Read())
            {
                CustomerRating rating = new CustomerRating();
                rating.CustomerName = reader["customer_name"].ToString();
                rating.VendorName = reader["vendor_name"].ToString();
                rating.OrderId = reader["order_id"].ToString();
                rating.OverAllRating = Convert.ToDecimal(reader["OVERALL_RATING"]);
                
                rating.ServiceQuality = Convert.ToDecimal(reader["SERVICE_QUALITY"]);
                rating.Punctuality = Convert.ToDecimal(reader["PUNCTUALITY"]);
                rating.Courtesy = Convert.ToDecimal(reader["COURTESY"]);
                rating.Price = Convert.ToDecimal(reader["PRICE"]);

                customerRatings.Add(rating);
            }

            reader.Close();
            return customerRatings.Count > 0 ? customerRatings : null;
        }

        /// <summary>
        /// Validates the authentication code.
        /// </summary>
        /// <param name="authCode">The authentication code.</param>
        /// <param name="isDeleteRequired">if set to <c>true</c> [is delete required].</param>
        /// <returns>Either valid Authcode or not</returns>
        /// <exception cref="Tasko.Model.UserException">Invalid Auth Code</exception>
        public static bool ValidateAuthCode(string authCode, bool isDeleteRequired)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(authCode, TaskoEnum.IdType.AuthCode);
            objParameters.Add(SqlHelper.CreateParameter("@pAuthCode", DbType.Binary, BinaryConverter.ConvertStringToByte(authCode)));

            objParameters.Add(SqlHelper.CreateParameter("@pIsDeleteRequired", DbType.Boolean, isDeleteRequired));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_ValidateAuthCode", objParameters.ToArray());
            bool isValid = false;
            if (reader.Read())
            {
                isValid = (bool)reader["IsValid"];
            }

            reader.Close();
            return isValid;
        }

        #endregion

        #region Common
        /// <summary>
        /// Adds the Vendor services.
        /// </summary>
        /// <param name="vendorServices">The Vendor services to add</param>
        /// <param name="vendorId">The Vendor Id</param>
        private static void AddVendorServices(List<ServicesForVendor> vendorServices, string vendorId)
        {
            foreach (ServicesForVendor vendorService in vendorServices)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                
                BinaryConverter.IsValidGuid(vendorService.ServiceId, TaskoEnum.IdType.ServiceId);
                objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorService.ServiceId)));
                objParameters.Add(SqlHelper.CreateParameter("@pIsActive", DbType.Boolean, vendorService.IsActive));

                BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
                objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
                SqlHelper.ExecuteNonQuery("dbo.usp_AddVendorService", objParameters.ToArray());
            }
        }

        /// <summary>
        /// Deletes the Vendor services.
        /// </summary>
        /// <param name="vendorId">The Vendor Id</param>
        private static void DeleteVendorServices(string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteVendorServices", objParameters.ToArray());
        }
        #endregion

        #region Orders
        public static List<OrderSummary> GetOrders(int orderStatusId, bool isOffline)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            //objParameters.Add(SqlHelper.CreateParameter("@pVENDORID", DbType.Binary, null));
            objParameters.Add(SqlHelper.CreateParameter("@pORDERSTATUSID", DbType.Int32, orderStatusId));
            objParameters.Add(SqlHelper.CreateParameter("@pRECORDSPERPAGE", DbType.Int32, 0));
            objParameters.Add(SqlHelper.CreateParameter("@pPAGENO", DbType.Int32, 0));
            objParameters.Add(SqlHelper.CreateParameter("@pISOFFLINE", DbType.Int16, isOffline));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOrders", objParameters.ToArray());
            List<OrderSummary> orders = new List<OrderSummary>();

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.OrderId = reader["ORDER_ID"].ToString();
                order.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                order.ServiceName = reader["SERVICENAME"].ToString();
                order.OrderStatus = reader["ORDERSTATUSNAME"].ToString();
                order.VendorName = reader["VENDOR_NAME"].ToString();

                if (!(reader["VENDOR_ID"] is System.DBNull))
                {
                    order.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                }
                
                order.CustomerName = reader["CUSTOMER_NAME"].ToString();
                if (!(reader["CUSTOMER_ID"] is System.DBNull))
                {
                    order.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                }

                order.BToBCustomerName = reader["B_TO_B_CUSTOMER_NAME"].ToString();
                orders.Add(order);
            }

            reader.Close();

            return orders.Count > 0 ? orders : null;
        }
        #endregion

        #region Dashboard

        /// <summary>
        /// Gets the dashboard recent orders by status.
        /// </summary>
        /// <param name="orderStatusId">The order status identifier.</param>
        /// <returns></returns>
        public static List<OrderSummary> GetDashboardRecentOrdersByStatus(int orderStatusId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int32, orderStatusId));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetDashboardRecentOrdersByStatus", objParameters.ToArray());
            List<OrderSummary> orders = new List<OrderSummary>();

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.OrderId = reader["ORDER_ID"].ToString();
                order.CustomerName = reader["CUSTOMER_NAME"].ToString();
                order.VendorName = reader["VENDOR_NAME"].ToString();
                order.ServiceName = reader["SERVICE_NAME"].ToString();
                order.OrderStatus = reader["ORDERSTATUS_NAME"].ToString();
                order.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                orders.Add(order);
            }

            reader.Close();

            return orders.Count > 0 ? orders : null;
        }

        /// <summary>
        /// Gets the dashboard meters.
        /// </summary>
        /// <returns>DashboardMeter Object</returns>
        public static DashboardMeter GetDashboardMeters()
        {
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetDashboardMeters");
            DashboardMeter dashboardMeter = null;

            while (reader.Read())
            {
                dashboardMeter = new DashboardMeter();
                dashboardMeter.TotalOrders = Convert.ToInt16(reader["TOTAL_ORDERS"].ToString());
                dashboardMeter.TotalVendors = Convert.ToInt16(reader["TOTAL_VENDORS"].ToString());
                dashboardMeter.TotalCustomers = Convert.ToInt16(reader["TOTAL_CUSTOMERS"].ToString());
                dashboardMeter.TotalVendorReviews = Convert.ToInt16(reader["TOTAL_VENDOR_REVIEWS"].ToString());
                dashboardMeter.TotalCustomerReviews = Convert.ToInt16(reader["TOTAL_CUSTOMER_REVIEWS"].ToString());
                dashboardMeter.TotalServices = Convert.ToInt16(reader["TOTAL_SERVICES"].ToString());
                dashboardMeter.TotalUsers = Convert.ToInt16(reader["TOTAL_USERS"].ToString());
                dashboardMeter.TotalPayments = Convert.ToDouble(reader["TOTAL_PAYMENTS"].ToString());
            }

            reader.Close();

            return dashboardMeter;
        }

        /// <summary>
        /// Gets the dashboard recent activities.
        /// </summary>
        /// <returns>list of RecentActivities</returns>
        public static List<RecentActivities> GetDashboardRecentActivities()
        {
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetDashboardRecentActivities");
            List<RecentActivities> RecentActivities = new List<RecentActivities>();

            while (reader.Read())
            {
                RecentActivities RecentActivity = new RecentActivities();
                RecentActivity.ActivityId = BinaryConverter.ConvertByteToString((byte[])reader["ACTIVITY_ID"]);
                RecentActivity.ActivityType = reader["ACTIVITY_TYPE"].ToString();

                if (!(reader["CUSTOMER_ID"] is System.DBNull))
                {
                    RecentActivity.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                }

                if (!(reader["VENDOR_ID"] is System.DBNull))
                {
                    RecentActivity.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                }

                if (!(reader["ORDER_ID"] is System.DBNull))
                {
                    RecentActivity.OrderId = reader["ORDER_ID"].ToString();
                }

                RecentActivity.Comment = reader["COMMENTS"].ToString();
                RecentActivity.TimeSince = DateHelper.RelativeDate(Convert.ToDateTime(reader["ACTIVITY_DATE"]));
                RecentActivities.Add(RecentActivity);
            }

            reader.Close();

            return RecentActivities.Count > 0 ? RecentActivities : null;
        }

        #endregion

        #region Payments

        /// <summary>
        /// Adds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public static void AddPayment(Payment payment)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(payment.VendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(payment.VendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pDueDate", DbType.Date, Convert.ToDateTime(payment.DueDate)));
            objParameters.Add(SqlHelper.CreateParameter("@pPaidDate", DbType.Date, Convert.ToDateTime(payment.PaidDate)));
            objParameters.Add(SqlHelper.CreateParameter("@pPaidAmount", DbType.Decimal, payment.Amount));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.String, payment.Status));
            objParameters.Add(SqlHelper.CreateParameter("@pDescription", DbType.String, payment.Description));
            objParameters.Add(SqlHelper.CreateParameter("@pMonth", DbType.String, payment.PayForMonth));
            SqlHelper.ExecuteNonQuery("dbo.usp_AddPayment", objParameters.ToArray());
        }

        /// <summary>
        /// Updates the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public static void UpdatePayment(Payment payment)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPaymentId", DbType.String, payment.PaymentId));
            
            BinaryConverter.IsValidGuid(payment.VendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(payment.VendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pDueDate", DbType.Date, Convert.ToDateTime(payment.DueDate)));
            objParameters.Add(SqlHelper.CreateParameter("@pPaidDate", DbType.Date, Convert.ToDateTime(payment.PaidDate)));
            objParameters.Add(SqlHelper.CreateParameter("@pPaidAmount", DbType.Decimal, payment.Amount));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.String, payment.Status));
            objParameters.Add(SqlHelper.CreateParameter("@pDescription", DbType.String, payment.Description));
            objParameters.Add(SqlHelper.CreateParameter("@pMonth", DbType.String, payment.PayForMonth));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdatePayment", objParameters.ToArray());
        }

        /// <summary>
        /// Gets all payments by status.
        /// </summary>
        /// <param name="paymentStatus">The payment status.</param>
        /// <returns>List of Payments</returns>
        public static List<Payment> GetAllPaymentsByStatus(string paymentStatus)
        {
            paymentStatus = string.IsNullOrEmpty(paymentStatus) ? string.Empty : paymentStatus;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.String, paymentStatus.ToUpper()));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllPaymentsByStatus", objParameters.ToArray());
            List<Payment> payments = new List<Payment>();

            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentId = reader["PAYMENT_ID"].ToString();
                payment.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                payment.VendorName = reader["VENDOR_NAME"].ToString();

                payment.DueDate = Convert.ToDateTime(reader["DUE_DATE"]).ToString("yyyy'-'MM'-'dd");
                payment.PaidDate = Convert.ToDateTime(reader["PAID_DATE"]).ToString("yyyy'-'MM'-'dd");
                payment.Amount = Convert.ToDouble(reader["AMOUNT"]);

                payment.Status = reader["STATUS"].ToString();
                payment.Description = reader["DESCRIPTION"].ToString();
                payment.PayForMonth = reader["MONTH"].ToString();
                payments.Add(payment);
            }

            reader.Close();

            return payments.Count > 0 ? payments : null;
        }

        /// <summary>
        /// Gets the payment invoice.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>VendorPaymentInvoice Object</returns>
        public static VendorPaymentInvoice GetPaymentInvoice(string paymentId)
        {
            VendorPaymentInvoice vendorPaymentInvoice = null;
            Payment payment = GetPayment(paymentId);
            if (payment != null && !string.IsNullOrEmpty(payment.VendorId))
            {
                vendorPaymentInvoice = new VendorPaymentInvoice();
                vendorPaymentInvoice.Payment = payment;
                vendorPaymentInvoice.VendorAddress = GetVendorAddress(payment.VendorId);
            }

            return vendorPaymentInvoice;
        }

        /// <summary>
        /// Gets the payment.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>Payment Object</returns>
        public static Payment GetPayment(string paymentId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPaymentId", DbType.String, paymentId));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetPayment", objParameters.ToArray());
            Payment payment = null;

            while (reader.Read())
            {
                payment = new Payment();
                payment.PaymentId = reader["PAYMENT_ID"].ToString();
                payment.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                payment.VendorName = reader["VENDOR_NAME"].ToString();

                payment.DueDate = Convert.ToDateTime(reader["DUE_DATE"]).ToString("yyyy'-'MM'-'dd");
                payment.PaidDate = Convert.ToDateTime(reader["PAID_DATE"]).ToString("yyyy'-'MM'-'dd");
                payment.Amount = Convert.ToDouble(reader["AMOUNT"]);
                payment.Status = reader["STATUS"].ToString();
                payment.Description = reader["DESCRIPTION"].ToString();
                payment.PayForMonth = reader["MONTH"].ToString();
            }

            reader.Close();

            return payment;
        }

        /// <summary>
        /// Gets the vendor address.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>AddressInfo Object</returns>
        public static AddressInfo GetVendorAddress(string vendorId)
        {
            AddressInfo vendorAddress = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorAddress", objParameters.ToArray());

            while (reader.Read())
            {
                vendorAddress = new AddressInfo();
                vendorAddress.AddressId = BinaryConverter.ConvertByteToString((byte[])reader["Address_ID"]);
                vendorAddress.AddressType = reader["ADDRESS_TYPE"].ToString();
                vendorAddress.Country = reader["COUNTRY"].ToString();
                vendorAddress.State = reader["STATE"].ToString();
                vendorAddress.City = reader["CITY"].ToString();
                vendorAddress.Locality = reader["LOCALITY"].ToString();
                vendorAddress.Address = reader["ADDRESS"].ToString();
                vendorAddress.Pincode = reader["PINCODE"].ToString();
                vendorAddress.Lattitude = reader["LATITIUDE"].ToString();
                vendorAddress.Longitude = reader["LONGITUDE"].ToString();
                if (!(reader["HOME_LATITIUDE"] is System.DBNull))
                {
                    vendorAddress.HomeLattitude = reader["HOME_LATITIUDE"].ToString();
                }

                if (!(reader["HOME_LONGITUDE"] is System.DBNull))
                {
                    vendorAddress.HomeLongitude = reader["HOME_LONGITUDE"].ToString();
                }
            }

            reader.Close();

            return vendorAddress;
        }

        /// <summary>
        /// Gets all vendors summary.
        /// </summary>
        /// <returns>list of vendor Summary</returns>
        public static List<VendorSummary> GetAllVendorsSummary()
        {
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllVendorsSummary");
            List<VendorSummary> vendors = new List<VendorSummary>();

            while (reader.Read())
            {
                VendorSummary objVendor = new VendorSummary();
                objVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USER_NAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.UniqueId = Convert.ToInt32(reader["VENDOR_REF_ID"]);
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objVendor.IsVendorLive = Convert.ToBoolean(reader["IS_VENDOR_LIVE"]);
                objVendor.MonthlyCharge = Convert.ToDouble(reader["MONTHLY_CHARGE"]);
                if (reader["DUE_DATE"] is System.DBNull)
                {
                    objVendor.DueDate = Convert.ToDateTime(reader["REGISTERED_DATE"]).AddMonths(1).ToString("yyyy'-'MM'-'dd");
                }
                else
                {
                    objVendor.DueDate = Convert.ToDateTime(reader["DUE_DATE"]).AddMonths(1).ToString("yyyy'-'MM'-'dd");
                }

                vendors.Add(objVendor);
            }

            reader.Close();

            return vendors.Count > 0 ? vendors : null;
        }

        /// <summary>
        /// Determines whether [is vendor exist] [the specified phone number].
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>true/false</returns>
        public static bool IsVendorExists(Vendor vendor)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pUsername", DbType.String, vendor.UserName));
            objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, vendor.MobileNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, vendor.EmailAddress));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_IsVendorExists", objParameters.ToArray());
            bool isVendorExists = false;
            if (reader.Read())
            {
                isVendorExists = (bool)reader["IsVendorExists"];
            }

            reader.Close();
            return isVendorExists;
        }

        #endregion

        #region User
        public static string AddUser(User user)
        {
            string userId = string.Empty;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pUserName", DbType.String, user.UserName));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, user.PassWord));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, user.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailId", DbType.String, user.EmailId));
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, user.MobileNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pIsAdmin", DbType.Boolean, user.IsAdmin));
            objParameters.Add(SqlHelper.CreateParameter("@pIsActive", DbType.Boolean, user.IsActive));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_AddUser", objParameters.ToArray());
            while (reader.Read())
            {
                if (reader["User_Id"] is System.DBNull)
                {
                    userId = string.Empty;
                }
                else
                {
                    userId = BinaryConverter.ConvertByteToString((byte[])reader["User_ID"]);
                }
            }

            reader.Close();
            return userId;
        }

        public static List<User> GetAllUsers()
        {
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllUsers");
            List<User> users = new List<User>();

            while (reader.Read())
            {
                //USER_ID, USER_NAME,NAME, PASSWORD,EMAIL_ADDRESS, MOBILE_NUMBER, ISADMIN, JOINED_DATE, ISACTIVE
                User user = new User();
                user.Id = BinaryConverter.ConvertByteToString((byte[])reader["USER_ID"]);
                user.Name = reader["NAME"].ToString();
                user.PassWord = reader["PASSWORD"].ToString();
                user.EmailId = reader["EMAIL_ADDRESS"].ToString();
                user.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                user.IsAdmin = (bool)reader["ISADMIN"];
                user.JoinedDate = Convert.ToDateTime(reader["JOINED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                user.IsActive = (bool)reader["ISACTIVE"];
                users.Add(user);
            }

            reader.Close();

            return users.Count > 0 ? users : null;
        }

        public static User GetUserDetails(string userId)
        {
            User user = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(userId, TaskoEnum.IdType.UserId);
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetUserDetails", objParameters.ToArray());

            if (reader.Read())
            {
                user = new User();
                //USER_ID, USER_NAME,NAME, PASSWORD,EMAIL_ADDRESS, MOBILE_NUMBER, ISADMIN, JOINED_DATE, ISACTIVE
                user.Id = BinaryConverter.ConvertByteToString((byte[])reader["USER_ID"]);
                user.Name = reader["NAME"].ToString();
                user.UserName = reader["USER_NAME"].ToString();
                user.PassWord = reader["PASSWORD"].ToString();
                user.EmailId = reader["EMAIL_ADDRESS"].ToString();
                user.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                user.IsAdmin = (bool)reader["ISADMIN"];
                user.IsActive = (bool)reader["ISACTIVE"];
                user.JoinedDate = Convert.ToDateTime(reader["JOINED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");

            }

            reader.Close();

            return user;
        }

        public static void DeleteUser(string userId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(userId, TaskoEnum.IdType.UserId);
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteUser", objParameters.ToArray());
        }

        public static LoginInfo LoginAdminUser(string userName, string password)
        {
            string tokenCode = string.Empty;
            LoginInfo loginInfo = new LoginInfo();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pUserName", DbType.String, userName));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, password));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_LoginAdminUser", objParameters.ToArray());
            
            if (reader.Read())
            {
                loginInfo.TokenId = BinaryConverter.ConvertByteToString((byte[])reader["Token_Code"]);
                if (!(reader["UserId"] is System.DBNull))
                {
                    loginInfo.UserId = BinaryConverter.ConvertByteToString((byte[])reader["UserId"]);
                }
            }

            reader.Close();
            return loginInfo;
        }

        public static void UpdateUserStatus(string userId, bool isActive)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(userId, TaskoEnum.IdType.UserId);
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            objParameters.Add(SqlHelper.CreateParameter("@pIsActive", DbType.Boolean, isActive));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateUserStatus", objParameters.ToArray());
        }

        #endregion

        #region Complaint

        public static List<Complaint> GetAllComplaints(int customerStatus)
        {
            List<Complaint> complaints = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerStatus", DbType.Int32, customerStatus));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetComplaints", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                complaints = new List<Complaint>();
                foreach (DataRow row in datatable.Rows)
                {
                    Complaint complaint = new Complaint();
                    complaint.ComplaintId = row["Complaint_Id"].ToString();
                    complaint.ComplaintStatus = Convert.ToInt32(row["Complaint_Status"]);
                    complaint.LoggedDate = Convert.ToDateTime(row["Logged_On_Date"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    complaint.Title = row["Title"].ToString();
                    complaints.Add(complaint);
                }
            }

            return complaints;
        }
        #endregion

        #region Notifications
        
        public static List<GcmUser> GetAllGCMUsers()
        {
            List<GcmUser> gcmUsers = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetAllGCMUsers", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                gcmUsers = new List<GcmUser>();
                foreach (DataRow row in datatable.Rows)
                {
                    GcmUser gcmUser = new GcmUser();
                    gcmUser.GcmId = BinaryConverter.ConvertByteToString((byte[])row["GCMID"]);
                    gcmUser.Name = row["NAME"].ToString();
                    gcmUser.GcmRegId = row["GCMREGID"].ToString();
                    //byte[] vendorId = null;
                    //byte.TryParse(row["VENDOR_ID"].ToString(), out vendorId);
                    if (row["VENDOR_ID"] != null && !string.IsNullOrEmpty(row["VENDOR_ID"].ToString()))
                    {
                        gcmUser.VendorId = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_ID"]);
                    }
                    else
                    {
                        gcmUser.CustomerId = BinaryConverter.ConvertByteToString((byte[])row["CUSTOMER_ID"]);
                    }
                    gcmUsers.Add(gcmUser);
                }
            }

            return gcmUsers;
        }

        #endregion

        #region Offline Vendor Request
        public static List<OfflineVendorRequest> GetOffileVendorRequests()
        {
            List<OfflineVendorRequest> requests = new List<OfflineVendorRequest>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetOffileVendorRequests", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    OfflineVendorRequest request = new OfflineVendorRequest();
                    request.Id = BinaryConverter.ConvertByteToString((byte[])row["Id"]);
                    request.CustomerName = row["CustomerName"].ToString();
                    request.CustomerPhone = row["CustomerPhone"].ToString();
                    request.RequestedServiceId = BinaryConverter.ConvertByteToString((byte[])row["RequestedServiceId"]);
                    request.RequestedServiceName = row["RequestedServiceName"].ToString();
                    requests.Add(request);
                }
            }

            return requests.Count > 0 ? requests : null;
        }
        #endregion

        #region Regions
        public static void AddCities(List<City> cities)
        {
            foreach (City city in cities)
            {
                BinaryConverter.IsValidGuid(city.StateId, TaskoEnum.IdType.StateId);
                List<SqlParameter> objParameters = new List<SqlParameter>();
                objParameters.Add(SqlHelper.CreateParameter("@pStateId", DbType.Binary, BinaryConverter.ConvertStringToByte(city.StateId)));
                objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.Boolean, city.Name));
                SqlHelper.ExecuteNonQuery("dbo.usp_AddCity", objParameters.ToArray());
            }
        }

        public static bool AddState(State state)
        {
            bool isStateAlreadyExists;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, state.Name));
            isStateAlreadyExists = (bool)SqlHelper.ExecuteScalar("dbo.usp_AddState", objParameters.ToArray());
            return isStateAlreadyExists;
        }

        public static List<City> GetCities(string stateId)
        {
            List<City> cities = new List<City>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(stateId))
            {
                BinaryConverter.IsValidGuid(stateId, TaskoEnum.IdType.StateId);
            }

            if (string.IsNullOrEmpty(stateId))
            {
                IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllCities", objParameters.ToArray());
                while (reader.Read())
                {
                    City city = new City();
                    city.Id = BinaryConverter.ConvertByteToString((byte[])reader["ID"]);
                    city.Name = reader["Name"].ToString();
                    city.StateId = BinaryConverter.ConvertByteToString((byte[])reader["StateId"]);
                    cities.Add(city);
                }

                reader.Close();
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pStateId", DbType.Binary, BinaryConverter.ConvertStringToByte(stateId)));
                IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetCities", objParameters.ToArray());
                while (reader.Read())
                {
                    City city = new City();
                    city.Id = BinaryConverter.ConvertByteToString((byte[])reader["ID"]);
                    city.Name = reader["Name"].ToString();
                    city.StateId = BinaryConverter.ConvertByteToString((byte[])reader["StateId"]);
                    cities.Add(city);
                }

                reader.Close();
            }

           
            return cities.Count > 0 ? cities : null;
        }

        public static void DeleteCities(List<string> cities)
        {
            foreach (string city in cities)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                BinaryConverter.IsValidGuid(city, TaskoEnum.IdType.CityId);
                objParameters.Add(SqlHelper.CreateParameter("@pCityId", DbType.Binary, BinaryConverter.ConvertStringToByte(city)));
                SqlHelper.ExecuteNonQuery("dbo.usp_DeleteCities", objParameters.ToArray());
            }
        }

        public static List<State> GetStates()
        {
            List<State> states = new List<State>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetStates", objParameters.ToArray());
            while (reader.Read())
            {
                State state = new State();
                state.Id = BinaryConverter.ConvertByteToString((byte[])reader["Id"]);
                state.Name = reader["Name"].ToString();
                states.Add(state);
            }

            reader.Close();
            return states.Count > 0 ? states : null;
        }
        #endregion

        #region Rate Card
        public static void AddRateCards(List<RateCard> rateCards)
        {
            foreach (RateCard rateCard in rateCards)
            {
                BinaryConverter.IsValidGuid(rateCard.CityId, TaskoEnum.IdType.CityId);
                BinaryConverter.IsValidGuid(rateCard.ServiceId, TaskoEnum.IdType.ServiceId);
                List<SqlParameter> objParameters = new List<SqlParameter>();
                objParameters.Add(SqlHelper.CreateParameter("@pCityId", DbType.Binary, BinaryConverter.ConvertStringToByte(rateCard.CityId)));
                objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(rateCard.ServiceId)));
                objParameters.Add(SqlHelper.CreateParameter("@pPrice", DbType.Decimal, rateCard.Price));
                SqlHelper.ExecuteNonQuery("dbo.usp_AddRateCard", objParameters.ToArray());
            }
        }

        public static List<RateCard> GetRateCardsForCity(string cityId, string parentServiceId)
        {
            List<RateCard> rateCards = new List<RateCard>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(cityId))
            {
                BinaryConverter.IsValidGuid(cityId, TaskoEnum.IdType.CityId);
            }
            if (!string.IsNullOrEmpty(parentServiceId))
            {
                BinaryConverter.IsValidGuid(parentServiceId, TaskoEnum.IdType.ServiceId);
            }

            objParameters.Add(SqlHelper.CreateParameter("@pCityId", DbType.Binary, BinaryConverter.ConvertStringToByte(cityId)));
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(parentServiceId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetRateCardsForCity", objParameters.ToArray());
            while (reader.Read())
            {
                RateCard rateCard = new RateCard();
                rateCard.Id = BinaryConverter.ConvertByteToString((byte[])reader["Id"]);
                rateCard.ServiceId = BinaryConverter.ConvertByteToString((byte[])reader["ServiceId"]);
                rateCard.CityId = BinaryConverter.ConvertByteToString((byte[])reader["CityId"]);
                rateCard.Price = Convert.ToDecimal(reader["AmountCharged"]);
                rateCard.ServiceName = reader["ServiceName"].ToString();
                rateCard.CityName = reader["CityName"].ToString();
                rateCards.Add(rateCard);
            }

            reader.Close();
            return rateCards.Count > 0 ? rateCards : null;
        }

        public static void UpdateRateCards(List<RateCard> rateCards)
        {
            foreach (RateCard rateCard in rateCards)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                BinaryConverter.IsValidGuid(rateCard.CityId, TaskoEnum.IdType.CityId);
                BinaryConverter.IsValidGuid(rateCard.ServiceId, TaskoEnum.IdType.ServiceId);
                objParameters.Add(SqlHelper.CreateParameter("@pCityId", DbType.Binary, BinaryConverter.ConvertStringToByte(rateCard.CityId)));
                objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(rateCard.ServiceId)));
                objParameters.Add(SqlHelper.CreateParameter("@pPrice", DbType.Decimal, rateCard.Price));
                SqlHelper.ExecuteNonQuery("dbo.usp_UpdateRateCards", objParameters.ToArray());
            }
        }

        public static void DeleteRateCards(List<string> rateCards)
        {
            foreach (string rateCard in rateCards)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                BinaryConverter.IsValidGuid(rateCard, TaskoEnum.IdType.RateCardId);
                objParameters.Add(SqlHelper.CreateParameter("@pRateCardId", DbType.Binary, BinaryConverter.ConvertStringToByte(rateCard)));
                SqlHelper.ExecuteNonQuery("dbo.usp_DeleteRateCards", objParameters.ToArray());
            }
        }


        public static void DeleteStates(List<string> states)
        {
            foreach (string state in states)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                BinaryConverter.IsValidGuid(state, TaskoEnum.IdType.StateId);
                objParameters.Add(SqlHelper.CreateParameter("@pStateId", DbType.Binary, BinaryConverter.ConvertStringToByte(state)));
                SqlHelper.ExecuteNonQuery("dbo.usp_DeleteStates", objParameters.ToArray());
            }
        }
        #endregion

        #region Social Media
        public static SocialMediaPost GetPostDetails(string postId)
        {
            SocialMediaPost post = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(postId, TaskoEnum.IdType.UserId);
            objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(postId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetPostDetails", objParameters.ToArray());

            if (reader.Read())
            {
                post = new SocialMediaPost();
                post.Id = BinaryConverter.ConvertByteToString((byte[])reader["ID"]);
                post.Message = reader["MESSAGE"].ToString();
                post.Views = Convert.ToInt32(reader["VIEWS"]);
                post.Likes = Convert.ToInt32(reader["LIKES"]);
                post.ImageUrls = new List<string>();
                objParameters = new List<SqlParameter>();
                objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(post.Id)));
                DataTable urlDatatable = SqlHelper.GetDataTable("dbo.usp_GetVendorPostsURL", objParameters.ToArray());
                if (urlDatatable != null && urlDatatable.Rows.Count > 0)
                {
                    foreach (DataRow urlRow in urlDatatable.Rows)
                    {
                        post.ImageUrls.Add(urlRow["IMAGEURL"].ToString());
                    }
                }

            }

            reader.Close();

            return post;
        }
       

        public static List<PostReport> GetPostReports(string postId)
        {
             List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(postId, TaskoEnum.IdType.SocialMediaPostId);
            objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(postId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetPostReports", objParameters.ToArray());
            List<PostReport> reports = new List<PostReport>();

            while (reader.Read())
            {
                PostReport report = new PostReport();
                report.Id = BinaryConverter.ConvertByteToString((byte[])reader["ID"]);
                report.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                report.PostId = BinaryConverter.ConvertByteToString((byte[])reader["POST_ID"]);
                report.ReportedDate = Convert.ToDateTime(reader["REPORTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                report.Reason = reader["REASON"].ToString();
                report.Comments = reader["COMMENT"].ToString();
                reports.Add(report);
            }

            reader.Close();

            return reports.Count > 0 ? reports : null;
        }
        
        public static List<PostLikes> GetPostLikes(string postId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(postId, TaskoEnum.IdType.SocialMediaPostId);
            objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(postId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetPostLikes", objParameters.ToArray());
            List<PostLikes> likes = new List<PostLikes>();

            while (reader.Read())
            {
                PostLikes like = new PostLikes();
                like.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMERID"]);
                like.LikedDate = Convert.ToDateTime(reader["LIKED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                like.CustomerName = reader["NAME"].ToString();
                likes.Add(like);
            }

            reader.Close();

            return likes.Count > 0 ? likes : null;
        }
        #endregion

        public static List<SocialMediaPost> GetAllPosts(short pageNumber, short recordsPerPage)
        {
            List<SocialMediaPost> posts = new List<SocialMediaPost>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPageNo", DbType.Int16, pageNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pRecordsPerPage", DbType.Int16, recordsPerPage));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetAllPosts", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    SocialMediaPost post = new SocialMediaPost();
                    post.Id = BinaryConverter.ConvertByteToString((byte[])row["ID"]);
                    post.Message = row["MESSAGE"].ToString();
                    post.Views = Convert.ToInt32(row["VIEWS"]);
                    post.Likes = Convert.ToInt32(row["LIKES"]);
                    if (row["POSTED_DATE"] != DBNull.Value)
                    {
                        post.PostedDate = Convert.ToDateTime(row["POSTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    }
                    post.VendorName = row["NAME"].ToString();
                    posts.Add(post);
                }
            }

            return posts;
        }
    }
}
