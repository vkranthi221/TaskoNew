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

        /**
         * @api {post} v1/GetVendorSubServices Get Vendor sub services
         * @apiName GetVendorSubServices
         * @apiGroup Vendor
         *
         * @apiParam {String} vendorServiceId Vendor Service Id.                
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "VendorService:#Tasko.Model",
                      "Id": "82B4B5E0C2ACED43BC5233F1A715071B",
                      "ImageURL": "",
                      "IsActive": true,
                      "Name": "test2"
                    },
                    {
                      "__type": "VendorService:#Tasko.Model",
                      "Id": "BFD1E3C77DE53D4E9026DB99FC71CA83",
                      "ImageURL": "",
                      "IsActive": true,
                      "Name": "test"
                    }
                  ],
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError NO_SUB_SERVICES_AVAILABLE No sub services available.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "No sub services available",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorSubServices(string vendorServiceId);

        /**
         * @api {post} v1/UpdateOrderStatus Update Order Status
         * @apiName UpdateOrderStatus
         * @apiGroup Vendor
         *
         * @apiParam {String} orderId Order Id.          
         * 
         * @apiParam {Short} orderStatus Order Status.            
         * 
         * @apiParam {String} Comments Comments.
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ERROR_UPDATING_ORDER_STATUS Error while updating OrderStatus.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error while updating OrderStatus",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateOrderStatus(string orderId, short orderStatus, string Comments);

        /**
         * @api {post} v1/UpdateVendorServices Update Vendor Services
         * @apiName UpdateVendorServices
         * @apiGroup Vendor
         *
         * @apiParam {List<VendorService>} vendorServices List of Vendor Services.          
         * 
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ERROR_UPDATING_VENDOR_SERVICES Error while updating Vendor Services.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error while updating Vendor Services",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendorServices(List<VendorService> vendorServices);

        /**
         * @api {post} v1/UpdateVendorBaseRate Update Vendor Base Rate
         * @apiName UpdateVendorBaseRate
         * @apiGroup Vendor
         *
         * @apiParam {string} vendorId Vendor Id.          
         * 
         * @apiParam {double} baseRate Base Rate.
         * 
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ERROR_UPDATING_VENDOR_BASE_RATE Error while updating Vendor Base Rate.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error while updating Vendor Base Rate",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendorBaseRate(string vendorId, double baseRate);

        /**
         * @api {post} v1/GetVendorRatings Get Vendor Ratings
         * @apiName GetVendorRatings
         * @apiGroup Vendor
         *
         * @apiParam {string} vendorId Vendor Id.          
         * 
         {
          "Data": [
                    {
                      "__type": "VendorRating:#Tasko.Model",
                      "Comments": "Service is Good",
                      "Courtesy": 3,
                      "CustomerId": null,
                      "CustomerName": "Shivaji123",
                      "Id": "342CA9BFFA1F2E419FADB343C7DE3EE7",
                      "OverAllRating": 0,
                      "Price": 4,
                      "Punctuality": 1,
                      "ReviewDate": "2016-07-01 05:50:19",
                      "ServiceQuality": 5,
                      "VendorId": null
                    },
                    {
                      "__type": "VendorRating:#Tasko.Model",
                      "Comments": "Service is in time",
                      "Courtesy": 3,
                      "CustomerId": null,
                      "CustomerName": "Shivaji123",
                      "Id": "FD388BB73B94644889EA5C56A1163554",
                      "OverAllRating": 0,
                      "Price": 4,
                      "Punctuality": 2,
                      "ReviewDate": "2016-07-01 05:50:19",
                      "ServiceQuality": 2,
                      "VendorId": null
                    }
                  ],
  
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError NO_RATINGS_FOR_VENDOR No ratings for vendor.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "No ratings for vendor",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorRatings(string vendorId);

        /**
         * @api {post} v1/GetVendorOverallRatings Vendor Overall Ratings
         * @apiName GetVendorOverallRatings
         * @apiGroup Vendor
         *
         * @apiParam {string} vendorId Vendor Id.          
         * 
         {
          "Data": {
                    "__type": "VendorOverallRating:#Tasko.Model",
                    "Courtesy": 3,
                    "OverAllRating": 3,
                    "Price": 3,
                    "Punctuality": 2,
                    "ServiceQuality": 3
                  },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError NO_RATINGS_FOR_VENDOR No ratings for vendor
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "No ratings for vendor",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorOverallRatings(string vendorId);

        /**
        * @api {post} v1/GetVendorOrders Vendor Orders
        * @apiName GetVendorOrders
        * @apiGroup Vendor
        *
        * @apiParam {string} vendorId Vendor Id.
        *
        * @apiParam {int} orderStatusId Order Status Id.
        *
        * @apiParam {int} pageNumber Page Number.
        *
        *  @apiParam {int} recordsPerPage Records Per Page.
        * 
        {
         "Data": [
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": "",
                      "OrderId": "TASKO1010",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-07-01 05:50:19",
                      "ServiceId": null,
                      "ServiceName": "Microwave Service"
                    },
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": "",
                      "OrderId": "TASKO1009",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-07-01 05:50:19",
                      "ServiceId": null,
                      "ServiceName": "Microwave Service"
                    }
                  ],
         "Error": false,
         "Message": "Success",
         "Status": 200
       }
        * @apiError NO_ORDERS_FOR_VENDOR No orders for vendor
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "No orders for vendor",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorOrders(string vendorId, int orderStatusId, int pageNumber, int recordsPerPage);

        /**
        * @api {post} v1/ChangePassword Change password
        * @apiName ChangePassword
        * @apiGroup Vendor
        *
        * @apiParam {string} vendorId Vendor Id.
        *
        * @apiParam {string} password Password.
        *
        * @apiParam {string} oldPassword Old Password.
        *
        {
        "Data": null,
         "Error": false,
         "Message": "Success",
         "Status": 200
       }
        * @apiError INVALID_OLD_PASSWORD Invalid old password
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "Invalid old password",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ChangePassword(string vendorId, string password, string oldPassword);

        /**
        * @api {post} v1/UpdateVendor Update Vendor
        * @apiName UpdateVendor
        * @apiGroup Vendor
        *
        * @apiParam {Vendor} vendor Vendor.
        *
        {
         "Data": null,
         "Error": false,
         "Message": "Success",
         "Status": 200
       }
        * @apiError INVALID_TOKEN_CODE Invalid token code
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "Invalid token code",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateVendor(Vendor vendor);
    }
}
