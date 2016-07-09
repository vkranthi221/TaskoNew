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

        /**
         * @api {post} a1/GetServicesForVendor Get Services For Vendor
         * @apiName GetServicesForVendor
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
         *  @apiParam {string} vendorId Vendor Id.
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "vendorId":"AFB2B50F2164804C8E6D26A6C4A32982"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
           "Data": [
                    {
                      "__type": "ServicesForVendor:#Tasko.Model",
                      "IsActive": false,
                      "ServiceId": "F4878463A2FF5043BF3763F8AA913DE1",
                      "ServiceName": "Microwave Service"
                    }
                  ],
                  "Error": false,
                  "Message": "Success",
                  "Status": 200
         }
         * @apiError SERVICES_NOT_FOUND Services not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Services not found",
            "Status": 400
          }        
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetServicesForVendor(string vendorId);
        /**
         * @api {post} a1/UpdateServicesForVendor Update Services For Vendor
         * @apiName UpdateServicesForVendor
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
         * @apiParam {string} vendorId VendorId
         * @apiParam {ServicesForVendor} services List of services for vendor.
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "vendorId": "AFB2B50F2164804C8E6D26A6C4A32982",
         *   "Data": [
                    {
                      "__type": "ServicesForVendor:#Tasko.Model",
                      "ServiceId": "F4878463A2FF5043BF3763F8AA913DE1",
                      "ServiceName": "Microwave Service"
                    }
                  ]
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
        Response UpdateServicesForVendor(string vendorId, List<ServicesForVendor> services);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorOverview(string vendorId);
        #endregion

        #region Customers
        #endregion

        #region Orders
        /**
        * @api {post} a1/GetOrders Get Orders
        * @apiName GetOrders
        * @apiGroup Admin
        *
        * @apiHeader {string} Token_Code Token Code
        * @apiHeader {string} Content-Type application/json
        * @apiHeader {string} User_Id User Id
        * 
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Unique Token code that is generated after login" ,
        *    "Content-Type": "application/json"
        *    "User_Id": "Logged in User ID",
        *  }
        *  
        * @apiParam {int} orderStatusId Order Status Id.
        *  
        * @apiParamExample {json} Param-Example:
        *  {
        *    "orderStatusId": "Status of the order",
        *  }
        *  
        * @apiSuccessExample Success-Response:
        {
         {
           "Data": [
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": null,
                      "CustomerName": "Shivaji",
                      "OrderId": "TASKO1000",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-07-07 14:12:55",
                      "ServiceId": null,
                      "ServiceName": "Electrician",
                      "VendorName": "chandra"
                    },
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": null,
                      "CustomerName": "Shivaji123",
                      "OrderId": "TASKO1001",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-07-07 14:12:55",
                      "ServiceId": null,
                      "ServiceName": "Microwave Service",
                      "VendorName": "srikanth test"
                    }
                  ]
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
       }
        * @apiError NO_ORDERS No orders
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "No orders",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetOrders(int orderStatusId);

        /**
         * @api {post} c1/GetOrderDetails Get Order details
         * @apiName GetOrderDetails
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
         * @apiParam {String} orderId Order Id.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "OrderId": "Order Id that you would like to get the details" 
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
            "__type": "Order:#Tasko.Model",
            "Comments": "",
            "CustomerId": "692BD435A5173E42916438F889F5DA08",
            "CustomerName": "Shivaji",
            "DestinationAddress": {
              "Address": "plot no 404, BaghyaNagar",
              "AddressId": "8397A91B6E997F438A9D4D9D49D3E12A",
              "City": "Hyderabad",
              "Country": "India",
              "Lattitude": "40",
              "Locality": "HMT HILLS",
              "Longitude": "600",
              "Pincode": "500072",
              "State": "Telangana"
            },
            "Location": "kphb",
            "OrderId": "TASKO1000",
            "OrderStatus": "Requested",
            "OrderStatusId": 1,
            "RequestedDate": "2016-06-29 22:49:47",
            "ServiceId": "9661D3C7E345B747BBE62DEA76F00B82",
            "ServiceName": "Electrician",
            "SourceAddress": {
              "Address": "plot no 101, vivekanandaNagar",
              "AddressId": "36F6A0E2C85F7D46AF68C4EB73148B2A",
              "City": "Hyderabad",
              "Country": "India",
              "Lattitude": "10",
              "Locality": "kphb",
              "Longitude": "200",
              "Pincode": "500081",
              "State": "Telangana"
            },
            "VendorId": "C3A4A364DA1DE542BA70FBAD2435D571",
            "VendorName": "chandra",
            "VendorServiceId": "CD2CA27D52CE5E4D8E897D53CC4379CB"
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ORDER_NOT_FOUND The Order id was not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Order not found",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetOrderDetails(string orderId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddComplaint(Complaint complaint);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetComplaints(int complaintStatus);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateComplaint(Complaint complaint);
        #endregion

        #region General
        #endregion
    }
}
