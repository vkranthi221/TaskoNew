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
    /// CustomerData Class
    /// </summary>
    public static class CustomerData
    {
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
            DataSet dataSet = SqlHelper.GetDataSet("dbo.usp_GetOrderDetails", objParameters.ToArray());

            if (dataSet != null && dataSet.Tables.Count == 3)
            {
                //// Order Table Info
                DataTable ObjOrderInfo = dataSet.Tables[0];

                if (ObjOrderInfo != null && ObjOrderInfo.Rows.Count > 0)
                {
                    objOrder.OrderId = ObjOrderInfo.Rows[0]["ORDER_ID"].ToString();

                    objOrder.CustomerId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["CUSTOMER_ID"]);
                    objOrder.CustomerName = ObjOrderInfo.Rows[0]["CUSTOMER_NAME"].ToString();

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]);
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                }

                //// Get the source Address
                objOrder.SourceAddress = GetAddress(dataSet.Tables[1]);

                //// Get the Destination Address
                objOrder.DestinationAddress = GetAddress(dataSet.Tables[2]);
            }

            return objOrder;
        }

        /// <summary>
        /// Gets the recent order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Order Object</returns>
        public static Order GetRecentOrder(string customerId)
        {
            Order objOrder = new Order();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            DataSet dataSet = SqlHelper.GetDataSet("dbo.usp_GetRecentOrder", objParameters.ToArray());

            if (dataSet != null && dataSet.Tables.Count == 3)
            {
                //// Order Table Info
                DataTable ObjOrderInfo = dataSet.Tables[0];

                if (ObjOrderInfo != null && ObjOrderInfo.Rows.Count > 0)
                {
                    objOrder.OrderId = ObjOrderInfo.Rows[0]["ORDER_ID"].ToString();

                    objOrder.CustomerId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["CUSTOMER_ID"]);
                    objOrder.CustomerName = ObjOrderInfo.Rows[0]["CUSTOMER_NAME"].ToString();

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]);
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                }

                //// Get the source Address
                objOrder.SourceAddress = GetAddress(dataSet.Tables[1]);

                //// Get the Destination Address
                objOrder.DestinationAddress = GetAddress(dataSet.Tables[2]);
            }

            return objOrder;
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>list of services</returns>
        public static List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetServices", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    Service service = new Service();
                    service.Id = BinaryConverter.ConvertByteToString((byte[])row["SERVICE_ID"]);
                    service.Name = row["NAME"].ToString();
                    if (!(row["PARENT_SERVICE_ID"] is System.DBNull))
                    {
                        service.ParentServiceId = BinaryConverter.ConvertByteToString((byte[])row["PARENT_SERVICE_ID"]);
                    }

                    service.ImageURL = row["IMAGE_URL"].ToString();
                    services.Add(service);
                }
            }

            return services;
        }

        /// <summary>
        /// Gets the service vendors.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public static List<ServiceVendor> GetServiceVendors(string serviceId)
        {
            List<ServiceVendor> serviceVendors = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetServiceVendors", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                serviceVendors = new List<ServiceVendor>();
                foreach (DataRow row in datatable.Rows)
                {
                    ServiceVendor serviceVendor = new ServiceVendor();
                    serviceVendor.ServiceId = BinaryConverter.ConvertByteToString((byte[])row["SERVICE_ID"]);
                    serviceVendor.ServiceName = row["SERVICE_NAME"].ToString();
                    serviceVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_ID"]);
                    serviceVendor.VendorName = row["VENDOR_NAME"].ToString();
                    serviceVendor.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_SERVICE_ID"]);
                    serviceVendors.Add(serviceVendor);
                }
            }

            return serviceVendors;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="addressTable">The address table.</param>
        /// <returns>Address Info</returns>
        private static AddressInfo GetAddress(DataTable addressTable)
        {
            AddressInfo addressInfo = null;
            if (addressTable != null && addressTable.Rows.Count > 0)
            {
                addressInfo = new AddressInfo();
                addressInfo.AddressId = BinaryConverter.ConvertByteToString((byte[])addressTable.Rows[0]["Address_ID"]);
                addressInfo.Country = addressTable.Rows[0]["COUNTRY"].ToString();
                addressInfo.State = addressTable.Rows[0]["STATE"].ToString();
                addressInfo.City = addressTable.Rows[0]["CITY"].ToString();
                addressInfo.Locality = addressTable.Rows[0]["LOCALITY"].ToString();
                addressInfo.Address = addressTable.Rows[0]["ADDRESS"].ToString();
                addressInfo.Pincode = addressTable.Rows[0]["PINCODE"].ToString();
                addressInfo.Lattitude = addressTable.Rows[0]["LATITIUDE"].ToString();
                addressInfo.Longitude = addressTable.Rows[0]["LONGITUDE"].ToString();
            }

            return addressInfo;
        }
    }
}
