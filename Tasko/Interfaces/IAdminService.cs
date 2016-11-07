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
         *     "ImageURL": "http://api.tasko.in/serviceimages/ac_services.png",
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
         *     "ImageURL": "http://api.tasko.in/serviceimages/ac_services.png",
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
                "VendorId": "6D76BCF5246BB44E8DD327C22780C6B0",
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

        /**
         * @api {post} a1/GetServiceOverview Get Service Overview
         * @apiName GetServiceOverview
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
              "Data": {
                "__type": "ServiceOverview:#Tasko.Model",
                "BiggestPayment": 600,
                "MonthlyPayments": 3750,
                "ServiceId": "43FFEE168D9E3C4B9FC28B263AA403F7",
                "ServiceName": "Microwave Service",
                "TotalPayments": 3750,
                "WeeklyPayments": 3750
              },
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
         * @apiError NO_SERVICES_EXIST No Payments found for the selected service.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "No Payments found for the selected service",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetServiceOverview(string serviceId);

        #endregion

        #region Vendors
        /**
         * @api {post} a1/AddVendor Add Vendor
         * @apiName AddVendor
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
         *  @apiParam {string} vendor Vendor .
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "vendor": {
                        "AddressDetails": {
                          "Address": "plot no 404, BaghyaNagar",
                          "AddressId": null,
                          "AddressType":"Home",
                          "City": "Hyderabad",
                          "Country": "India",
                          "Lattitude": "40",
                          "Locality": "HMT HILLS",
                          "Longitude": "600",
                          "Pincode": "500072",
                          "State": "Hyderabad"
                        },
                        "BaseRate": 100,
                        "DateOfBirth": "7/7/2016 2:12:55 PM",
                        "EmailAddress": "sree@gmail.com",
                        "Gender": 0,
                        "IsVendorLive": false,
                        "IsVendorVerified": true,
                        "MobileNumber": "9985466195",
                        "Name": "srikanth3",
                        "Experience":"1",
                        "FacebookUrl":"http://facebook.com/xyz",
                        "VendorAlsoKnownAs":"srikanth",
                        "NoOfEmployees": 10,
                        "Password": "123456",
                        "Photo": "test photo",
                        "UserName": "srikanth3",
                        "VendorDetails": {
                          "MonthlyCharge": "1000",
                          "IsBlocked": "false",
                          "IsPowerSeller": "true",
                          "AreOrdersBlocked": "false"
                        },
                        "VendorServices": [
                                    {
                                      "ServiceId": "226AC0D8D240344294A5D1FC4DC96273"
                                    },
                                    {
                                     "ServiceId": "B42A577C337BEB4988E8E02200F28965"  
                                    }
                                 ]
                      }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
           "Data":"D519EDD9B0713B4699E75C0D24F54370" ,
                  "Error": false,
                  "Message": "Success",
                  "Status": 200
         }
         * @apiError ADD_VENDOR_FAILED Error adding vendor.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Error adding vendor.",
            "Status": 400
          }        
         */
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
                      "ServiceId": "F4878463A2FF5043BF3763F8AA913DE1",
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

        /**
         * @api {post} a1/GetVendorOverview Get Vendor overview
         * @apiName GetVendorOverview
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
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "vendorId": "AFB2B50F2164804C8E6D26A6C4A32982",
         * }
         *
         * @apiSuccessExample Success-Response:
         {
            "Data": {
                        "__type": "VendorOverview:#Tasko.Model",
                        "AverageMonthlyAmount": 3750,
                        "HighestOrderAmount": 600,
                        "Name": "Srikanth",
                        "OrdersThisWeek": 10,
                        "OrdersToday": 10,
                        "TotalOrderAmount": 3750,
                        "TotalOrders": 10,
                        "WeeklyOrderAmount": 3750
                      },
            "Error": false,
            "Message": "Success",
            "Status": 200
         }
         * @apiError VENDOR_NOT_FOUND Vendor not found.
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
        Response GetVendorOverview(string vendorId);

        /**
         * @api {post} a1/GetVendorsByStatus Get Vendors by Status
         * @apiName GetVendorsByStatus
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
         * @apiParam {string} vendorStatus Vendor Status {0- All, 1-Online, 2-Offline   }
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "vendorStatus": "0"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
            "Data": [
                        {
                          "__type": "VendorSummary:#Tasko.Model",
                          "EmailAddress": "mchandu123@gmail.com",
                          "VendorId": "40C58B1908D4CE439FA05FF0B138EA8A",
                          "IsVendorLive": true,
                          "MobileNumber": "9985466195",
                          "Name": "chandra",
                          "UserName": "chandra"
                        },
                        {
                          "__type": "VendorSummary:#Tasko.Model",
                          "EmailAddress": "sree@gmail.com",
                          "VendorId": "B6C163EABE8C0A4B8F4BAFA9CAA7DDB1",
                          "IsVendorLive": true,
                          "MobileNumber": "1234567890",
                          "Name": "Srikanth",
                          "UserName": "srikanth"
                        }
                  ],
            "Error": false,
            "Message": "Success",
            "Status": 200
         }
         * @apiError NO_VENDORS Vendors not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Vendors not found",
            "Status": 400
          }        
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetVendorsByStatus(int vendorStatus);

        /**
        * @api {post} a1/UpdateVendorDetails Update Vendor Details
        * @apiName UpdateVendorDetails
        * @apiGroup Admin
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
        *    "vendor": {
        *               "Id": "FC73EC7242E28142ACCAFDF4703F0EBF",
        *               "MobileNumber": "9849345086",
        *               "Name": "srikanth",
        *               "EmailAddress":"srikanth@tasko.com",
        *               "Photo": "",
        *               "DateOfBirth":"2016-07-07 14:12:55",
        *               "AreOrdersBlocked":"0",
        *               "IsBlocked":"0",
        *               "IsPowerSeller":"1",
        *               "MonthlyCharge":"300",
        *               "FacebookUrl":"http://facebook.com/xyz",
        *               
        *              } 
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
        Response UpdateVendorDetails(Vendor vendor);
        #endregion

        #region Customers
        /**
        * @api {post} a1/GetAllCustomersByStatus Get All Customers By Status
        * @apiDescription Get the customers details based on the given status. The possible statuses are 0 - All, 1- Online, 2- Offline, 3- Blocked
        * @apiName GetAllCustomersByStatus
        * @apiGroup Admin
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
        * @apiParam {customerStatus} customerStatus 0 - All, 1- Online, 2- Offline, 3- Blocked.
        * 
        * @apiParamExample {json} Param-Example:
        *  {
            "customerStatus": 0
           }
        *
        * @apiSuccessExample Success-Response:
        {
          "Data": [
            {
              "__type": "Customer:#Tasko.Model",
              "EmailAddress": "shivaji@gmail.com",
              "Id": "3B456AD997CC9046B4B8F45244B50A57",
              "MobileNumber": "1234567890",
              "Name": "Shivaji"
            },
            {
              "__type": "Customer:#Tasko.Model",
              "EmailAddress": "shivaji456@gmail.com",
              "Id": "41F53C6CE848E843B75FA43A274FD18C",
              "MobileNumber": "9876543210",
              "Name": "Shivaji456"
            },
          ],
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
        Response GetAllCustomersByStatus(int customerStatus);

        /**
        * @api {post} a1/GetCustomerRatingsForOrders Get Customer Ratings for Orders
        * @apiName GetCustomerRatingsForOrders
        * @apiGroup Admin
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
        * @apiParam {string} customerId Customer Id.
        * @apiParam {integer} noOfRecords No of records to retrieve
        * 
        * @apiParamExample {json} Param-Example:
        *  {
            "customerId": "6786E5D449D6B74396E8ADAEA1C17E37",
            "noOfRecords":2
           }
        *
        * @apiSuccessExample Success-Response:
        {
            "Data": [
                {
                    "__type": "CustomerRating:#Tasko.Model",
                    "Comments": null,
                    "Courtesy": 3,
                    "CustomerId": null,
                    "CustomerName": "Shivaji",
                    "Id": null,
                    "OrderId": "TASKO1000",
                    "OverAllRating": 2,
                    "Price": 1,
                    "Punctuality": 2,
                    "ReviewDate": null,
                    "ServiceQuality": 2,
                    "VendorId": null,
                    "VendorName": "chandra"
                }
            ],
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
        Response GetCustomerRatingsForOrders(string customerId, int noOfRecords);

        /**
         * @api {post} a1/GetCustomerOverview Get Customer Overview
         * @apiName GetCustomerOverview
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
         * @apiParam {string} customerId Customer Id.
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *   "customerId":"6786E5D449D6B74396E8ADAEA1C17E37"
         * }
         *
         * @apiSuccessExample Success-Response:
            {
              "Data": {
                "__type": "CustomerOverview:#Tasko.Model",
                "BiggestPayments": 600,
                "MonthlyPayments": 3750,
                "Name": "Shivaji123",
                "TodayOrders": 0,
                "TotalOrders": 10,
                "TotalPayments": 3750,
                "WeeklyOrders": 10,
                "WeeklyPayments": 3750
              },
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
         * @apiError CUSTOMER_NOT_FOUND Customer's not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Customer's not found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerOverview(string customerId);
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
              "AddressType":"Home",   
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
              "AddressType":"Home",
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

        #endregion

        #region Dashboard

        /**
         * @api {post} a1/GetDashboardRecentOrdersByStatus Get Dashboard Recent Orders
         * @apiName GetDashboardRecentOrdersByStatus
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
         * @apiParam {string} orderStatusId Order Status Id {If Order status Id is 6 it will return Completed orders else it will return the pending orders}
         *
         * @apiParamExample {json} Param-Example 1:
         * { 
         *   "orderStatusId":6
         * }
         *
         * @apiSuccessExample Success-Response 1:
         {
          "Data": [
            {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji123",
              "OrderId": "TASKO1007",
              "OrderStatus": "Completed",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": null,
              "ServiceName": "Microwave Service",
              "VendorName": "Srikanth"
            },
            {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji",
              "OrderId": "TASKO1000",
              "OrderStatus": "Completed",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": null,
              "ServiceName": "Electrician",
              "VendorName": "chandra"
            }
          ],
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiParamExample {json} Param-Example 2:
         * { 
         *   "orderStatusId":1
         * }
         *
         * @apiSuccessExample Success-Response 2:
         {
          "Data": [
             {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji123",
              "OrderId": "TASKO1010",
              "OrderStatus": "Requested",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": null,
              "ServiceName": "Microwave Service",
              "VendorName": "Srikanth"
            },
            {
              "__type": "OrderSummary:#Tasko.Model",
              "Comments": null,
              "CustomerName": "Shivaji123",
              "OrderId": "TASKO1009",
              "OrderStatus": "Accepted",
              "RequestedDate": "2016-07-03 17:43:19",
              "ServiceId": null,
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
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetDashboardRecentOrdersByStatus(int orderStatusId);

        /**
         * @api {post} a1/GetDashboardMeters Get Dashboard Meter Values
         * @apiName GetDashboardMeters
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
            "Data": {
            "__type": "DashboardMeter:#Tasko.Model",
            "TotalCustomerReviews": 1,
            "TotalCustomers": 3,
            "TotalOrders": 11,
            "TotalPayments": 0,
            "TotalServices": 15,
            "TotalUsers": 0,
            "TotalVendorReviews": 11,
            "TotalVendors": 2
            },
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
        Response GetDashboardMeters();

        /**
         * @api {post} a1/GetDashboardRecentActivities Get Dashboard Recent Activities
         * @apiName GetDashboardRecentActivities
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
                    "__type": "RecentActivities:#Tasko.Model",
                    "ActivityId": "5FD87BC4BF91424DB08F4298F9580641",
                    "ActivityType": "ORDER",
                    "Comment": "TASKO1010 Order  is completed.",
                    "CustomerId": null,
                    "OrderId": "TASKO1010",
                    "TimeSince": "2016-07-09 17:55:14",
                    "VendorId": null
                },
                {
                    "__type": "RecentActivities:#Tasko.Model",
                    "ActivityId": "08020C7D838046409B42714FEB382761",
                    "ActivityType": "ORDER",
                    "Comment": "New Order TASKO1012 has been placed.",
                    "CustomerId": null,
                    "OrderId": "TASKO1012",
                    "TimeSince": "2016-07-09 17:44:08",
                    "VendorId": null
                },
                {
                    "__type": "RecentActivities:#Tasko.Model",
                    "ActivityId": "272910E262B17D45B16A11F70C5CD3AA",
                    "ActivityType": "CUSTOMER",
                    "Comment": "Customer Shaker registered.",
                    "CustomerId": "13D97F236A0E0547B22A7734B63488F8",
                    "OrderId": null,
                    "TimeSince": "2016-07-09 17:16:29",
                    "VendorId": null
                },
                {
                    "__type": "RecentActivities:#Tasko.Model",
                    "ActivityId": "9D234754C3B4754BBD8B1ECCCB510DCB",
                    "ActivityType": "VENDOR",
                    "Comment": "Vendor Chandra registered",
                    "CustomerId": null,
                    "OrderId": null,
                    "TimeSince": "2016-07-09 16:59:51",
                    "VendorId": "13D97F236A0E0547B22A7734B63488F8"
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
         * @apiError NO_RECENT_ACTIVITIES Recent Activities are not found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "Recent Activities are not found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetDashboardRecentActivities();

        #endregion

        #region Payments

        /**
         * @api {post} a1/AddPayment Add Payment
         * @apiName AddPayment
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
         * @apiParam {Payment} payment Payment details.
         * 
         *
         * @apiParamExample {json} Param-Example:
        {
            "payment": {
            "VendorId": "F9756A47F455F64DAD4B24E49A257188",
            "DueDate": "23/6/2016",
            "PaidDate": "10/7/2016",
            "Amount": 300,
            "Status": "Pending",
            "Description": "OutStanding Charge",
            "PayForMonth": "June 2016"
            }
        }
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
        Response AddPayment(Payment payment);

        /**
         * @api {post} a1/UpdatePayment Update Payment
         * @apiName UpdatePayment
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
         * @apiParam {Payment} payment Payment details.
         * 
         *
         * @apiParamExample {json} Param-Example:
        {
            "payment": {
            "PaymentId": "TASKOPAY1002"
            "VendorId": "F9756A47F455F64DAD4B24E49A257188",
            "DueDate": "23/6/2016",
            "PaidDate": "10/7/2016",
            "Amount": 400,
            "Status": "Completed",
            "Description": "OutStanding Charge",
            "PayForMonth": "June 2016"
            }
        }
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
        Response UpdatePayment(Payment payment);

        /**
         * @api {post} a1/GetAllPaymentsByStatus Get All Payments ByStatus
         * @apiName GetAllPaymentsByStatus
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
         * @apiParam {String} status Status {Pending, Completed, ALL}.
         * 
         *
         * @apiParamExample {json} Param-Example1:
         * { 
         *     "status": "ALL"
         * }
         * @apiSuccessExample Success-Response:
            {
            "Data": [
            {
                "__type": "Payment:#Tasko.Model",
                "Amount": 500,
                "Description": "Monthly Charge",
                "DueDate": "2016-06-23",
                "PaidDate": "2016-07-07",
                "PayForMonth": "May 2016",
                "PaymentId": "TASKOPAY1000",
                "Status": "Completed",
                "VendorId": "682D49C154DB16499DA55BF1D50930FF",
                "VendorName": "Srikanth"
            },
            {
                "__type": "Payment:#Tasko.Model",
                "Amount": 300,
                "Description": "OutStanding Charge",
                "DueDate": "2016-06-23",
                "PaidDate": "2016-07-10",
                "PayForMonth": "June 2016",
                "PaymentId": "TASKOPAY1001",
                "Status": "Completed",
                "VendorId": "682D49C154DB16499DA55BF1D50930FF",
                "VendorName": "Srikanth"
            },
            {
                "__type": "Payment:#Tasko.Model",
                "Amount": 400,
                "Description": "Partial Payment made",
                "DueDate": "2016-06-23",
                "PaidDate": "2016-07-10",
                "PayForMonth": "June 2016",
                "PaymentId": "TASKOPAY1002",
                "Status": "Pending",
                "VendorId": "682D49C154DB16499DA55BF1D50930FF",
                "VendorName": "chandra"
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
         * @apiError NO_PAYMENTS_FOUND No Payments found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "No Payments found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetAllPaymentsByStatus(string status);

        /**
         * @api {post} a1/GetPayment Get Payment
         * @apiName GetPayment
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
         * @apiParam {String} paymentId PaymentId.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *     "paymentId": "TASKOPAY1000"
         * }
         * @apiSuccessExample Success-Response:
           {
            "Data": {
            "__type": "Payment:#Tasko.Model",
            "Amount": 500,
            "Description": "Test",
            "DueDate": "1986-01-14",
            "PaidDate": "1999-12-22",
            "PayForMonth": "May 2016",
            "PaymentId": "TASKOPAY1000",
            "Status": "Pending",
            "VendorId": "682D49C154DB16499DA55BF1D50930FF",
            "VendorName": "Srikanth"
            },
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
         * @apiError NO_PAYMENT_FOUND No Payments found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "No Paymnet found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetPayment(string paymentId);

        /**
         * @api {post} a1/GetPaymentInvoice Get Payment Invoice
         * @apiName GetPaymentInvoice
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
         * @apiParam {String} paymentId PaymentId.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * { 
         *     "paymentId": "TASKOPAY1000"
         * }
         * @apiSuccessExample Success-Response:
            {
              "Data": {
                "__type": "VendorPaymentInvoice:#Tasko.Model",
                "Payment": {
                  "Amount": 500,
                  "Description": "Test",
                  "DueDate": "1986-01-14",
                  "PaidDate": "1999-12-22",
                  "PayForMonth": "May 2016",
                  "PaymentId": "TASKOPAY1000",
                  "Status": "Pending",
                  "VendorId": "682D49C154DB16499DA55BF1D50930FF",
                  "VendorName": "Srikanth"
                },
                "VendorAddress": {
                  "Address": "plot no 404, BaghyaNagar",
                  "AddressId": "F3378ADDB47E164DB5A585CCC36FC5BA",
                  "AddressType":"Home",
                  "City": "Hyderabad",
                  "Country": "India",
                  "Lattitude": "40",
                  "Locality": "HMT HILLS",
                  "Longitude": "600",
                  "Pincode": "500072",
                  "State": "Telangana"
                }
              },
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
         * @apiError NO_PAYMENT_FOUND No Payments found.
         *
         * @apiErrorExample Error-Response:
         {
            "Data": null,
            "Error": true,
            "Message": "No Paymnet found",
            "Status": 400
          }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetPaymentInvoice(string paymentId);

        /**
         * @api {post} a1/GetAllVendorsSummary Get All Vendors Summary
         * @apiName GetAllVendorsSummary
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
                "__type": "VendorSummary:#Tasko.Model",
                "DueDate": "2016-08-13",
                "EmailAddress": "mchandu123@gmail.com",
                "IsVendorLive": true,
                "MobileNumber": "9985466195",
                "MonthlyCharge": 300,
                "Name": "chandra",
                "UniqueId": 1,
                "UserName": "chandra",
                "VendorId": "365D5778496AF745975DA6692AC64661"
             },
             {
                "__type": "VendorSummary:#Tasko.Model",
                "DueDate": "2016-08-13",
                "EmailAddress": "sree@gmail.com",
                "IsVendorLive": true,
                "MobileNumber": "1234567890",
                "MonthlyCharge": 300,
                "Name": "Srikanth",
                "UniqueId": 2,
                "UserName": "srikanth",
                "VendorId": "F1EFDAF4136F2847B99F259519C1D729"
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
        Response GetAllVendorsSummary();
        #endregion

        #region Users

        /**
         * @api {post} a1/auth Get Auth Code
         * @apiName auth
         * @apiGroup Admin
         *
         * @apiHeader {string} X-APIKey API key
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "X-APIKey": "API Key" ,
         *    "Content-Type": "application/json"
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
         * @api {post} a1/Login Login 
         * @apiName Login
         * @apiGroup Admin
         *
         * @apiHeader {string} Auth_Code Authntication code
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Auth_Code": "Authetication code that is generated using GetAuthCode API" ,
         *    "Content-Type": "application/json"
         *  }
         *   
         * @apiParam {String} userName user name of customer.
         * 
         * @apiParam {String} password password.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *   "userName": "kranthi ",
         *   "password":"kranthi"
         *   }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
            "__type": "LoginInfo:#Tasko.Model",
            "TokenId": "B282108B71974748876F5BAC53A93F",
            "UserId": "E51DF58EF04A1947BE85BB5B04AC94A9"
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_CREDENTIALS Invalid credentials.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": {
            "__type": "LoginInfo:#Tasko.Model",
            "TokenId": "7BC33345FA08BF488335AC75E3DBA6",
            "UserId": null
          },
          "Error": false,
          "Message": "Invalid Credentials",
          "Status": 200
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response Login(string userName, string password);

        /**
         * @api {post} a1/AddUser Add Admin User
         * @apiName AddUser
         * @apiGroup Admin
         *
         * @apiHeader {string} Token_Code Authntication code
         * @apiHeader {string} User_Id user id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Token code got from login API" ,
         *    "User_Id": "User id" ,
         *    "Content-Type": "application/json"
         *  }
         *   
         * @apiParam {String} userName user name of customer.
         * 
         * @apiParam {String} password password.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  user:
           {
            "__type": "User:#Tasko.Model",
            "EmailId": "testuser@testuser.com",
            "Id": "E51DF58EF04A1947BE85BB5B04AC94A9",
            "IsActive": true,
            "IsAdmin": true,
            "JoinedDate": "2016-07-13 15:13:01",
            "MobileNumber": "9898987876",
            "Name": "testuser",
            "PassWord": "testuser",
            "UserName": "testuser"
          }
          }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
            "__type": "LoginInfo:#Tasko.Model",
            "TokenId": "B282108B71974748876F5BAC53A93F",
            "UserId": "E51DF58EF04A1947BE85BB5B04AC94A9"
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_CREDENTIALS Invalid credentials.
         *
         * @apiErrorExample Error-Response:
         {
              "Data": "",
              "Error": true,
              "Message": "User Name Exists",
              "Status": 400
         }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddUser(User user);

        /**
         * @api {post} a1/GetAllUsers Get All Users
         * @apiName GetAllusers
         * @apiGroup Admin
         *
         * @apiHeader {string} Token_Code Authntication code
         * @apiHeader {string} User_Id user id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Token code got from login API" ,
         *    "User_Id": "User id" ,
         *    "Content-Type": "application/json"
         *  }
         *   
         * @apiSuccessExample Success-Response:
         {
          "Data": [
            {
              "__type": "User:#Tasko.Model",
              "EmailId": "test@test.com",
              "Id": "236E155155DB7A489E8101290DEDECE1",
              "IsActive": true,
              "IsAdmin": true,
              "JoinedDate": "2016-07-13 20:38:06",
              "MobileNumber": "9898987878",
              "Name": "testuser",
              "PassWord": "testuser",
              "UserName": null
            },
            {
              "__type": "User:#Tasko.Model",
              "EmailId": "testuse1r@testuser.com",
              "Id": "EFB93DAEFECC0D409E2AC5FEB4441615",
              "IsActive": true,
              "IsAdmin": true,
              "JoinedDate": "2016-07-13 20:32:29",
              "MobileNumber": "9898987876",
              "Name": "testuser11",
              "PassWord": "testuser11",
              "UserName": null
            }
          ],
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_CREDENTIALS Invalid credentials.
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
        Response GetAllUsers();

        /**
         * @api {post} a1/GetUserDetails Get User Details
         * @apiName GetUserDetails
         * @apiGroup Admin
         *
         * @apiHeader {string} Token_Code Authntication code
         * @apiHeader {string} User_Id user id
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Token_Code": "Token code got from login API" ,
         *    "User_Id": "User id" ,
         *    "Content-Type": "application/json"
         *  }
         *   
         * @apiParam {String} userId user id of admin user.
         * 
         *
         * @apiParamExample {json} Param-Example:
         * 
           {
             "userId": "E51DF58EF04A1947BE85BB5B04AC94A9"
           }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
            "__type": "User:#Tasko.Model",
            "EmailId": "kranthi@kr.com",
            "Id": "E51DF58EF04A1947BE85BB5B04AC94A9",
            "IsActive": true,
            "IsAdmin": true,
            "JoinedDate": "2016-07-13 15:13:01",
            "MobileNumber": "9898987876",
            "Name": "kranthi",
            "PassWord": "kranthi",
            "UserName": "kranthi"
          },
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
         * @apiError INVALID_CREDENTIALS Invalid credentials.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "User not found",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetUserDetails(string userId);

        /**
        * @api {post} a1/DeleteUser Delete User
        * @apiName DeleteUser
        * @apiGroup Admin
        *
        * @apiHeader {string} Token_Code Authntication code
        * @apiHeader {string} User_Id user id
        * @apiHeader {string} Content-Type application/json
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Token code got from login API" ,
        *    "User_Id": "User id" ,
        *    "Content-Type": "application/json"
        *  }
        *   
        * @apiParam {String} userId user id of admin user.
        * 
        *
        * @apiParamExample {json} Param-Example:
        * 
          {
            "userId": "E51DF58EF04A1947BE85BB5B04AC94A9"
          }
        *
        * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
        * @apiError INVALID_CREDENTIALS Invalid credentials.
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "Fail",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeleteUser(string userId);


        /**
        * @api {post} a1/UpdateUserStatus Update User Status
        * @apiName UpdateUserStatus
        * @apiGroup Admin
        *
        * @apiHeader {string} Token_Code Authntication code
        * @apiHeader {string} User_Id user id
        * @apiHeader {string} Content-Type application/json
        * 
        * @apiHeaderExample {json} Header-Example:
        *  {
        *    "Token_Code": "Token code got from login API" ,
        *    "User_Id": "User id" ,
        *    "Content-Type": "application/json"
        *  }
        *   
        * @apiParam {String} userId user id of admin user.
        * @apiParam {Bool} isActive whether user is active 
        * 
        *
        * @apiParamExample {json} Param-Example:
        * 
          {
            "userId":"EFB93DAEFECC0D409E2AC5FEB4441615",
            "isActive":false
          }   
        *
        * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
         }
        * @apiError FAIL updating status failed
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "Fail",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateUserStatus(string userId, bool isActive);

        #endregion

        #region Complaints
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetComplaints(int complaintStatus);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateComplaint(Complaint complaint);

        /**
         * @api {post} a1/GetAllComplaints Get All Complaints
         * @apiName GetAllComplaints
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
         * @apiParam {string} complaintStatus Complaint status where 0 refers to all complaints.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *       {
                  "complaintStatus": 1
                }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "Complaint:#Tasko.Model",
                      "ComplaintChats": null,
                      "ComplaintId": "Complaint#1000",
                      "ComplaintStatus": 0,
                      "DueDate": null,
                      "LoggedDate": "2016-07-16 07:16:28",
                      "OrderId": null,
                      "Title": "Test"
                    }
                  ],
                  "Error": false,
                  "Message": "Success",
                  "Status": 200
        }
         * @apiError COMPLAINT_NOT_FOUND Complaints not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Complaints not found",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetAllComplaints(int complaintStatus);
        #endregion

        #region Notifications

        /**
         * @api {post} a1/GetAllComplaints Get All Complaints
         * @apiName GetAllComplaints
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
                      "__type": "GcmUser:#Tasko.Model",
                      "CustomerId": "F3E6D9CBF8EF6A4289E1FC3509076D54",
                      "GcmId": "995FB41FF15F374398985802AF9E0CD5",
                      "GcmRegId": "APA91bEvA_MLQBs27lR24U_dEXkBoxL5K5VL5l2BkkVoi_6axHy8tEQvEBLRZ-Vlo4FY9u6S0I5PI5EhshJ-jJ5JjgjYBhExk2kuCVa7cFC1KxNgi6QMpzu6IsClEGbbV2ZvG_-H6DC6",
                      "Name": "srikanth",
                      "VendorId": null
                    }
                  ],
                  "Error": false,
                  "Message": "Success",
                  "Status": 200
        }
         * @apiError USERS_NOT_FOUND Users not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Users not found",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetAllGCMUsers();

        #endregion

        #region Offline Vendor Request
        /**
        * @api {post} a1/GetOffileVendorRequests Gets offline vendor requests for the day
        * @apiName GetOffileVendorRequests
        * @apiGroup Admin
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
        * @apiSuccessExample Success-Response:
        {
           "Data": [
                    {
                      "__type": "OfflineVendorRequest:#Tasko.Model",
                      "CustomerName": "srikanth test",
                      "CustomerPhone": "9849345086",
                      "Id": "4720EA1EEFDEE141AABE38A7E7D3831A",
                      "RequestedServiceId": "2D0D8369F97C7E4D9757F4F1BF39324C",
                      "RequestedServiceName": "AC Installation"
                    },
                    {
                      "__type": "OfflineVendorRequest:#Tasko.Model",
                      "CustomerName": "Shivaji",
                      "CustomerPhone": "1234567890",
                      "Id": "697413385619B943BE380ADFF78EA868",
                      "RequestedServiceId": "3CB1F934AEE59E4EA6E824B96752FE27",
                      "RequestedServiceName": "Semi-Automatic Washing Machine Service"
                    }
                  ],
                  "Error": false,
                  "Message": "Success",
                  "Status": 200
        }
        * @apiError REQUESTS_NOT_FOUND No Offline Requests
        *
        * @apiErrorExample Error-Response:
        {
          "Data": null,
          "Error": true,
          "Message": "No Offline Requests",
          "Status": 400
        }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetOffileVendorRequests();
        #endregion
    }
}
