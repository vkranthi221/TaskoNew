using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasko.Model;
using Tasko.Common;

namespace Tasko.Repository
{
    public static class VendorData
    {
        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>vendor details</returns>
        public static Vendor GetVendor(string vendorId)
        {
            Vendor objVendor = new Vendor();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorDetails", objParameters.ToArray());
            if (reader.Read())
            {
                objVendor.Id = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.Name = reader["NAME"].ToString();
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.Address = reader["ADDRESS"].ToString();
                objVendor.NoOfEmployees = Convert.ToInt32(reader["EMPLOYEE_COUNT"]);
                objVendor.BaseRate = Convert.ToDouble(reader["BASE_RATE"]);
                objVendor.IsVendorVerified = Convert.ToBoolean(reader["IS_VENDOR_VERIFIED"]);
                ////objVendor.TimeSpentOnApp = Convert.ToDateTime(reader["TIME_SPENT_ON_APP"]);
                ////objVendor.ActiveTimePerDay = Convert.ToDateTime(reader["ACTIVE_TIME_PER_DAY"]);
                objVendor.DataConsumption = Convert.ToInt32(reader["DATA_CONSUMPTION"]);
                objVendor.CallsToCustomerCare = Convert.ToInt32(reader["CALLS_TO_CUSTOMER_CARE"]);
            }

            reader.Close();

            return objVendor;
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Order details</returns>
        public static Order GetOrderDetails(string orderId)
        {
            Order objOrder = new Order();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetOrderDetails", objParameters.ToArray());
            if (reader.Read())
            {
                objOrder.OrderId = reader["ORDER_ID"].ToString();

                objOrder.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                objOrder.CustomerName = reader["CUSTOMER_NAME"].ToString();

                objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_SERVICE_ID"]);
                objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objOrder.VendorName = reader["VENDOR_NAME"].ToString();

                objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])reader["SERVICE_ID"]);
                objOrder.ServiceName = reader["SERVICE_NAME"].ToString();

                objOrder.OrderStatusId = Convert.ToInt16(reader["ORDER_STATUS_ID"]);
                objOrder.OrderStatus = reader["ORDERSTATUS_NAME"].ToString();

                objOrder.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]);
                objOrder.Location = reader["ORDER_LOCATION"].ToString();
            }

            reader.Close();

            return objOrder;
        }

        /// <summary>
        /// Updates the vendor services.
        /// </summary>
        /// <param name="vendorServices">The vendor services.</param>
        public static void UpdateVendorServices(List<VendorService> vendorServices)
        {
            foreach (VendorService vendorService in vendorServices)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();

                objParameters.Add(SqlHelper.CreateParameter("@pVendorServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorService.Id)));
                objParameters.Add(SqlHelper.CreateParameter("@pActivateService", DbType.Boolean, vendorService.IsActive));
                SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendorServices", objParameters.ToArray());
            }
        }

        /// <summary>
        /// Gets the vendor services.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>list of vendor services</returns>
        public static List<VendorService> GetVendorServices(string vendorId)
        {
            List<VendorService> vendorServices = new List<VendorService>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetVendorServices", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    VendorService service = new VendorService();
                    service.Id = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_SERVICE_ID"]);
                    service.Name = row["SERVICE_NAME"].ToString();
                    service.IsActive = Convert.ToBoolean(row["IS_VENDOR_SERVICE_ACTIVE"]);
                    vendorServices.Add(service);
                }
            }

            return vendorServices;
        }

        /// <summary>
        /// Gets the vendor sub services.
        /// </summary>
        /// <param name="vendorServiceId">The vendor service identifier.</param>
        /// <returns>list of vendor sub services</returns>
        public static List<VendorService> GetVendorSubServices(string vendorServiceId)
        {
            List<VendorService> vendorServices = new List<VendorService>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pVendorServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorServiceId)));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetVendorSubServices", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    VendorService service = new VendorService();
                    service.Id = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_SERVICE_ID"]);
                    service.Name = row["SERVICE_NAME"].ToString();
                    service.IsActive = Convert.ToBoolean(row["IS_VENDOR_SERVICE_ACTIVE"]);
                    vendorServices.Add(service);
                }
            }

            return vendorServices;
        }

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderStatus">The order status.</param>
        public static void UpdateOrderStatus(string orderId, short orderStatus)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderStatus", DbType.Int16, orderStatus));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateOrderStatus", objParameters.ToArray());
        }

        /// <summary>
        /// Updates the vendor base rate.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="baseRate">The base rate.</param>
        public static void UpdateVendorBaseRate(string vendorId, double baseRate)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pBaseRate", DbType.Decimal, baseRate));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateBaseRate", objParameters.ToArray());
        }
    }
}
