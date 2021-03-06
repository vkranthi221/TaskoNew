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
         * @api {post} v1/auth Get Auth Code
         * @apiName auth
         * @apiGroup Vendor
         * 
         * @apiHeader {string} X-APIKey API Key
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "X-APIKey": "API Key" ,
         *  }
         * 
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": "API key comes here",
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
         * @apiHeader {string} Auth_Code Auth Code
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Auth_Code": "API Key",
         *    "Content-Type": "application/json"
         *  }
         *  
         * @apiParam {String} username User name to login.  
         * 
         * @apiParam {String} password password of the user.  
         * 
         * @apiParam {String} mobilenumber mobile number of the user. 
         * 
         * @apiParam {Int16} userType user type.
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "username": "User name to login",
         *    "password": "Password of the user",
         *    "mobilenumber": "Mobile number of the user",
         *    "userType": "User type",
         *  }
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} User_Id User Id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "User_Id": "Logged in User ID",
         *    "Content-Type": "application/json"
         *  }
         *        
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {String} vendorId Vendor Id. 
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id " 
         *  }
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
            "FacebookUrl":"http://facebook.com/xyz",
            "Photo":"http://Tasko.in/Images/abc.jpg",
            "Name": "Steve",
            "NoOfEmployees": 10,
            "UserName": "sree123",
            "IsPowerSeller": true
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {String} vendorId Vendor Id.     
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id " 
         *  }
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {String} vendorServiceId Vendor Service Id.  
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorServiceId": "Vendor Service Id to get the sub services " 
         *  }
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {String} orderId Order Id.          
         * 
         * @apiParam {Short} orderStatus Order Status.            
         * 
         * @apiParam {String} comments Comments.
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "orderId": "Order Id to update the status",
         *    "orderStatus": "Order status ",
         *    "comments": "Comments",
         *  }
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         * 
         * @apiParam {List} vendorServices List of Vendor Services.          
         * 
         * @apiParamExample {json} Param-Example:
         * {
         *   "vendorServices": [
         *  {
         *      "__type": "VendorService:#Tasko.Model",
         *      "Id": "196898FF2956FE478FB4FD9C2A8B49F6",
         *      "ImageURL": "",
         *      "IsActive": true,
         *      "Name": "Carpentry"
         *  },
         *  {
         *      "__type": "VendorService:#Tasko.Model",
         *      "Id": "8B9BDFDF712B764E88FF29E8733A92C2",
         *      "ImageURL": "",
         *      "IsActive": false,
         *      "Name": "Pest Control"
         *  },
         *  {
         *      "__type": "VendorService:#Tasko.Model",
         *      "Id": "9B41B620DFDFD24D8A861BFB96827DDD",
         *      "ImageURL": "",
         *      "IsActive": true,
         *      "Name": "Microwave Service"
         *  },
         *  {
         *      "__type": "VendorService:#Tasko.Model",
         *      "Id": "E0311E79F6785541B6E008721A4B41BA",
         *      "ImageURL": "",
         *      "IsActive": true,
         *      "Name": "Refrigerator Service"
         *  },
         *  {
         *      "__type": "VendorService:#Tasko.Model",
         *      "Id": "FB282BF584AB1145B73FB35CB8589C1E",
         *      "ImageURL": "",
         *      "IsActive": true,
         *      "Name": "Plumber"
         *    }
         *   ],
         *  }
         * 
         * @apiSuccessExample Success-Response: 
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {string} vendorId Vendor Id.          
         * 
         * @apiParam {double} baseRate Base Rate.
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id",
         *    "baseRate": "Base Rate"
         *  }
         *  
         * @apiSuccessExample Success-Response:
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {string} vendorId Vendor Id.
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id"
         *  }
         * 
         * @apiSuccessExample Success-Response:
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
                      "VendorId": null,
                      "OrderPrice":500
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
                      "VendorId": null,
                      "OrderPrice":500
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
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {string} vendorId Vendor Id.        
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id"
         *  }
         * 
         * @apiSuccessExample Success-Response:
         * {
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
        * @api {post} v1/GetVendorOrders Get Vendor Orders
        * @apiName GetVendorOrders
        * @apiGroup Vendor
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {string} vendorId Vendor Id.
        *
        * @apiParam {string} orderStatusId Order Status Id's. Accepts Comma separated values ex: "1,2" for multiple order statuses.
        *
        * @apiParam {int} pageNumber Page Number.
        *
        * @apiParam {int} recordsPerPage Records Per Page.
        *  
        * @apiParamExample {json} Param-Example:
        *  {
        *    "vendorId": "Vendor Id",
        *    "orderStatusId": "Status of the order",
        *    "pageNumber": "Page number",
        *    "recordsPerPage": "Number of records per page"
        *  }
        *  
        * @apiSuccessExample Success-Response:
        {
         {
          "Data": {
            "__type": "Vendor:#Tasko.Model",
            "AddressDetails": {
              "Address": "test",
              "AddressId": null,
              "AddressType":"Home",
              "City": "Hyderabad",
              "Country": "India",
              "Lattitude": "1",
              "Locality": "KPHB",
              "Longitude": "2",
              "Pincode": "500072",
              "State": "Hyderabad"
            },
            "BaseRate": 100,
            "DateOfBirth": "7/7/2016 1:51:33 PM",
            "EmailAddress": "sree@gmail.com",
            "Gender": 1,
            "Id": "3BCF0E621CC9FA45B644AD360D3B7E29",
            "IsVendorLive": false,
            "IsVendorVerified": true,
            "MobileNumber": "1234567890",
            "Name": "Srikanth",
            "NoOfEmployees": 10,
            "Password": null,
            "Photo": "",
            "UserName": "sree123",
            "VendorDetails": null,
            "VendorServices": null
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
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
        Response GetVendorOrders(string vendorId, string orderStatusId, int pageNumber, int recordsPerPage);

        /**
        * @api {post} v1/ChangePassword Change password
        * @apiName ChangePassword
        * @apiGroup Vendor
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {string} vendorId Vendor Id.
        *
        * @apiParam {string} password Password.
        *
        * @apiParam {string} oldPassword Old Password.
        * 
        * @apiParam {bool} chkOld Check for old password.
        * 
        * @apiParamExample {json} Param-Example:
        *  {
        *    "vendorId": "Vendor Id",
        *    "password": "New Password",
        *    "oldPassword": "Old Password"
        *    "chkOld":true
        *  }
        *
        * @apiSuccessExample Success-Response:
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
        Response ChangePassword(string vendorId, string password, string oldPassword, bool chkOld);

        /**
        * @api {post} v1/UpdateVendor Update Vendor
        * @apiName UpdateVendor
        * @apiGroup Vendor
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {Vendor} vendor Vendor.
        * 
        * @apiParamExample {json} Param-Example:
        *  {
        *    "vendor": "Vendor details to update" 
        *  }
        *
        * @apiSuccessExample Success-Response:
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

        /**
        * @api {post} v1/UpdateVendorLocation Update Vendor Location
        * @apiName UpdateVendorLocation
        * @apiGroup Vendor
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {string} vendorId Vendor Id.
        * 
        * @apiParam {AddressInfo} addressInfo Address Info.
        *
        * @apiParamExample {json} Param-Example:
        *  {
             *  "vendorId":"F3E6D9CBF8EF6A4289E1FC3509076D54",
             *  "addressInfo": 
             *    {
             *     "Address": "plot no 101, vivekanandaNagar",
             *     "AddressType":"Home",
             *     "City": "Hyderabad",
             *     "Country": "India",
             *     "Lattitude": "10",
             *     "Locality": "kphb",
             *     "Longitude": "200",
             *     "Pincode": "500081",
             *     "State": "Telangana"
             *    }
        *  }
        *
        * @apiSuccessExample Success-Response:
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
        Response UpdateVendorLocation(string vendorId, AddressInfo addressInfo);

        #region Notifications
        /**
        * @api {post} v1/StoreVendorGCMUser Store Vendor GCM User
        * @apiName StoreVendorGCMUser
        * @apiGroup Vendor
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {string} vendorId Vendor Id. 
        * 
        * @apiParam {string} name GCM User Name . 
        * 
        * @apiParam {string} gcmRedId GCMREDID. 
        * 
        * @apiParamExample {json} Param-Example:
        *  {
        *    "vendorId":"Vendor Id",
             "name": "srikanth",
             "gcmRedId": "gcm reg Id
        *  }
        *
        * @apiSuccessExample Success-Response:
        {
         "Data": "0C12E1E9EF74CD499EAAEDB8FFDCE74A",
         "Error": false,
         "Message": "Success",
         "Status": 200
       }
        * @apiError USER_NAME_EXISTS User Name Exists
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "User Name Exists",
         "Status": 400
       }
        */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response StoreVendorGCMUser(string name, string vendorId, string gcmRedId);
        #endregion

        #region Social Media

        /**
         * @api {post} v1/AddPost Add Social Media Post
         * @apiName AddPost
         * @apiGroup Vendor
         *
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} User_Id User Id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "User_Id": "Logged in User ID",
         *    "Content-Type": "application/json"
         *  }
         *    
         * @apiParam {SocialMediaPost} Social Media Post.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *     "post": 
         *       {
         *         "Message":"Post Message",
         *         "VendorId":"Vendor id"
         *         "ImageUrls": [
         *           {
         *             "F4878463A2FF5043BF3763F8AA913DE1",
         *             "F4878463A2FF5043BF3763F8AA913DE1"
         *           }
         *         ]
         *       }
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError Invalid Token Code
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Token Code",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddPost(SocialMediaPost post);

        /**
         * @api {post} v1/GetVendorPosts Gets Vendor Posts
         * @apiName GetVendorPosts
         * @apiGroup Vendor
         *
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} Content-Type application/json
         * @apiHeader {string} User_Id User Id
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "Content-Type": "application/json"
         *    "User_Id": "Logged in User ID",
         *  }
         *  
         * @apiParam {String} vendorId Vendor Id.     
         * @apiParam {int} pageNumber Page Number.
         *
         * @apiParam {int} recordsPerPage Records Per Page.
         * 
         * @apiParamExample {json} Param-Example:
         *  {
         *    "vendorId": "Vendor Id " 
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                       "__type": "SocialMediaPost:#Tasko.Model",
                      "Id": "Id",
                      "Message":"Post Message",
                      "VendorId":"Vendor id",
                      "Views":"10",
                      "Likes":"1",,
                      "VendorName":"Test",
                      "PostedDate":"date",
                      "VendorImageURL":"Vendor Image URL",
                      "ImageUrls": [
                        {
                          "F4878463A2FF5043BF3763F8AA913DE1",
                          "F4878463A2FF5043BF3763F8AA913DE1"
                        }
                      ]
                    }
                 ]
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError NO_POSTS_AVAILABLE No posts available.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "No services available",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorPosts(string vendorId,int pageNumber, int recordsPerPage);

        /**
         * @api {post} v1/UpdatePost Update Social Media Post
         * @apiName UpdatePost
         * @apiGroup Vendor
         *
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} User_Id User Id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "User_Id": "Logged in User ID",
         *    "Content-Type": "application/json"
         *  }
         *    
         * @apiParam {SocialMediaPost} Social Media Post.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *     "post": 
         *       {
         *         "Id": "Id",
         *         "Message":"Post Message",
         *         "VendorId":"Vendor id"
         *         "ImageUrls": [
         *           {
         *             "F4878463A2FF5043BF3763F8AA913DE1",
         *             "F4878463A2FF5043BF3763F8AA913DE1"
         *           }
         *         ]
         *       }
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError Invalid Token Code
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Token Code",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdatePost(SocialMediaPost post);

        /**
         * @api {post} v1/DeletePost Delete Social Media Post
         * @apiName DeletePost
         * @apiGroup Vendor
         *
         * @apiHeader {string} Token_Code Token Code
         * @apiHeader {string} User_Id User Id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Unique Token code that is generated after login" ,
         *    "User_Id": "Logged in User ID",
         *    "Content-Type": "application/json"
         *  }
         *    
         * @apiParam {string} PostId.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *     "postId": "Post Id"
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError Invalid Token Code
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Token Code",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeletePost(string postId);
        #endregion
    }
}
