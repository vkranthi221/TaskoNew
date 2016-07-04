using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tasko.Model;

namespace Tasko.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        #region Services

        /**
         * @api {post} a1/AddService Add Service
         * @apiName AddService
         * @apiGroup Admin
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
         * @apiParam {Service} service Service Info.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "service":
         *   {   
         *     "Name": "AC Service",
         *     "ParentServiceId": "",
         *     "ImageUrl": "http://api.tasko.in/serviceimages/ac_services.png",
         *     "Status": "0"
         *   }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
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
        Response AddService(Service service);

        /**
         * @api {post} a1/UpdateService Update Service
         * @apiName UpdateService
         * @apiGroup Admin
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
         * @apiParam {Service} service Service Info.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "service":
         *   {   
         *     "Id":"054CFD4A388C27046918399822EAA7458",
         *     "Name": "AC Service",
         *     "ParentServiceId": "",
         *     "ImageUrl": "http://api.tasko.in/serviceimages/ac_services.png",
         *     "Status": "1"
         *   }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
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
        Response UpdateService(Service service);

        /**
         * @api {post} a1/DisableService Disable Service
         * @apiName DisableService
         * @apiGroup Admin
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
         * @apiParam {string} serviceId Service Id.
         * @apiParam {short} status status {0 - Active; 1 - Disable}.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "serviceId":"54CFD4A388C27046918399822EAA7458",
         *   "status":"1"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
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
        Response DisableService(string serviceId, short status);

        /**
         * @api {post} a1/DeleteService Delete Service
         * @apiName DeleteService
         * @apiGroup Admin
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
         * @apiParam {string} serviceId Service Id.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "serviceId":"54CFD4A388C27046918399822EAA7458"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Invalid token code",
            "Status": 400
          }
         * @apiError SERVICE_IN_USE Unable to delete the Service as it is in Use.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Unable to delete the Service as it is in Use",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeleteService(string serviceId);

        /**
         * @api {post} a1/GetAllServices Get All Services
         * @apiName GetAllServices
         * @apiGroup Admin
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
         * @apiSuccessExample Success-Response:
         {
           "Data": [
             {
              "__type": "ServiceDetail:#Tasko.Model",
              "Service": {
                "Id": "5EC9A583EFF0534897DD55B3653627C9",
                "ImageURL": "http://api.tasko.in/serviceimages/bikeService.png",
                "Name": "Bike Service",
                "ParentServiceId": null,
                "Status": 0
              },
              "TotalOrders": 0,
              "TotalVendors": 0
            },
            {
              "__type": "ServiceDetail:#Tasko.Model",
              "Service": {
                "Id": "6786E5D449D6B74396E8ADAEA1C17E37",
                "ImageURL": "http://api.tasko.in/serviceimages/microwave.png",
                "Name": "Microwave Service",
                "ParentServiceId": null,
                "Status": 0
              },
              "TotalOrders": 10,
              "TotalVendors": 1
            },
            {
              "__type": "ServiceDetail:#Tasko.Model",
              "Service": {
                "Id": "688B6A30A7895D40B3A64A0A03AE28D8",
                "ImageURL": "http://api.tasko.in/serviceimages/carpenter.png",
                "Name": "Carpentry",
                "ParentServiceId": null,
                "Status": 0
              },
              "TotalOrders": 0,
              "TotalVendors": 1
            }
              ],
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
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
        Response GetAllServices();

        /**
         * @api {post} a1/GetOrdersByService Get Orders By Service
         * @apiName GetOrdersByService
         * @apiGroup Admin
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
         * @apiParam {string} serviceId Service Id.
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "serviceId":"6786E5D449D6B74396E8ADAEA1C17E37"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
            {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji123",
              "OrderId": "TASKO1001",
              "OrderStatus": "Requested",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": "6786E5D449D6B74396E8ADAEA1C17E37",
              "ServiceName": "Microwave Service",
              "VendorName": "Srikanth"
            },
            {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji123",
              "OrderId": "TASKO1002",
              "OrderStatus": "Requested",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": "6786E5D449D6B74396E8ADAEA1C17E37",
              "ServiceName": "Microwave Service",
              "VendorName": "Srikanth"
            }
              ],
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Invalid token code",
            "Status": 400
          } 
         * @apiError ORDERS_NOT_FOUND Order's not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Order's not found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetOrdersByService(string serviceId);

        /**
         * @api {post} a1/GetVendorsByService Get Vendors By Service
         * @apiName GetVendorsByService
         * @apiGroup Admin
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
         * @apiParam {string} serviceId Service Id.
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "serviceId":"6786E5D449D6B74396E8ADAEA1C17E37"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
            "Data": [
            {
                "__type": "VendorSummary:#Tasko.Model",
                "EmailAddress": "sree@gmail.com",
                "Id": "6D76BCF5246BB44E8DD327C22780C6B0",
                "IsVendorLive": true,
                "MobileNumber": "1234567890",
                "Name": "Srikanth",
                "UserName": "sree123"
            }
            ],
            "Error": false,
            "Message": "Success",
            "Status": 200
        }
         * @apiError INVALID_TOKEN_CODE Invalid token code.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Invalid token code",
            "Status": 400
          }  
         * @apiError VENDORS_NOT_FOUND Vendor's not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Vendor's not found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorsByService(string serviceId);
        #endregion

        #region Vendors
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddVendor(Vendor vendor);
        #endregion

        #region Customers
        #endregion

        #region General
        #endregion
    }
}
