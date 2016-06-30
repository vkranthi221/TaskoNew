using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Tasko.Model;

namespace Tasko.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthenticationService" in both code and config file together.
    [ServiceContract]
    public interface IVendorAppService
    {
        /**
         * @api {post} v1/GetAuthCode Get Auth Code
         * @apiName GetAuthCode
         * @apiGroup Vendor
         * 
         * @apiParam\n
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": "3E71AF3FF2196045BB3212623BFDEF91",
         },
          "Error": false,
          "Message": "Authentication Successful",
          "Status": 200
        }
         * @apiError Authentication failed.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Authentication failed",
          "Status": 400
        }
         */
        [OperationContract]
        [FaultContract(typeof(ErrorDetails))]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "auth")]
        Response GetAuthCode();

        /**
         * @api {post} v1/Login Vendor Login
         * @apiName Login
         * @apiGroup Vendor
         * 
         * @apiParam {String} username User name to login.  
         * 
         * @apiParam {String} password password of the user.  
         * 
         * @apiParam {String} mobilenumber mobile number of the user. 
         * 
         * @apiParam {Int16} userType user type. 
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
                     "__type": "LoginInfo:#Tasko.Model",
                     "TokenId": "6CEC15B7B6FC23439AC131F54551BB22",
                     "UserId": "FC73EC7242E28142ACCAFDF4703F0EBF"
                  }
         },
          "Error": false,
          "Message": "Login Successfull",
          "Status": 200
        }
         * @apiError Authentication failed.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Authentication failed",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response Login(string username, string password, string mobilenumber, Int16 userType);

        /**
         * @api {post} v1/Logout Log out
         * @apiName Logout
         * @apiGroup Vendor
         * 
         * @apiParam\n
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": "null",
         },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError Authentication failed.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error logging out",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response Logout();

        /**
         * @api {post} v1/GetVendorDetails Get Vendor details
         * @apiName GetVendorDetails
         * @apiGroup Vendor
         *
         * @apiParam {String} vendorId Vendor Id.                
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
            "__type": "Vendor:#Tasko.Model",
            "Address": "KPHB,HMT Hills",
            "BaseRate": 100,
            "CallsToCustomerCare": 123,
            "DataConsumption": 10,
            "EmailAddress": "sree@gmail.com",
            "Id": "05B3274A2E6EC94D8C0292293823C122",
            "IsVendorLive": false,
            "IsVendorVerified": true,
            "MobileNumber": "9848022669",
            "Name": "Steve",
            "NoOfEmployees": 10,
            "UserName": "sree123"
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError VendorIdNotFound The Vendor id is invalid or was not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Vendor not found",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorDetails(string vendorId);

        /**
         * @api {post} v1/GetVendorServices Get Vendor services
         * @apiName GetVendorServices
         * @apiGroup Vendor
         *
         * @apiParam {String} vendorId Vendor Id.                
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                        "__type": "VendorService:#Tasko.Model",
                         "Id": "CF9A27B3DA0D5E418B1A8E6CC79218AD",
                         "ImageURL": "",
                         "IsActive": true,
                         "Name": "Microwave Service"
                    }
                 ]
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError NO_SERVICES_AVAILABLE No services available.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "No services available",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorServices(string vendorId);

        /// <summary>
        /// Gets the vendor sub services.
        /// </summary>
        /// <param name="vendorServiceId">The vendor service identifier.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorSubServices(string vendorServiceId);

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderStatus">The order status.</param>
        /// <param name="Comments">The comments.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateOrderStatus(string orderId, short orderStatus, string Comments);

        /// <summary>
        /// Updates the vendor services.
        /// </summary>
        /// <param name="vendorServices">The vendor services.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendorServices(List<VendorService> vendorServices);

        /// <summary>
        /// Updates the vendor base rate.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="baseRate">The base rate.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendorBaseRate(string vendorId, double baseRate);

        /// <summary>
        /// Gets the Vendor Ratings
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorRatings(string vendorId);

        /// <summary>
        /// Gets the Vendor overall Ratings
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorOverallRatings(string vendorId);

         /// <summary>
        /// Gets the Vendor orders
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="orderStatusId">The order status id.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorOrders(string vendorId, int orderStatusId, int pageNumber, int recordsPerPage);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ChangePassword(string vendorId, string password, string oldPassword);

        /// <summary>
        /// Updates Vendor details
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns>Response</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendor(Vendor vendor);
    }
}
