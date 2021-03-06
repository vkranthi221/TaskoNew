using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            Order objOrder = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            DataSet dataSet = SqlHelper.GetDataSet("dbo.usp_GetOrderDetails", objParameters.ToArray());

            if (dataSet != null && dataSet.Tables.Count == 4)
            {
                //// Order Table Info
                DataTable ObjOrderInfo = dataSet.Tables[0];

                if (ObjOrderInfo != null && ObjOrderInfo.Rows.Count > 0)
                {
                    objOrder = new Order();
                    objOrder.OrderId = ObjOrderInfo.Rows[0]["ORDER_ID"].ToString();

                    objOrder.CustomerId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["CUSTOMER_ID"]);
                    objOrder.CustomerName = ObjOrderInfo.Rows[0]["CUSTOMER_NAME"].ToString();
                    objOrder.CustomerMobileNumber = Convert.ToString(ObjOrderInfo.Rows[0]["CUSTOMER_MOBILE_NUMBER"]);

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();
                    objOrder.VendorMobileNumber = Convert.ToString(ObjOrderInfo.Rows[0]["VENDOR_MOBILE_NUMBER"]);
                    objOrder.Photo = ObjOrderInfo.Rows[0]["PHOTO"].ToString();

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();
                    objOrder.ServiceImageURL = Convert.ToString(ObjOrderInfo.Rows[0]["IMAGE_URL"]);

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                    objOrder.Comments = ObjOrderInfo.Rows[0]["COMMENTS"].ToString();

                    objOrder.CustomerETA = ObjOrderInfo.Rows[0]["CUSTOMER_ETA"].ToString();
                    objOrder.CustomerDistance = ObjOrderInfo.Rows[0]["CUSTOMER_DISTANCE"].ToString();
                    if (ObjOrderInfo.Rows[0]["VISITING_FEE"] != DBNull.Value)
                    {
                        objOrder.VisitingFee = Convert.ToDouble(ObjOrderInfo.Rows[0]["VISITING_FEE"]);
                    }

                    objOrder.BToBCustomerName = ObjOrderInfo.Rows[0]["B_TO_B_CUSTOMER_NAME"].ToString();
                    objOrder.IsOffline = Convert.ToBoolean(ObjOrderInfo.Rows[0]["IS_OFFLINE"]);
                }


                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                {
                    //// Get the source Address
                    ////objOrder.SourceAddress = PopulateAddress(dataSet.Tables[1].Rows[0]);
                    objOrder.AmountPaid = Convert.ToDouble(dataSet.Tables[1].Rows[0]["ORDER_PRICE"]);

                    objOrder.ServiceQuality = Convert.ToDouble(dataSet.Tables[1].Rows[0]["SERVICE_QUALITY"]);
                    objOrder.Punctuality = Convert.ToDouble(dataSet.Tables[1].Rows[0]["PUNCTUALITY"]);
                    objOrder.Courtesy = Convert.ToDouble(dataSet.Tables[1].Rows[0]["COURTESY"]);
                    objOrder.Price = Convert.ToDouble(dataSet.Tables[1].Rows[0]["PRICE"]);
                }

                //// Get the Destination Address
                if (dataSet.Tables[2] != null && dataSet.Tables[2].Rows.Count > 0)
                {
                    objOrder.DestinationAddress = PopulateAddress(dataSet.Tables[2].Rows[0]);
                }

                if (dataSet.Tables[3] != null && dataSet.Tables[3].Rows.Count > 0 && dataSet.Tables[3].Rows[0]["OVERALL_RATING"] != DBNull.Value)
                {
                    objOrder.OverAllRating = Convert.ToDouble(dataSet.Tables[3].Rows[0]["OVERALL_RATING"]);
                    objOrder.IsOrderRated = true;
                }
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
            Order objOrder = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            DataSet dataSet = SqlHelper.GetDataSet("dbo.usp_GetRecentOrder", objParameters.ToArray());

            if (dataSet != null && dataSet.Tables.Count == 3)
            {
                //// Order Table Info
                DataTable ObjOrderInfo = dataSet.Tables[0];

                if (ObjOrderInfo != null && ObjOrderInfo.Rows.Count > 0)
                {
                    objOrder = new Order();
                    objOrder.OrderId = ObjOrderInfo.Rows[0]["ORDER_ID"].ToString();

                    objOrder.CustomerId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["CUSTOMER_ID"]);
                    objOrder.CustomerName = ObjOrderInfo.Rows[0]["CUSTOMER_NAME"].ToString();
                    objOrder.CustomerMobileNumber = Convert.ToString(ObjOrderInfo.Rows[0]["CUSTOMER_MOBILE_NUMBER"]);

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();
                    objOrder.VendorMobileNumber = Convert.ToString(ObjOrderInfo.Rows[0]["VENDOR_MOBILE_NUMBER"]);

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();
                    objOrder.ServiceImageURL = Convert.ToString(ObjOrderInfo.Rows[0]["IMAGE_URL"]);

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                    objOrder.Comments = ObjOrderInfo.Rows[0]["COMMENTS"].ToString();
                    objOrder.IsOrderRated = Convert.ToBoolean(ObjOrderInfo.Rows[0]["IS_ORDER_RATED"]);
                }

                //// Get the source Address
                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                {
                    objOrder.SourceAddress = PopulateAddress(dataSet.Tables[1].Rows[0]);
                }

                //// Get the Destination Address
                if (dataSet.Tables[2] != null && dataSet.Tables[2].Rows.Count > 0)
                {
                    objOrder.DestinationAddress = PopulateAddress(dataSet.Tables[2].Rows[0]);
                }
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

            return services.OrderBy(i => i.Name).ToList();
        }

        /// <summary>
        /// Gets the service vendors.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        public static List<ServiceVendor> GetServiceVendors(string serviceId, string customerId)
        {
            List<ServiceVendor> serviceVendors = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
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
                    serviceVendor.BaseRate = Convert.ToDouble(row["BASE_RATE"]);
                    serviceVendor.Latitude = Convert.ToDecimal(row["LATITIUDE"]);
                    serviceVendor.Longitude = Convert.ToDecimal(row["LONGITUDE"]);
                    if (!(row["HOME_LATITIUDE"] is System.DBNull))
                    {
                        serviceVendor.HomeLatitude = Convert.ToDecimal(row["HOME_LATITIUDE"]);
                    }

                    if (!(row["HOME_LONGITUDE"] is System.DBNull))
                    {
                        serviceVendor.HomeLongitude = Convert.ToDecimal(row["HOME_LONGITUDE"]);
                    }

                    if (row["FAVORITE_ID"] != null && !row["FAVORITE_ID"].Equals(DBNull.Value))
                    {
                        serviceVendor.IsFavoriteVendor = true;
                    }

                    if (row["OVERALL_RATINGS"] != null && !row["OVERALL_RATINGS"].Equals(DBNull.Value))
                    {
                        serviceVendor.OverAllRating = Convert.ToDecimal(row["OVERALL_RATINGS"]);
                    }

                    serviceVendor.TotalReviews = Convert.ToInt32(row["TOTAL_REVIEWS"]);

                    serviceVendor.FacebookUrl = Convert.ToString(row["FACEBOOK_URL"]);
                    serviceVendor.Photo = Convert.ToString(row["PHOTO"]);
                    serviceVendor.MobileNumber = Convert.ToString(row["MOBILE_NUMBER"]);
                    serviceVendor.IsEntireCityAccessible = Convert.ToBoolean(row["IS_VISIBLE_TO_ENTIRE_CITY"]);
                    serviceVendor.VendorCity = Convert.ToString(row["CITY"]);
                    serviceVendors.Add(serviceVendor);
                }
            }

            return serviceVendors;
        }

        /// <summary>
        /// Confirms the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>order id</returns>
        public static string ConfirmOrder(Order order, bool? isOffline)
        {
            string orderId = string.Empty;
            string sourceAddressId = string.Empty;
            if (!string.IsNullOrEmpty(order.VendorId))
            {
                order.SourceAddress = AdminData.GetVendorAddress(order.VendorId);
                sourceAddressId = order.SourceAddress.AddressId;
            }
            else
            {
                //// add the source address and get the Source addressId
                sourceAddressId = AddAddress(order.SourceAddress);
            }

            //// add the destination address and get the destination addressId
            string destinationAddressId = AddAddress(order.DestinationAddress);

            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(order.VendorServiceId, TaskoEnum.IdType.VendorServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(order.VendorServiceId)));

            BinaryConverter.IsValidGuid(order.CustomerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(order.CustomerId)));
            if (isOffline.HasValue && isOffline.Value)
            {
                objParameters.Add(SqlHelper.CreateParameter("@pIsOffline", DbType.Boolean, true));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pIsOffline", DbType.Boolean, false));
            }

            objParameters.Add(SqlHelper.CreateParameter("@pSourceAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(sourceAddressId)));
            objParameters.Add(SqlHelper.CreateParameter("@pDestinationAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(destinationAddressId)));
            if (string.IsNullOrEmpty(order.BToBCustomerName))
            {
                order.BToBCustomerName = string.Empty;
            }

            objParameters.Add(SqlHelper.CreateParameter("@pBToBCustomerName", DbType.String, order.BToBCustomerName));

            orderId = (string)SqlHelper.ExecuteScalar("dbo.usp_ConfirmOrder", objParameters.ToArray());

            return orderId;
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public static void UpdateCustomer(Customer customer)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customer.Id, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customer.Id)));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, customer.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailAddress", DbType.String, customer.EmailAddress));
            objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, customer.MobileNumber));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateCustomer", objParameters.ToArray());
        }

        /// <summary>
        /// Gets the customer orders.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderStatus">The order status Ids.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <returns>
        /// List of Customer Orders
        /// </returns>
        public static List<OrderSummary> GetCustomerOrders(string customerId, string orderStatus, int pageNumber, int recordsPerPage)
        {
            List<OrderSummary> customerOrders = null;
            if (orderStatus != null)
            {
                string[] listOfOrderstatusIds = orderStatus.Split(',');

                foreach (string statusId in listOfOrderstatusIds)
                {
                    List<SqlParameter> objParameters = new List<SqlParameter>();
                    BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
                    objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
                    objParameters.Add(SqlHelper.CreateParameter("@pOrderstatusId", DbType.Int16, statusId));
                    objParameters.Add(SqlHelper.CreateParameter("@pPageNo", DbType.Int16, pageNumber));
                    objParameters.Add(SqlHelper.CreateParameter("@pRecordsPerPage", DbType.Int16, recordsPerPage));
                    DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetCustomerOrders", objParameters.ToArray());
                    if (datatable != null && datatable.Rows.Count > 0)
                    {
                        customerOrders = new List<OrderSummary>();
                        foreach (DataRow row in datatable.Rows)
                        {
                            OrderSummary orderSummary = new OrderSummary();
                            orderSummary.OrderId = row["ORDER_ID"].ToString();
                            orderSummary.OrderStatus = row["ORDERSTATUS_NAME"].ToString();
                            orderSummary.ServiceId = BinaryConverter.ConvertByteToString((byte[])row["SERVICE_ID"]);
                            orderSummary.ServiceName = row["SERVICE_NAME"].ToString();
                            orderSummary.RequestedDate = Convert.ToDateTime(row["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                            orderSummary.Comments = row["COMMENTS"].ToString();
                            customerOrders.Add(orderSummary);
                        }
                    }
                }
            }

            return customerOrders;
        }

        /// <summary>
        /// Adds the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressInfo">The address information.</param>
        public static void AddCustomerAddress(string customerId, AddressInfo addressInfo)
        {
            string addressId = AddAddress(addressInfo);

            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(addressId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_AddCustomerAddress", objParameters.ToArray());
        }

        /// <summary>
        /// Updates the customer address.
        /// </summary>       
        /// <param name="addressInfo">The address information.</param>
        public static void UpdateCustomerAddress(AddressInfo addressInfo)
        {
            UpdateAddress(addressInfo);
        }

        /// <summary>
        /// Updates the address.
        /// </summary>       
        /// <param name="addressInfo">The address information.</param>
        public static void UpdateAddress(AddressInfo addressInfo)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(addressInfo.AddressId, TaskoEnum.IdType.AddressId);
            objParameters.Add(SqlHelper.CreateParameter("@pAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(addressInfo.AddressId)));
            objParameters.Add(SqlHelper.CreateParameter("@pCountry", DbType.String, addressInfo.Country));
            objParameters.Add(SqlHelper.CreateParameter("@pState", DbType.String, addressInfo.State));
            objParameters.Add(SqlHelper.CreateParameter("@pLatitude", DbType.String, addressInfo.Lattitude));
            objParameters.Add(SqlHelper.CreateParameter("@pLongitude", DbType.String, addressInfo.Longitude));
            objParameters.Add(SqlHelper.CreateParameter("@pLocality", DbType.String, addressInfo.Locality));
            objParameters.Add(SqlHelper.CreateParameter("@pCity", DbType.String, addressInfo.City));
            objParameters.Add(SqlHelper.CreateParameter("@pAddress", DbType.String, addressInfo.Address));
            objParameters.Add(SqlHelper.CreateParameter("@Pincode", DbType.String, addressInfo.Pincode));
            addressInfo.AddressType = string.IsNullOrEmpty(addressInfo.AddressType) ? string.Empty : addressInfo.AddressType;
            objParameters.Add(SqlHelper.CreateParameter("@pAddressType", DbType.String, addressInfo.AddressType));

            if (string.IsNullOrWhiteSpace(addressInfo.HomeLattitude))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLatitude", DbType.String, DBNull.Value));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLatitude", DbType.String, addressInfo.HomeLattitude));
            }

            if (string.IsNullOrWhiteSpace(addressInfo.HomeLongitude))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLongitude", DbType.String, DBNull.Value));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLongitude", DbType.String, addressInfo.HomeLongitude));
            }

            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateCustomerAddress", objParameters.ToArray());
        }

        /// <summary>
        /// Deletes the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        public static void DeleteCustomerAddress(string customerId, string addressId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            BinaryConverter.IsValidGuid(addressId, TaskoEnum.IdType.AddressId);
            objParameters.Add(SqlHelper.CreateParameter("@pAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(addressId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteCustomerAddress", objParameters.ToArray());
        }

        /// <summary>
        /// Gets the customer addresses.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>list of Addresses for the customer</returns>
        public static List<AddressInfo> GetCustomerAddresses(string customerId)
        {
            List<AddressInfo> customerAddresses = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetCustomerAddresses", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                customerAddresses = new List<AddressInfo>();
                foreach (DataRow row in datatable.Rows)
                {
                    AddressInfo addressInfo = PopulateAddress(row);
                    customerAddresses.Add(addressInfo);
                }
            }

            return customerAddresses;
        }

        /// <summary>
        /// Adds the vendor rating.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="vendorRating">The vendor rating.</param>
        public static void AddVendorRating(string orderId, VendorRating vendorRating)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));

            BinaryConverter.IsValidGuid(vendorRating.CustomerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorRating.CustomerId)));

            BinaryConverter.IsValidGuid(vendorRating.VendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorRating.VendorId)));

            objParameters.Add(SqlHelper.CreateParameter("@pServiceQuality", DbType.Decimal, vendorRating.ServiceQuality));
            objParameters.Add(SqlHelper.CreateParameter("@pPunctuality", DbType.Decimal, vendorRating.Punctuality));
            objParameters.Add(SqlHelper.CreateParameter("@pCourtesy", DbType.Decimal, vendorRating.Courtesy));
            objParameters.Add(SqlHelper.CreateParameter("@pPrice", DbType.Decimal, vendorRating.Price));
            objParameters.Add(SqlHelper.CreateParameter("@pComments", DbType.String, vendorRating.Comments));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderPrice", DbType.Decimal, vendorRating.OrderPrice));

            SqlHelper.ExecuteNonQuery("dbo.usp_AddVendorRating", objParameters.ToArray());
        }

        /// <summary>
        /// Updates the vendor rating.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="vendorRating">The vendor rating.</param>
        public static void UpdateVendorRating(string orderId, VendorRating vendorRating)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));

            BinaryConverter.IsValidGuid(vendorRating.CustomerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorRatingId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorRating.Id)));
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorRating.CustomerId)));

            BinaryConverter.IsValidGuid(vendorRating.VendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorRating.VendorId)));

            objParameters.Add(SqlHelper.CreateParameter("@pServiceQuality", DbType.Decimal, vendorRating.ServiceQuality));
            objParameters.Add(SqlHelper.CreateParameter("@pPunctuality", DbType.Decimal, vendorRating.Punctuality));
            objParameters.Add(SqlHelper.CreateParameter("@pCourtesy", DbType.Decimal, vendorRating.Courtesy));
            objParameters.Add(SqlHelper.CreateParameter("@pPrice", DbType.Decimal, vendorRating.Price));
            objParameters.Add(SqlHelper.CreateParameter("@pComments", DbType.String, vendorRating.Comments));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderPrice", DbType.Decimal, vendorRating.OrderPrice));

            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendorRating", objParameters.ToArray());
        }

        /// <summary>
        /// Sets the vendor as favorite vendor for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Is vendor already set or not</returns>
        public static bool SetFavoriteVendor(string customerId, string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            bool isFavouriteVendorAlreadySet = false;

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            isFavouriteVendorAlreadySet = (bool)SqlHelper.ExecuteScalar("dbo.usp_SetFavoriteVendor", objParameters.ToArray());

            return isFavouriteVendorAlreadySet;
        }

        /// <summary>
        /// Gets the favorite vendors for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// /// <returns>list of favorite vendors for the customer</returns>
        public static List<FavoriteVendor> GetFavoriteVendors(string customerId)
        {
            List<FavoriteVendor> favoriteVendors = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetFavoriteVendors", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                favoriteVendors = new List<FavoriteVendor>();
                foreach (DataRow row in datatable.Rows)
                {
                    FavoriteVendor favoriteVendor = new FavoriteVendor();
                    if (!(row["VENDOR_ID"] is System.DBNull))
                    {
                        favoriteVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_ID"]);
                    }
                    if (!(row["VENDOR_NAME"] is System.DBNull))
                    {
                        favoriteVendor.VendorName = row["VENDOR_NAME"].ToString();
                    }
                    if (!(row["VENDOR_PHONE"] is System.DBNull))
                    {
                        favoriteVendor.VendorPhoneNumber = row["VENDOR_PHONE"].ToString();
                    }

                    if (!(row["TOTAL_RATINGS"] is System.DBNull))
                    {
                        favoriteVendor.TotalRatings = Convert.ToInt32(row["TOTAL_RATINGS"]);
                    }

                    if (!(row["OVERALL_RATINGS"] is System.DBNull))
                    {
                        favoriteVendor.OverallRating = Convert.ToInt32(row["OVERALL_RATINGS"]);
                    }

                    if (!string.IsNullOrEmpty(favoriteVendor.VendorId))
                    {
                        favoriteVendors.Add(favoriteVendor);
                    }
                }
            }

            return favoriteVendors;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns>
        /// Address Info
        /// </returns>
        public static AddressInfo PopulateAddress(DataRow dataRow)
        {
            AddressInfo addressInfo = new AddressInfo();
            addressInfo.AddressId = BinaryConverter.ConvertByteToString((byte[])dataRow["Address_ID"]);
            addressInfo.AddressType = dataRow["ADDRESS_TYPE"].ToString();
            addressInfo.Country = dataRow["COUNTRY"].ToString();
            addressInfo.State = dataRow["STATE"].ToString();
            addressInfo.City = dataRow["CITY"].ToString();
            addressInfo.Locality = dataRow["LOCALITY"].ToString();
            addressInfo.Address = dataRow["ADDRESS"].ToString();
            addressInfo.Pincode = dataRow["PINCODE"].ToString();
            addressInfo.Lattitude = dataRow["LATITIUDE"].ToString();
            addressInfo.Longitude = dataRow["LONGITUDE"].ToString();

            return addressInfo;
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="addressInfo">The address.</param>
        /// <returns>Address Id</returns>
        public static string AddAddress(AddressInfo addressInfo)
        {
            string AddressId = string.Empty;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pCountry", DbType.String, addressInfo.Country));
            objParameters.Add(SqlHelper.CreateParameter("@pState", DbType.String, addressInfo.State));
            objParameters.Add(SqlHelper.CreateParameter("@pLatitude", DbType.String, addressInfo.Lattitude));
            objParameters.Add(SqlHelper.CreateParameter("@pLongitude", DbType.String, addressInfo.Longitude));
            objParameters.Add(SqlHelper.CreateParameter("@pLocality", DbType.String, addressInfo.Locality));
            objParameters.Add(SqlHelper.CreateParameter("@pCity", DbType.String, addressInfo.City));
            objParameters.Add(SqlHelper.CreateParameter("@pAddress", DbType.String, addressInfo.Address));
            objParameters.Add(SqlHelper.CreateParameter("@Pincode", DbType.String, addressInfo.Pincode));

            if (string.IsNullOrWhiteSpace(addressInfo.HomeLattitude))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLatitude", DbType.String, DBNull.Value));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLatitude", DbType.String, addressInfo.HomeLattitude));
            }

            if (string.IsNullOrWhiteSpace(addressInfo.HomeLongitude))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLongitude", DbType.String, DBNull.Value));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pHomeLongitude", DbType.String, addressInfo.HomeLongitude));
            }

            addressInfo.AddressType = string.IsNullOrEmpty(addressInfo.AddressType) ? string.Empty : addressInfo.AddressType;
            objParameters.Add(SqlHelper.CreateParameter("@pAddressType", DbType.String, addressInfo.AddressType));
            byte[] Address_Id = (byte[])SqlHelper.ExecuteScalar("dbo.usp_AddAddress", objParameters.ToArray());

            AddressId = BinaryConverter.ConvertByteToString(Address_Id);
            return AddressId;
        }

        /// <summary>
        /// inserts otp details to DB
        /// </summary>
        /// <param name="otp">OTP</param>
        /// <param name="phoneNumber">Phone Number</param>
        /// <param name="emailId">email id</param>
        public static void InsertOTPDetails(string otp, string phoneNumber, string emailId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pOtp", DbType.String, otp));
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, phoneNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailId", DbType.String, emailId));

            SqlHelper.ExecuteNonQuery("dbo.usp_InsertOTPDetails", objParameters.ToArray());

        }

        /// <summary>
        /// return whether the customer phone number exists or not
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        /// <returns>true or false</returns>
        public static bool isCustomerPhoneNumberExits(string phoneNumber)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, phoneNumber));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_IsCustomerExists", objParameters.ToArray());
            bool isCustomerExists = false;
            if (reader.Read())
            {
                isCustomerExists = (bool)reader["IsCustomerExists"];
            }

            reader.Close();
            return isCustomerExists;
        }

        /// <summary>
        /// Validates the otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <returns>Is OTP Valid</returns>
        public static bool ValidateOTP(string phoneNumber, string OTP)
        {

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, phoneNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pOTP", DbType.String, OTP));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_ValidateOTP", objParameters.ToArray());

            bool isvalid = false;
            if (reader.Read())
            {
                isvalid = (bool)reader["IsValid"];
            }

            reader.Close();
            return isvalid;
        }

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Login Info</returns>
        public static LoginInfo AddCustomer(string name, string emailId, string phoneNumber)
        {
            LoginInfo logininfo = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, name));
            objParameters.Add(SqlHelper.CreateParameter("@pEmailId", DbType.String, emailId));
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, phoneNumber));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_AddCustomer", objParameters.ToArray());

            if (reader.Read())
            {
                logininfo = new LoginInfo();
                if (!(reader["Auth_Code"] is System.DBNull))
                {
                    logininfo.TokenId = BinaryConverter.ConvertByteToString((byte[])reader["AUTH_CODE"]);
                }

                if (!(reader["USERID"] is System.DBNull))
                {
                    logininfo.UserId = BinaryConverter.ConvertByteToString((byte[])reader["USERID"]);
                }
            }

            reader.Close();
            return logininfo;
        }

        /// <summary>
        /// Logins the validate otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <param name="IsValid">if set to <c>true</c> [is valid].</param>
        /// <returns>Login Info</returns>
        public static LoginInfo LoginValidateOTP(string phoneNumber, string OTP, ref bool IsValid)
        {
            LoginInfo logininfo = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPhoneNumber", DbType.String, phoneNumber));
            objParameters.Add(SqlHelper.CreateParameter("@pOTP", DbType.String, OTP));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_CustomerLoginValidateOTP", objParameters.ToArray());

            if (reader.Read())
            {
                IsValid = (bool)reader["IsValid"];
                if (IsValid)
                {
                    logininfo = new LoginInfo();
                    logininfo.TokenId = BinaryConverter.ConvertByteToString((byte[])reader["AUTH_CODE"]);
                    logininfo.UserId = BinaryConverter.ConvertByteToString((byte[])reader["USERID"]);
                }
            }

            reader.Close();
            return logininfo;
        }

        /// <summary>
        /// Gets the Customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Customer details</returns>
        public static Customer GetCustomer(string customerId)
        {
            Customer objCustomer = new Customer();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetCustomerDetails", objParameters.ToArray());
            if (reader.Read())
            {
                objCustomer.Id = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                objCustomer.Name = reader["NAME"].ToString();
                objCustomer.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objCustomer.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objCustomer.RegisteredDate = Convert.ToDateTime(reader["REGISTERED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
            }

            reader.Close();

            return objCustomer;
        }

        /// <summary>
        /// Deletes the favorite vendor.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        public static void DeleteFavoriteVendor(string customerId, string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteFavoriteVendor", objParameters.ToArray());
        }

        #region Complaint

        public static string AddComplaint(Complaint complaint)
        {
            string complaintId = string.Empty;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pComplaintStatus", DbType.Int32, complaint.ComplaintStatus));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, complaint.OrderId));
            objParameters.Add(SqlHelper.CreateParameter("@pTitle", DbType.String, complaint.Title));
            complaintId = (string)SqlHelper.ExecuteScalar("dbo.usp_AddComplaint", objParameters.ToArray());
            if (!string.IsNullOrEmpty(complaintId))
            {
                AddComplaintChat(complaint.ComplaintChats, complaintId);
            }

            return complaintId;
        }

        public static void AddComplaintChat(List<ComplaintChat> chats, string complaintId)
        {
            foreach (ComplaintChat chat in chats)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();
                objParameters.Add(SqlHelper.CreateParameter("@pComplaintId", DbType.String, complaintId));
                objParameters.Add(SqlHelper.CreateParameter("@pChatContent", DbType.String, chat.ChatContent));
                SqlHelper.ExecuteNonQuery("dbo.usp_AddComplaintChat", objParameters.ToArray());
            }
        }

        public static List<Complaint> GetCustomerComplaints(string customerId)
        {
            List<Complaint> complaints = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetCustomerComplaints", objParameters.ToArray());
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

        public static string GetCustomerPhone(string customerId)
        {
            string phone = string.Empty;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetCustomerPhone", objParameters.ToArray());
            if (reader.Read())
            {
                phone = reader["MOBILE_NUMBER"].ToString();
            }

            reader.Close();

            return phone;
        }

        public static void SaveOfflineVendorRequest(string customerId, string serviceId, string area)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            BinaryConverter.IsValidGuid(serviceId, TaskoEnum.IdType.ServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            objParameters.Add(SqlHelper.CreateParameter("@pArea", DbType.String, area));
            SqlHelper.ExecuteNonQuery("dbo.usp_SaveOfflineVendor", objParameters.ToArray());
        }

        public static void UpdateCustomerOrderDetails(string customerETA, string customerDistance, string orderId, string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerDistance", DbType.String, customerDistance));
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerETA", DbType.String, customerETA));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateCustomerOrder", objParameters.ToArray());
        }

        #region Social Media
        public static void UpdateCustomerLikeForPost(string postId, string customerId, bool isLiked)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(postId)));
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pIsLiked", DbType.Boolean, isLiked));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateCustomerLikeForPost", objParameters.ToArray());
        }

        public static void ReportPost(string postId, string customerId, string reason, string comment)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pPostId", DbType.Binary, BinaryConverter.ConvertStringToByte(postId)));
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pReason", DbType.String, reason));
            objParameters.Add(SqlHelper.CreateParameter("@pComment", DbType.String, comment));
            SqlHelper.ExecuteNonQuery("dbo.usp_ReportPost", objParameters.ToArray());
        }
        #endregion

        //public static void Test()
        //{
        //    string serviceId = "9908FBC6FD4C9F459F2D1631F40E4938";
        //    string customerId = "002722397B7BC942B02C141CDF780E46";
        //    bool isOnline = false;
        //    decimal distanceCovered = 10;
        //    string latitude = "17.4834";
        //    string longitude = "78.3871";
        //    List<ServiceVendor> services = null;
        //    services = CustomerData.GetServiceVendors(serviceId, customerId);
        //    bool nearVendorFound = false;
        //    if (services != null)
        //    {
        //        foreach (ServiceVendor serviceVendor in services)
        //        {
        //            decimal vendorLatitude = 0;
        //            decimal vendorLongitude = 0;
        //            if (isOnline)
        //            {
        //                vendorLatitude = serviceVendor.Latitude;
        //                vendorLongitude = serviceVendor.Longitude;
        //            }
        //            else
        //            {
        //                vendorLatitude = serviceVendor.HomeLatitude;
        //                vendorLongitude = serviceVendor.HomeLongitude;
        //            }

        //            // This means that vendor is logged out. So we are updating his distance to negative value.
        //            if (vendorLatitude != 0 && vendorLongitude != 0)
        //            {
        //                if (serviceVendor.IsEntireCityAccessible)
        //                {
        //                    XmlDocument xDoc = new XmlDocument();
        //                    xDoc.Load("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");

        //                    XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
        //                    XmlNode xNode = xNodelst.Item(0);
        //                    //string adress = xNode.SelectSingleNode("formatted_address").InnerText;
        //                    //string area = xNode.SelectSingleNode("address_component[3]/long_name").InnerText;
        //                    string customerCity = xNode.SelectSingleNode("address_component[4]/long_name").InnerText;
        //                    if (string.IsNullOrEmpty(customerCity) || string.IsNullOrEmpty(serviceVendor.VendorCity) || customerCity.ToLower() != serviceVendor.VendorCity.ToLower())
        //                    {
        //                        // setting this to false so that this vendor will not be returned. we are not saving in the db. this is just a temp change to restrict him from returning
        //                        serviceVendor.IsEntireCityAccessible = false;
        //                    }
        //                    else
        //                    {
        //                        nearVendorFound = true;
        //                    }
        //                    //string district = xNode.SelectSingleNode("address_component[5]/long_name").InnerText;
        //                }
        //                else
        //                {
        //                    string requestUri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + latitude + "," + longitude + "&destinations=" + vendorLatitude + "," + vendorLongitude;

        //                    WebRequest request = HttpWebRequest.Create(requestUri);
        //                    WebResponse response = request.GetResponse();
        //                    StreamReader reader = new StreamReader(response.GetResponseStream());
        //                    string responseStringData = reader.ReadToEnd();
        //                    if (!string.IsNullOrEmpty(responseStringData))
        //                    {
        //                        XmlDocument xmlDoc = new XmlDocument();
        //                        xmlDoc.LoadXml(responseStringData);
        //                        string xpath = "DistanceMatrixResponse/row/element/distance/text";
        //                        XmlNode distance = xmlDoc.SelectSingleNode(xpath);
        //                        if (distance != null && !string.IsNullOrEmpty(distance.InnerText))
        //                        {
        //                            string actualDistance = distance.InnerText.Remove(distance.InnerText.IndexOf(" "));
        //                            if (!string.IsNullOrEmpty(actualDistance))
        //                            {
        //                                nearVendorFound = true;
        //                                serviceVendor.Distance = Convert.ToDecimal(actualDistance);
        //                            }
        //                        }

        //                        string durationXpath = "DistanceMatrixResponse/row/element/duration/text";
        //                        XmlNode duration = xmlDoc.SelectSingleNode(durationXpath);
        //                        if (duration != null && !string.IsNullOrEmpty(duration.InnerText))
        //                        {
        //                            serviceVendor.ETA = duration.InnerText;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                serviceVendor.Distance = -1;
        //                serviceVendor.IsEntireCityAccessible = false;
        //            }
        //        }
        //    }

        //    if (nearVendorFound)
        //    {
        //        List<ServiceVendor> vendors = new List<ServiceVendor>();
        //        if (services.Any(i => i.VendorId == "2C086E5F59A0C44AAC70475E6613FF4E"))
        //        {
        //            vendors.Add(services.FirstOrDefault(i => i.VendorId == "2C086E5F59A0C44AAC70475E6613FF4E"));
        //        }

        //        vendors.AddRange(services.Where(i => i.VendorId != "2C086E5F59A0C44AAC70475E6613FF4E"));
        //       List<ServiceVendor> vendorss =  vendors.Where(i => (i.Distance <= distanceCovered && i.Distance != -1) || i.IsEntireCityAccessible).ToList();
        //        if(vendorss != null)
        //        {

        //        }
        //    }
        //}
    }
}
