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
            Order objOrder = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            DataSet dataSet = SqlHelper.GetDataSet("dbo.usp_GetOrderDetails", objParameters.ToArray());

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

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                    objOrder.Comments = ObjOrderInfo.Rows[0]["COMMENTS"].ToString();
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

                    objOrder.VendorServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_SERVICE_ID"]);
                    objOrder.VendorId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["VENDOR_ID"]);
                    objOrder.VendorName = ObjOrderInfo.Rows[0]["VENDOR_NAME"].ToString();

                    objOrder.ServiceId = BinaryConverter.ConvertByteToString((byte[])ObjOrderInfo.Rows[0]["SERVICE_ID"]);
                    objOrder.ServiceName = ObjOrderInfo.Rows[0]["SERVICE_NAME"].ToString();

                    objOrder.OrderStatusId = Convert.ToInt16(ObjOrderInfo.Rows[0]["ORDER_STATUS_ID"]);
                    objOrder.OrderStatus = ObjOrderInfo.Rows[0]["ORDERSTATUS_NAME"].ToString();

                    objOrder.RequestedDate = Convert.ToDateTime(ObjOrderInfo.Rows[0]["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    objOrder.Location = ObjOrderInfo.Rows[0]["ORDER_LOCATION"].ToString();
                    objOrder.Comments = ObjOrderInfo.Rows[0]["COMMENTS"].ToString();
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

            return services;
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
                    if (row["FAVORITE_ID"] != null)
                    {
                        serviceVendor.IsFavoriteVendor = true;
                    }

                    serviceVendor.OverAllRating = Convert.ToDecimal(row["OVERALL_RATINGS"]);
                    serviceVendor.TotalReviews = Convert.ToInt32(row["TOTAL_REVIEWS"]);
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
        public static string ConfirmOrder(Order order)
        {
            string orderId = string.Empty;

            //// add the source address and get the Source addressId
            string sourceAddressId = AddAddress(order.SourceAddress);

            //// add the destination address and get the destination addressId
            string destinationAddressId = AddAddress(order.DestinationAddress);

            List<SqlParameter> objParameters = new List<SqlParameter>();
            
            BinaryConverter.IsValidGuid(order.VendorServiceId, TaskoEnum.IdType.VendorServiceId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(order.VendorServiceId)));
            
            BinaryConverter.IsValidGuid(order.CustomerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(order.CustomerId)));
            
            objParameters.Add(SqlHelper.CreateParameter("@pSourceAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(sourceAddressId)));
            objParameters.Add(SqlHelper.CreateParameter("@pDestinationAddressId", DbType.Binary, BinaryConverter.ConvertStringToByte(destinationAddressId)));
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
        /// <param name="orderStatus">The order status.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <returns>
        /// List of Customer Orders
        /// </returns>
        public static List<OrderSummary> GetCustomerOrders(string customerId, int orderStatus, int pageNumber, int recordsPerPage)
        {
            List<OrderSummary> customerOrders = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(customerId, TaskoEnum.IdType.CustomerId);
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderstatusId", DbType.Int16, orderStatus));
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

            SqlHelper.ExecuteNonQuery("dbo.usp_AddVendorRating", objParameters.ToArray());
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
                    favoriteVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])row["VENDOR_ID"]);
                    favoriteVendor.VendorName = row["VENDOR_NAME"].ToString();
                    favoriteVendor.TotalRatings = Convert.ToInt32(row["TOTAL_RATINGS"]);
                    favoriteVendor.OverallRating = Convert.ToInt32(row["OVERALL_RATINGS"]);
                    favoriteVendors.Add(favoriteVendor);
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

            if (reader.Read())
            {
                return (bool)reader["IsValid"];
            }
            return false;
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
                return logininfo;
            }

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
                    return logininfo;
                }
            }

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
                    complaint.LoggedDate =  Convert.ToDateTime(row["Logged_On_Date"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                    complaint.Title = row["Title"].ToString();
                    complaints.Add(complaint);
                }
            }

            return complaints;
        }
      
        #endregion
    }
}
