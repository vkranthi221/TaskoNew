using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasko.Common;
using Tasko.Model;

namespace Tasko.Repository
{
    /// <summary>
    /// AdminData Repository class
    /// </summary>
    public static class AdminData
    {
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
    }
}
