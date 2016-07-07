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
                objParameters.Add(SqlHelper.CreateParameter("@pParentServiceId", DbType.Binary, DBNull.Value));
            }
            else
            {
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

            return services;            
        }

        /// <summary>
        /// Gets the orders by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>list of Order summary</returns>
        public static List<OrderSummary> GetOrdersByService(string serviceId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));            
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

            return orders;
        }

        /// <summary>
        /// Gets the vendors by service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>list of vendors</returns>
        public static List<VendorSummary> GetVendorsByService(string serviceId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorsByService", objParameters.ToArray());
            List<VendorSummary> vendors = new List<VendorSummary>();

            while (reader.Read())
            {
                VendorSummary objVendor = new VendorSummary();
                objVendor.Id = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USER_NAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objVendor.IsVendorLive = Convert.ToBoolean(reader["IS_VENDOR_LIVE"]);
                vendors.Add(objVendor);
            }

            reader.Close();

            return vendors;
        }
        #endregion

        #region Vendor

        /// <summary>
        /// Adds the Vendor.
        /// </summary>
        /// <param name="vendor">The Vendor to add</param>
        public static void AddVendor(Vendor vendor)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            //// add the vendor address 
            string vendorAddressId = CustomerData.AddAddress(vendor.AddressDetails);
            
            XmlSerializer xmlSerializer = new XmlSerializer(vendor.VendorDetails.GetType());
            string vendorDetailsXml = string.Empty;
            using (StringWriter sw = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sw))
            {
                xmlSerializer.Serialize(writer, vendor.VendorDetails);
                vendorDetailsXml = sw.ToString(); // Your XML
            }

            objParameters.Add(SqlHelper.CreateParameter("@pVendorDetails", DbType.Xml, vendorDetailsXml));
            objParameters.Add(SqlHelper.CreateParameter("@pBaseRate", DbType.Double, vendor.BaseRate));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, vendor.EmailAddress));
            objParameters.Add(SqlHelper.CreateParameter("@pIsVendorLive", DbType.Boolean, vendor.IsVendorLive));
            objParameters.Add(SqlHelper.CreateParameter("@pIsVendorVerified", DbType.Boolean, vendor.IsVendorVerified));
            objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, vendor.MobileNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, vendor.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pNoOfEmployees", DbType.Int32, vendor.NoOfEmployees));
            //objParameters.Add(SqlHelper.CreateParameter("@pTimeSpentOnApp", DbType.String, vendor.TimeSpentOnApp));
            objParameters.Add(SqlHelper.CreateParameter("@pUserName", DbType.String, vendor.UserName));
            objParameters.Add(SqlHelper.CreateParameter("@pAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorAddressId)));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, vendor.Password));
            objParameters.Add(SqlHelper.CreateParameter("@pDOB", DbType.DateTime, vendor.DateOfBirth));
            objParameters.Add(SqlHelper.CreateParameter("@pGender", DbType.Int16, vendor.Gender));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.Int16, vendor.Password));
            //objParameters.Add(SqlHelper.CreateParameter("@pPhoto", DbType.varbin, vendor.Photo));
            //objParameters.Add(SqlHelper.CreateParameter("@pActiveTimePerDay", DbType.String, vendor.ActiveTimePerDay));
            //objParameters.Add(SqlHelper.CreateParameter("@pDataConsumption", DbType.Int32, vendor.DataConsumption));
            //objParameters.Add(SqlHelper.CreateParameter("@pCallsToCustomerCare", DbType.Int32, vendor.CallsToCustomerCare));
            byte[] vendorId = (byte[])SqlHelper.ExecuteScalar("dbo.usp_AddVendor", objParameters.ToArray());

            if (vendor.VendorServices != null && vendorId != null)
            {
                string id = BinaryConverter.ConvertByteToString(vendorId);
                AddVendorServices(vendor.VendorServices, id);
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
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.String, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetServicesForVendor", objParameters.ToArray());
            while (reader.Read())
            {
                ServicesForVendor vendorService = new ServicesForVendor();
                vendorService.ServiceId = BinaryConverter.ConvertByteToString((byte[])reader["SERVICE_ID"]);
                vendorService.ServiceName = reader["SERVICE_NAME"].ToString();
                services.Add(vendorService);
            }

            return services;
        }

        /// <summary>
        /// Updates the services of the vendor
        /// </summary>
        /// <param name="vendorId">vendor Id</param>
        /// <param name="services">Services if vendor</param>
        public static void UpdateServicesForVendor(string vendorId, List<ServicesForVendor> services)
        {
            DeleteVendorServices(vendorId);
            AddVendorServices(services, vendorId);
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
                vendorOverview.AverageMonthlyAmount = 1;
            }

            return vendorOverview;
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
                objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorService.ServiceId)));
                objParameters.Add(SqlHelper.CreateParameter("@pIsActive", DbType.Boolean, vendorService.IsActive));
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
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteVendorServices", objParameters.ToArray());
        }
        #endregion

        #region Orders
        public static List<OrderSummary> GetOrders(int orderStatusId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            //objParameters.Add(SqlHelper.CreateParameter("@pVENDORID", DbType.Binary, null));
            objParameters.Add(SqlHelper.CreateParameter("@pORDERSTATUSID", DbType.Int32, orderStatusId));
            objParameters.Add(SqlHelper.CreateParameter("@pRECORDSPERPAGE", DbType.Int32, 0));
            objParameters.Add(SqlHelper.CreateParameter("@pPAGENO", DbType.Int32, 0));
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
                order.CustomerName = reader["CUSTOMER_NAME"].ToString();
                orders.Add(order);
            }

            reader.Close();

            return orders;
        }
        #endregion
    }
}
