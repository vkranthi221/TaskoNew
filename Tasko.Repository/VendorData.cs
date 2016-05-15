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

                objOrder.OrderStatusId = BinaryConverter.ConvertByteToString((byte[])reader["ORDER_STATUS_ID"]);
                objOrder.OrderStatus = reader["ORDERSTATUS_NAME"].ToString();

                objOrder.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]);
                objOrder.Location = reader["ORDER_LOCATION"].ToString();
            }

            reader.Close();

            return objOrder;
        }

        //public static void EnableServices(string vendorServiceId)
        //{
        //    List<SqlParameter> objParameters = new List<SqlParameter>();

        //    objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
        //    SqlHelper.ExecuteNonQuery("dbo.usp_GetOrderDetails", objParameters.ToArray());
        //}

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

        public static void UpdateOrderStatus(string orderId, short orderStatus)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderStatus", DbType.Int16, orderStatus));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateOrderStatus", objParameters.ToArray());
        }
    }
}
