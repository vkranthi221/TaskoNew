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
            string authCode = string.Empty;
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_InsertAuthCode");
            if (reader.Read())
            {
                authCode = BinaryConverter.ConvertByteToString((byte[])reader["Auth_Code"]);
            }

            reader.Close();
            return authCode;
        }

        /// <summary>
        /// Validates the authentication code.
        /// </summary>
        /// <param name="authCode">The authentication code.</param>
        /// <param name="isDeleteRequired">if set to <c>true</c> [is delete required].</param>
        /// <returns>
        /// true/false
        /// </returns>
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

        /// <summary>
        /// Validates the token code.
        /// </summary>
        /// <param name="tokenCode">The token code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>tue/false</returns>
        public static bool ValidateTokenCode(string tokenCode, string userId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            BinaryConverter.IsValidGuid(tokenCode, TaskoEnum.IdType.TokenCode);
            objParameters.Add(SqlHelper.CreateParameter("@pTokenCode", DbType.Binary, BinaryConverter.ConvertStringToByte(tokenCode)));

            BinaryConverter.IsValidGuid(userId, TaskoEnum.IdType.UserId);
            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_ValidateTokenCode", objParameters.ToArray());

            bool isvalid = false;
            if (reader.Read())
            {
                isvalid = (bool)reader["IsValid"];
            }

            reader.Close();
            return isvalid;
        }

        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// vendor details
        /// </returns>
        public static Vendor GetVendor(string vendorId)
        {
            Vendor objVendor = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorDetails", objParameters.ToArray());
            if (reader.Read())
            {
                objVendor = new Vendor();
                objVendor.Id = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USER_NAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.MobileNumber = reader["MOBILE_NUMBER"].ToString();
                objVendor.EmailAddress = Convert.ToString(reader["EMAIL_ADDRESS"]);
                objVendor.AddressDetails = new AddressInfo();
                objVendor.AddressDetails.AddressId = BinaryConverter.ConvertByteToString((byte[])reader["Address_ID"]);
                objVendor.AddressDetails.Address = reader["VENDOR_ADDRESS"].ToString();
                objVendor.AddressDetails.Country = reader["VENDOR_COUNTRY"].ToString();
                objVendor.AddressDetails.AddressType = reader["VENDOR_ADDRESS_TYPE"].ToString();
                objVendor.AddressDetails.City = reader["VENDOR_CITY"].ToString();
                objVendor.AddressDetails.State = reader["VENDOR_STATE"].ToString();
                objVendor.AddressDetails.Lattitude = reader["VENDOR_LATTITUDE"].ToString();
                objVendor.AddressDetails.Locality = reader["VENDOR_LOCALITY"].ToString();
                objVendor.AddressDetails.Longitude = reader["VENDOR_LONGITUDE"].ToString();
                objVendor.AddressDetails.Pincode = reader["VENDOR_PINCODE"].ToString();
                if (!(reader["HOME_LATITIUDE"] is System.DBNull))
                {
                    objVendor.AddressDetails.HomeLattitude = reader["HOME_LATITIUDE"].ToString();
                }

                if (!(reader["HOME_LONGITUDE"] is System.DBNull))
                {
                    objVendor.AddressDetails.HomeLongitude = reader["HOME_LONGITUDE"].ToString();
                }

                objVendor.NoOfEmployees = Convert.ToInt32(reader["EMPLOYEE_COUNT"]);
                objVendor.BaseRate = Convert.ToDouble(reader["BASE_RATE"]);
                objVendor.MonthlyCharge = Convert.ToDecimal(reader["MONTHLY_CHARGE"]);
                objVendor.IsVendorVerified = Convert.ToBoolean(reader["IS_VENDOR_VERIFIED"]);
                objVendor.VenorRefId = Convert.ToInt32(reader["VENDOR_REF_ID"]);
                objVendor.RegisteredDate = Convert.ToDateTime(reader["REGISTERED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                if (reader["DATE_OF_BIRTH"] != null)
                {
                    objVendor.DateOfBirth = Convert.ToDateTime(reader["DATE_OF_BIRTH"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                }

                objVendor.Gender = (Int16)reader["GENDER"];
                objVendor.VendorAlsoKnownAs = reader["VENDOR_ALSO_KNOWN_AS"].ToString();
                objVendor.Experience = reader["EXPERIENCE"].ToString();
                objVendor.FacebookUrl = Convert.ToString(reader["FACEBOOK_URL"]);                
                objVendor.Photo = Convert.ToString(reader["PHOTO"]);
                objVendor.IsPowerSeller = Convert.ToBoolean(reader["IS_POWER_SELLER"]);
                //objVendor.DataConsumption = Convert.ToInt32(reader["DATA_CONSUMPTION"]);
                //objVendor.CallsToCustomerCare = Convert.ToInt32(reader["CALLS_TO_CUSTOMER_CARE"]);
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
            objParameters.Add(SqlHelper.CreateParameter("@pUserName", DbType.String, userName));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, passowrd));
            objParameters.Add(SqlHelper.CreateParameter("@pMobileNumber", DbType.String, mobileNumber));

            objParameters.Add(SqlHelper.CreateParameter("@pUserType", DbType.Int16, userType)); // 1 for vendor

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_Login", objParameters.ToArray());
            if (reader.Read())
            {
                logininfo = new LoginInfo();
                if (!(reader["AUTH_CODE"] is System.DBNull))
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
        /// Updates the vendor services.
        /// </summary>
        /// <param name="vendorServices">The vendor services.</param>
        public static void UpdateVendorServices(List<VendorService> vendorServices)
        {
            foreach (VendorService vendorService in vendorServices)
            {
                List<SqlParameter> objParameters = new List<SqlParameter>();

                BinaryConverter.IsValidGuid(vendorService.Id, TaskoEnum.IdType.VendorServiceId);
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

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
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
                    if (row["IMAGE_URL"] != null)
                    {
                        service.ImageURL = row["IMAGE_URL"].ToString();
                    }

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
            BinaryConverter.IsValidGuid(vendorServiceId, TaskoEnum.IdType.VendorServiceId);
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
                    if (row["IMAGE_URL"] != null)
                    {
                        service.ImageURL = row["IMAGE_URL"].ToString();
                    }

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
        public static void UpdateOrderStatus(string orderId, short orderStatus, string Comments)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            objParameters.Add(SqlHelper.CreateParameter("@pOrderStatus", DbType.Int32, orderStatus));
            objParameters.Add(SqlHelper.CreateParameter("@pComments", DbType.String, Comments));
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

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pBaseRate", DbType.Decimal, baseRate));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateBaseRate", objParameters.ToArray());
        }

        /// <summary>
        /// Logouts the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authCode">The authentication code.</param>
        public static void Logout(string userId, string tokenCode)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pUserId", DbType.Binary, BinaryConverter.ConvertStringToByte(userId)));
            objParameters.Add(SqlHelper.CreateParameter("@pTokenCode", DbType.Binary, BinaryConverter.ConvertStringToByte(tokenCode)));

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

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
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
                rating.ReviewDate = Convert.ToDateTime(reader["REVIEW_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                rating.Comments = reader["COMMENTS"].ToString();
                rating.OverAllRating = Convert.ToDecimal(reader["TOTAL"]);
                rating.CustomerName = reader["NAME"].ToString();
                rating.OrderId = reader["ORDER_ID"].ToString();
                if (!(reader["ORDER_PRICE"] is System.DBNull))
                {
                    rating.OrderPrice = Convert.ToDecimal(reader["ORDER_PRICE"]);
                }

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

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOverallRating", objParameters.ToArray());
            VendorOverallRating rating = new VendorOverallRating();

            if (reader.Read())
            {
                if (!(reader["QUALITY"] is System.DBNull))
                {
                    rating.ServiceQuality = Convert.ToDecimal(reader["QUALITY"]);
                }

                if (!(reader["PUNCTUALITY"] is System.DBNull))
                {
                    rating.Punctuality = Convert.ToDecimal(reader["PUNCTUALITY"]);
                }

                if (!(reader["COURTESY"] is System.DBNull))
                {
                    rating.Courtesy = Convert.ToDecimal(reader["COURTESY"]);
                }

                if (!(reader["PRICE"] is System.DBNull))
                {
                    rating.Price = Convert.ToDecimal(reader["PRICE"]);
                }

                if (!(reader["TOTAL"] is System.DBNull))
                {
                    rating.OverAllRating = Convert.ToDecimal(reader["TOTAL"]);
                }
            }

            reader.Close();

            return rating;
        }

        /// <summary>
        /// Gets the vendor orders.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="orderStatusId">The order status identifiers.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">Records per page.</param>
        /// <returns>
        /// Vendor Orders
        /// </returns>
        public static List<OrderSummary> GetVendorOrders(string vendorId, string orderStatusId, int pageNumber, int recordsPerPage)
        {            
            List<OrderSummary> orders = new List<OrderSummary>();

            if (orderStatusId != null)
            {
                BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
                string[] listOfOrderstatusIds = orderStatusId.Split(',');

                foreach (string statusId in listOfOrderstatusIds)
                {
                    List<SqlParameter> objParameters = new List<SqlParameter>();
                    objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
                    objParameters.Add(SqlHelper.CreateParameter("@pORDERSTATUSID", DbType.Int32, Convert.ToInt32(statusId)));
                    objParameters.Add(SqlHelper.CreateParameter("@pRECORDSPERPAGE", DbType.Int32, recordsPerPage));
                    objParameters.Add(SqlHelper.CreateParameter("@pPAGENO", DbType.Int32, pageNumber));
                    IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorOrders", objParameters.ToArray());

                    while (reader.Read())
                    {
                        OrderSummary order = new OrderSummary();
                        order.OrderId = reader["ORDER_ID"].ToString();
                        order.RequestedDate = Convert.ToDateTime(reader["REQUESTED_DATE"]).ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                        order.ServiceName = reader["SERVICENAME"].ToString();
                        order.OrderStatus = reader["ORDERSTATUSNAME"].ToString();
                        order.Comments = reader["COMMENTS"].ToString();
                        orders.Add(order);
                    }

                    reader.Close();
                }
            }

            return orders;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <returns>is old password is correct or not</returns>
        public static bool ChangePassword(string vendorId, string password, string oldPassword)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            bool isValidOldPassword = false;

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pPassword", DbType.String, password));
            objParameters.Add(SqlHelper.CreateParameter("@pOldPassword", DbType.String, oldPassword));
            isValidOldPassword = (bool)SqlHelper.ExecuteScalar("dbo.usp_ChangePassword", objParameters.ToArray());

            return isValidOldPassword;
        }

        /// <summary>
        /// Updates vendor details
        /// </summary>
        /// <param name="vendor">vendor details</param>
        public static void UpdateVendor(Vendor vendor)
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

            // Vendor also known as
            if (!string.IsNullOrEmpty(vendor.VendorAlsoKnownAs))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pVendorAlsoKnownAs", DbType.String, vendor.VendorAlsoKnownAs));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pVendorAlsoKnownAs", DbType.String, DBNull.Value));
            }

            // Experience
            if (!string.IsNullOrEmpty(vendor.Experience))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pExperience", DbType.String, vendor.Experience));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pExperience", DbType.String, DBNull.Value));
            }

            if (!string.IsNullOrEmpty(vendor.FacebookUrl))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pFacebookUrl", DbType.String, vendor.FacebookUrl));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pFacebookUrl", DbType.String, DBNull.Value));
            }
                        
            objParameters.Add(SqlHelper.CreateParameter("@pIsVendorVerified", DbType.Boolean, vendor.IsVendorVerified));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendor", objParameters.ToArray());
        }

        public static GcmUser GetGCMUserDetails(string vendorId, string customerId)
        {
            GcmUser gcmUser = null;

            List<SqlParameter> objParameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(customerId))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));
            }

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetGCMUserDetails", objParameters.ToArray());
            if (reader.Read())
            {
                gcmUser = new GcmUser();
                gcmUser.GcmId = BinaryConverter.ConvertByteToString((byte[])reader["GCMID"]);
                gcmUser.GcmRegId = reader["GCMREGID"].ToString();
                gcmUser.Name = reader["NAME"].ToString();
                if (reader["VENDOR_ID"] != null && !string.IsNullOrEmpty(reader["VENDOR_ID"].ToString()))
                {
                    gcmUser.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                }
                else
                {
                    gcmUser.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);
                }
            }

            reader.Close();
            return gcmUser;
        }

        public static void UpdateVendorLocation(AddressInfo addressInfo, string vendorId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            objParameters.Add(SqlHelper.CreateParameter("@pLatitude", DbType.String, addressInfo.Lattitude));
            objParameters.Add(SqlHelper.CreateParameter("@pLongitude", DbType.String, addressInfo.Longitude));
            objParameters.Add(SqlHelper.CreateParameter("@pHomeLatitude", DbType.String, addressInfo.HomeLattitude));
            objParameters.Add(SqlHelper.CreateParameter("@pHomeLongitude", DbType.String, addressInfo.HomeLongitude));
            objParameters.Add(SqlHelper.CreateParameter("@pAddress", DbType.String, addressInfo.Address));
            objParameters.Add(SqlHelper.CreateParameter("@pAddressType", DbType.String, addressInfo.AddressType));
            objParameters.Add(SqlHelper.CreateParameter("@pCity", DbType.String, addressInfo.City));
            objParameters.Add(SqlHelper.CreateParameter("@pCountry", DbType.String, addressInfo.Country));
            objParameters.Add(SqlHelper.CreateParameter("@pLocality", DbType.String, addressInfo.Locality));
            objParameters.Add(SqlHelper.CreateParameter("@pPincode", DbType.String, addressInfo.Pincode));
            objParameters.Add(SqlHelper.CreateParameter("@pState", DbType.String, addressInfo.State));
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.String, BinaryConverter.ConvertStringToByte(vendorId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateVendorLocation", objParameters.ToArray());
        }

        public static List<VendorSummary> GetActiveVendorLocations()
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetActiveVendorLocations", objParameters.ToArray());
            List<VendorSummary> vendors = new List<VendorSummary>();

            while (reader.Read())
            {
                VendorSummary objVendor = new VendorSummary();
                objVendor.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);
                objVendor.UserName = reader["USERNAME"].ToString();
                objVendor.Name = reader["NAME"].ToString();
                objVendor.Latitude = Convert.ToDecimal(reader["LATITIUDE"]);
                objVendor.Longitude = Convert.ToDecimal(reader["LONGITUDE"]);
                vendors.Add(objVendor);
            }

            reader.Close();

            return vendors.Count > 0 ? vendors : null;
        }
        
        public static string GetVendorPhone(string vendorId)
        {
            string phone = string.Empty;
            List<SqlParameter> objParameters = new List<SqlParameter>();

            BinaryConverter.IsValidGuid(vendorId, TaskoEnum.IdType.VendorId);
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.Binary, BinaryConverter.ConvertStringToByte(vendorId)));

            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetVendorPhone", objParameters.ToArray());
            if (reader.Read())
            {
                phone = reader["MOBILE_NUMBER"].ToString();
            }

            reader.Close();

            return phone;
        }
        
        /// <summary>
        /// Gets all pending orders.
        /// </summary>
        /// <returns>list of Pending Orders</returns>
        public static List<OrderSummary> GetAllPendingOrders()
        {
            List<OrderSummary> pendingOrders = new List<OrderSummary>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetAllPendingOrders", objParameters.ToArray());

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.OrderId = reader["ORDER_ID"].ToString();                
                pendingOrders.Add(order);
            }

            reader.Close();

            return pendingOrders;
        }

        /// <summary>
        /// Resets the logins.
        /// </summary>
        public static void ResetAllLogins()
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            SqlHelper.ExecuteNonQuery("dbo.usp_ResetAllLogins", objParameters.ToArray());
        }

        public static List<OrderSummary> GetOfflineOrdersWithNoRatings()
        {
            List<OrderSummary> pendingOrders = new List<OrderSummary>();
            List<SqlParameter> objParameters = new List<SqlParameter>();
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_GetOfflineOrdersWithNoRatings", objParameters.ToArray());

            while (reader.Read())
            {
                OrderSummary order = new OrderSummary();
                order.CustomerId = BinaryConverter.ConvertByteToString((byte[])reader["CUSTOMER_ID"]);                
                order.OrderId = reader["ORDER_ID"].ToString();
                order.VendorId = BinaryConverter.ConvertByteToString((byte[])reader["VENDOR_ID"]);                
                order.VendorName = reader["VENDOR_NAME"].ToString();
                order.ServiceName = reader["SERVICE_NAME"].ToString();
                pendingOrders.Add(order);
            }

            reader.Close();

            return pendingOrders;
        }

        public static void UpdateOrderIsNotified(string orderId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pOrderId", DbType.String, orderId));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateOrderIsNotified", objParameters.ToArray());
        }

        #region Notifications
        public static string StoreUser(string name, string vendorId, string gcmRedId, string customerId)
        {
            string userId = string.Empty;
            List<SqlParameter> objParameters = new List<SqlParameter>();
            if(!string.IsNullOrEmpty(vendorId))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pIsVendor", DbType.Boolean, true));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pIsVendor", DbType.Boolean, false));
            }
            objParameters.Add(SqlHelper.CreateParameter("@pCustomerId", DbType.Binary, BinaryConverter.ConvertStringToByte(customerId)));
            objParameters.Add(SqlHelper.CreateParameter("@pVendorId", DbType.String, BinaryConverter.ConvertStringToByte(vendorId)));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, name));
            objParameters.Add(SqlHelper.CreateParameter("@pgcmRedId", DbType.String, gcmRedId));
            IDataReader reader = SqlHelper.GetDataReader("dbo.usp_StoreUser", objParameters.ToArray());
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
        #endregion
    }
}
