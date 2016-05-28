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
        /// Inserts the authentication code.
        /// </summary>
        /// <returns>Auth Code</returns>
        public static string InsertAuthCode()
        {
            Vendor objVendor = new Vendor();

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_InsertAuthCode");
            if (reader.Read())
            {
                return BinaryConverter.ConvertByteToString((byte[])reader["Auth_Code"]);
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the authentication code.
        /// </summary>
        /// <param name="authCode">The authentication code.</param>
        /// <returns>true/false</returns>
        public static bool ValidateAuthCode(string authCode)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pAuthCode", DbType.Binary, BinaryConverter.ConvertStringToByte(authCode)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_ValidateAuthCode", objParameters.ToArray());

            if (reader.Read())
            {
                return (bool)reader["IsValid"];
            }
            return false;

        }

        /// <summary>
        /// Validates the token code.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>tue/false</returns>
        public static bool ValidateTokenCode(string tokenCode, string userId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pTokenCode", DbType.Binary, BinaryConverter.ConvertStringToByte(tokenCode)));
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_ValidateTokenCode", objParameters.ToArray());

            if (reader.Read())
            {
                return (bool)reader["IsValid"];
            }
            return false;

        }
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
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passowrd">The passowrd.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns>
        /// Login Info
        /// </returns>
        public static LoginInfo Login(string userName, string passowrd, string mobileNumber, Int16 userType)
        {
            LoginInfo logininfo = null;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.String, userName));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, passowrd));
            objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, mobileNumber));

            objParameters.Add(SqlHelper.CreateParameter("@pUserType", DbType.Int16, userType)); // 1 for vendor

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_Login", objParameters.ToArray());
            if (reader.Read())
            {
                logininfo = new LoginInfo();
                logininfo.TokenId = BinaryConverter.ConvertByteToString((byte[])reader["AUTH_CODE"]);
                logininfo.UserId = BinaryConverter.ConvertByteToString((byte[])reader["USERID"]);
            }

            reader.Close();

            return logininfo;
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
                    service.ImageURL = row["IMAGE_URL"].ToString();
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
                    service.ImageURL = row["IMAGE_URL"].ToString();
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
        /// <param name="Comments">The comments.</param>
        public static void UpdateOrderStatus(string orderId, short orderStatus,string Comments)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderStatus", DbType.Int16, orderStatus));
            objParameters.Add(SqlHelper.CreateParameter("@pComments", DbType.Int16, Comments));
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

        /// <summary>
        /// Logouts the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authCode">The authentication code.</param>
        public static void Logout(string userId, string authCode)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            objParameters.Add(SqlHelper.CreateParameter("@pAuthCode", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));

            SqlHelper.ExecuteNonQuery("dbo.usp_Logout", objParameters.ToArray());
        }

        /// <summary>
        /// Gets the vendor ratings.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Vendor Rating</returns>
        public static List<VendorRating> GetVendorRatings(string vendorId)
        {
            List<VendorRating> vendorRatings = new List<VendorRating>();
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorRatings", objParameters.ToArray());
            while (reader.Read())
            {
                VendorRating rating = new VendorRating();
                rating.Id = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_RATING_ID"]);
                rating.ServiceQuality = Convert.ToDecimal(reader["SERVICE_QUALITY"]);
                rating.Punctuality = Convert.ToDecimal(reader["PUNCTUALITY"]);
                rating.Courtesy = Convert.ToDecimal(reader["COURTESY"]);
                rating.Price = Convert.ToDecimal(reader["PRICE"]);
                rating.ReviewDate = Convert.ToDateTime(reader["REVIEW_DATE"]);
                rating.Comments = reader["COMMENTS"].ToString();
                rating.CustomerName = reader["NAME"].ToString();
                vendorRatings.Add(rating);
            }

            reader.Close();

            return vendorRatings;
        }

        /// <summary>
        /// Gets the vendor overall ratings.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Overall Vendor Rating</returns>
        public static VendorOverallRating GetVendorOverallRatings(string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOverallRating", objParameters.ToArray());
            VendorOverallRating rating = new VendorOverallRating();

            if (reader.Read())
            {
                rating.ServiceQuality = Convert.ToDecimal(reader["QUALITY"]);
                rating.Punctuality = Convert.ToDecimal(reader["PUNCTUALITY"]);
                rating.Courtesy = Convert.ToDecimal(reader["COURTESY"]);
                rating.Price = Convert.ToDecimal(reader["PRICE"]);
                rating.OverAllRating = Convert.ToDecimal(reader["TOTAL"]);
            }

            reader.Close();

            return rating;
        }

        /// <summary>
        /// Gets the vendor orders.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="orderStatusId">The order status identifier.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>Vendor Orders</returns>
        public static List<OrderSummary> GetVendorOrders(string vendorId, int orderStatusId, int pageNumber, int recordsPerPage)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pORDERSTATUSID", DbType.Int32, orderStatusId));
            objParameters.Add(SqlHelper.CreateParameter("@pRECORDSPERPAGE", DbType.Int32, recordsPerPage));
            objParameters.Add(SqlHelper.CreateParameter("@pPAGENO", DbType.Int32, pageNumber));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOrders", objParameters.ToArray());
            List<OrderSummary> orders = new List<OrderSummary>();

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.OrderId = reader["ORDER_ID"].ToString();
                order.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]);
                order.ServiceName = reader["SERVICENAME"].ToString();
                order.OrderStatus = reader["ORDERSTATUSNAME"].ToString();
                order.Comments = reader["COMMENTS"].ToString();
                orders.Add(order);
            }

            reader.Close();

            return orders;
        }
    }
}
