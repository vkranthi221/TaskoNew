using System.ServiceModel;
using System.ServiceModel.Web;
using Tasko.Model;

namespace Tasko.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        /**
         * @api {post} c1/GetOrderDetails Get Order details
         * @apiName GetOrderDetails
         * @apiGroup Customer
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

        /**
         * @api {post} c1/GetRecentOrder Get Recent Order
         * @apiName GetRecentOrder
         * @apiGroup Customer
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
         * @apiParam {String} customerId Customer Id.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *   "customerId": "F501CE6E98E3A549B024E1565561EC62"
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
                    "__type": "Order:#Tasko.Model",
                    "Comments": "",
                    "CustomerId": "F501CE6E98E3A549B024E1565561EC62",
                    "CustomerName": "srikanth test",
                    "DestinationAddress": {
                      "Address": "plot no 404, BaghyaNagar",
                      "AddressId": "3E71FF52AF41AC448F11C6085D4BDC69",
                      "AddressType":"Home",
                      "City": "Hyderabad",
                      "Country": "India",
                      "Lattitude": "40",
                      "Locality": "HMT HILLS",
                      "Longitude": "600",
                      "Pincode": "500072",
                      "State": "Telangana"
                    },
                    "Location": "",
                    "OrderId": "TASKO1011",
                    "OrderStatus": "Requested",
                    "OrderStatusId": 1,
                    "RequestedDate": "2016-06-08 07:33:17",
                    "ServiceId": "0AEAC4261E569C498A05ABBEEC84EA55",
                    "ServiceName": "Microwave Service",
                    "SourceAddress": {
                      "Address": "plot no 101, vivekanandaNagar",
                      "AddressId": "97B42A2664F905489E9B2E4524EDB0E2",
                      "AddressType":"Home",
                      "City": "Hyderabad",
                      "Country": "India",
                      "Lattitude": "10",
                      "Locality": "kphb",
                      "Longitude": "200",
                      "Pincode": "500081",
                      "State": "Telangana"
                    },
                    "VendorId": "FC73EC7242E28142ACCAFDF4703F0EBF",
                    "VendorName": "srikanth",
                    "VendorServiceId": "CF9A27B3DA0D5E418B1A8E6CC79218AD"
                  },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ORDER_NOT_FOUND The Order not found.
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
        Response GetRecentOrder(string customerId);

        /**
         * @api {post} c1/GetServices Get Services
         * @apiName GetServices
         * @apiGroup Customer
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
         * @apiParam\n.
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "Service:#Tasko.Model",
                      "Id": "0230AB8F8DB92548A58BC7F3FCD6C310",
                      "ImageURL": "",
                      "Name": "Refrigerator Service",
                      "ParentServiceId": null
                    },
                    {
                      "__type": "Service:#Tasko.Model",
                      "Id": "098DF6729F546143B0D9FC824227D384",
                      "ImageURL": "http://api.tasko.in/serviceimages/ac_services.png",
                      "Name": "AC Service",
                      "ParentServiceId": null
                    },
                    {
                      "__type": "Service:#Tasko.Model",
                      "Id": "0AEAC4261E569C498A05ABBEEC84EA55",
                      "ImageURL": "",
                      "Name": "Microwave Service",
                      "ParentServiceId": null
                    }
                  ]
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
        Response GetServices();

        /**
         * @api {post} c1/GetServiceVendors Get Service Vendors
         * @apiName GetServiceVendors
         * @apiGroup Customer
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
         * @apiParam {String} serviceId Service Id.
         * @apiParam {String} customerId Customer Id.
         * @apiParam {String} latitude Latitude.
         * @apiParam {String} longitude Longitude.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "serviceId": "47DAF7A1B95E8040BD9FA90252E72E17",
         *    "customerId": "10E4394670195C4AA1E4B7130A514187",
         *    "latitude": "17.3850440",
         *    "longitude": "78.4866710"
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "ServiceVendor:#Tasko.Model",
                      "BaseRate": 82,
                      "IsFavoriteVendor": true,
                      "OverAllRating": 3,
                      "ServiceId": "0AEAC4261E569C498A05ABBEEC84EA55",
                      "ServiceName": "Microwave Service",
                      "TotalReviews": 10,
                      "VendorId": "FC73EC7242E28142ACCAFDF4703F0EBF",
                      "VendorName": "srikanth",
                      "VendorServiceId": "CF9A27B3DA0D5E418B1A8E6CC79218AD",
                      "Distance": 4,
                      "ETA":"21 mins"
                    }
                  ],
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError VENDORS_NOT_FOUND Vendors are not found for the selected service.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Vendors are not found for the selected service",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetServiceVendors(string serviceId, string customerId, string latitude, string longitude);

        /**
         * @api {post} c1/ConfirmOrder Confirm Order
         * @apiName ConfirmOrder
         * @apiGroup Customer
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
         * @apiParam {Order} order order.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "order": {
         *    "Comments": "",
         *    "CustomerId": "10E4394670195C4AA1E4B7130A514187",
         *    "CustomerName": "srikanth test",
         *    "CustomerPhone": "9999999999",
         *    "DestinationAddress": {
         *      "Address": "plot no 404, BaghyaNagar",
         *      "AddressType":"Home",
         *      "City": "Hyderabad",
         *      "Country": "India",
         *      "Lattitude": "40",
         *      "Locality": "HMT HILLS",
         *      "Longitude": "600",
         *      "Pincode": "500072",
         *      "State": "Telangana"
         *    },
         *    "Location": "kphb",
         *    "OrderStatus": "Requested",
         *    "OrderStatusId": 1,
         *    "RequestedDate": "/Date(1465353306423+0530)/",
         *    "ServiceId": "BF0860B092FA2447AE6AA8B3609FDCA9",
         *    "ServiceName": "Microwave Service",
         *    "SourceAddress": {
         *      "Address": "plot no 101, vivekanandaNagar",
         *      "AddressType":"Home",
         *      "City": "Hyderabad",
         *      "Country": "India",
         *      "Lattitude": "10",
         *      "Locality": "kphb",
         *      "Longitude": "200",
         *      "Pincode": "500081",
         *      "State": "Telangana"
         *    },
         *    "VendorId": "B0269B0769CC8D48AEB92D2513EA14D6",
         *    "VendorName": "Srikanth",
         *    "VendorServiceId": "C9C834D79EE3BC48BF8D5669B2560D24"
         *  }
         *}
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": "OrderId: TASKO1012",
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ORDER_NOT_CONFIRMED Order not Confirmed.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Order not Confirmed",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ConfirmOrder(Order order);

        /**
         * @api {post} c1/UpdateCustomer Update Customer
         * @apiName UpdateCustomer
         * @apiGroup Customer
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
         * @apiParam {Customer} Customer Customer.
         *
         * @apiParamExample {json} Param-Example:
         * {
         * "customer":
         *  {
         *   "Id": "10E4394670195C4AA1E4B7130A514187",
         *   "Name": "srikanth testing",
         *   "EmailAddress": "penmetsa.srikanth@gmail.com",
         *   "MobileNumber": "9849345086"
         *  }
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
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateCustomer(Customer customer);

        /**
         * @api {post} c1/GetCustomerOrders Get Customer Orders
         * @apiName GetCustomerOrders
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {int} orderStatus Order Status.
         * 
         * @apiParam {int} pageNumber Page Number.
         * 
         * @apiParam {int} recordsPerPage Records Per Page.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "customerId":"10E4394670195C4AA1E4B7130A514187",
         *  "orderStatus":"1",
         *  "pageNumber":"",
         *  "recordsPerPage":""
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": "",
                      "OrderId": "TASKO1011",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-06-08 07:33:17",
                      "ServiceId": "0AEAC4261E569C498A05ABBEEC84EA55",
                      "ServiceName": "Microwave Service"
                    },
                    {
                      "__type": "OrderSummary:#Tasko.Model",
                      "Comments": "",
                      "OrderId": "TASKO1012",
                      "OrderStatus": "Requested",
                      "RequestedDate": "2016-07-01 18:17:44",
                      "ServiceId": "0AEAC4261E569C498A05ABBEEC84EA55",
                      "ServiceName": "Microwave Service"
                    }
                  ],
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ORDERS_NOT_FOUND Orders not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Orders not found",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerOrders(string customerId, int orderStatus, int pageNumber, int recordsPerPage);

        /**
         * @api {post} c1/AddCustomerAddress Add Customer Address
         * @apiName AddCustomerAddress
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {AddressInfo} addressInfo Address Info.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "customerId": "10E4394670195C4AA1E4B7130A514187 ",
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
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError CUSTOMER_DETAILS_INVALID Customer Id and address are mandatory.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Customer Id and address are mandatory",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddCustomerAddress(string customerId, AddressInfo addressInfo);

        /**
         * @api {post} c1/UpdateCustomerAddress Update Customer Address
         * @apiName UpdateCustomerAddress
         * @apiGroup Customer
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
         * @apiParam {AddressInfo} addressInfo Address Info.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *     "addressInfo": 
         *       {
         *         "Address": "plot no 101, vivekanandaNagar",
         *         "AddressId": "542875B7E7719942AA82B3EABCEE64BF",
         *         "AddressType":"Home",
         *         "City": "Hyderabad",
         *         "Country": "India",
         *         "Lattitude": "10",
         *         "Locality": "kphb",
         *         "Longitude": "200",
         *         "Pincode": "500081",
         *         "State": "Telangana"
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
         * @apiError CUSTOMER_ADDRESS_INVALID Customer Address Invalid.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Customer Address Invalid",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateCustomerAddress(AddressInfo addressInfo);

        /**
         * @api {post} c1/DeleteCustomerAddress Delete Customer Address
         * @apiName DeleteCustomerAddress
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {string} addressId Address Id.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "customerId": "10E4394670195C4AA1E4B7130A514187",
         *  "addressId": "346E84F8827D624FB39829A35A23209B"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_DETAILS Invalid Details.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Details",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeleteCustomerAddress(string customerId, string addressId);

        /**
         * @api {post} c1/GetCustomerAddresses Get Customer Address
         * @apiName GetCustomerAddresses
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "customerId": "10E4394670195C4AA1E4B7130A514187 ",
          * "addressInfo": 
          *  {
         *     "Address": "plot no 101, vivekanandaNagar",
         *     "AddressId": "542875B7E7719942AA82B3EABCEE64BF",
         *     "AddressType":"Home",
         *     "City": "Hyderabad",
         *     "Country": "India",
         *     "Lattitude": "10",
         *     "Locality": "kphb",
         *     "Longitude": "200",
         *     "Pincode": "500081",
         *     "State": "Telangana"
         *   }
         * }
         * 
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "AddressInfo:#Tasko.Model",
                      "Address": "plot no 101, vivekanandaNagar",
                      "AddressId": "B7DD393239CE854FA5596C67DBF12DD0",
                      "AddressType":"Home",
                      "City": "Hyderabad",
                      "Country": "India",
                      "Lattitude": "10",
                      "Locality": "kphb",
                      "Longitude": "200",
                      "Pincode": "500081",
                      "State": "Telangana"
                    },
                    {
                      "__type": "AddressInfo:#Tasko.Model",
                      "Address": "plot no 101, vivekanandaNagar",
                      "AddressId": "4CDE7B6962CFEC4FB9722081E75DC21C",
                      "AddressType":"Home",
                      "City": "Hyderabad",
                      "Country": "India",
                      "Lattitude": "10",
                      "Locality": "kphb",
                      "Longitude": "200",
                      "Pincode": "500081",
                      "State": "Telangana"
                    },
                    {
                      "__type": "AddressInfo:#Tasko.Model",
                      "Address": "plot no 101, vivekanandaNagar",
                      "AddressId": "BD0E478182ED4C4FB12CE7CD580C910A",
                      "AddressType":"Home",
                      "City": "Hyderabad",
                      "Country": "India",
                      "Lattitude": "10",
                      "Locality": "kphb",
                      "Longitude": "200",
                      "Pincode": "500081",
                      "State": "Telangana"
                    }
                  ],
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError CUSTOMER_ADDRESS_NOT_FOUND Customer Addresses not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Customer Addresses not found",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerAddresses(string customerId);

        /**
         * @api {post} c1/AddVendorRating Add Vendor Rating
         * @apiName AddVendorRating
         * @apiGroup Customer
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
         * @apiParam {string} orderId Order Id.
         * 
         * @apiParam {VendorRating} vendorRating Vendor Rating.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *   "orderId":"TASKO1012",
         *   "vendorRating":
         *   {   
         *     "CustomerId": "10E4394670195C4AA1E4B7130A514187",
         *     "VendorId": "B0269B0769CC8D48AEB92D2513EA14D6",
         *     "ServiceQuality": "5",
         *     "Punctuality": "5",
         *     "Courtesy": "5",
         *     "Price": "5",
         *     "Comments":"Excellent"
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
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddVendorRating(string orderId, VendorRating vendorRating);

        /**
         * @api {post} c1/SetFavoriteVendor Set Favorite Vendor
         * @apiName SetFavoriteVendor
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {string} vendorId Vendor Id.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "customerId": "BA09714B34AEEC4BB84A5675FB3662BD",
         *  "vendorId": "ACC75F79F2CFD94E8434D2B3E848889E"
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
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response SetFavoriteVendor(string customerId, string vendorId);

        /**
         * @api {post} c1/GetFavoriteVendors Get Favorite Vendors
         * @apiName GetFavoriteVendors
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "customerId": "BA09714B34AEEC4BB84A5675FB3662BD"
         *  }
         * 
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "FavoriteVendor:#Tasko.Model",
                      "OverallRating": 3,
                      "TotalRatings": 11,
                      "VendorId": "FC73EC7242E28142ACCAFDF4703F0EBF",
                      "VendorName": "srikanth"
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
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetFavoriteVendors(string customerId);

        /**
         * @api {post} v1/GenerateOTP Generate OTP
         * @apiName GenerateOTP
         * @apiGroup Customer
         *
         * @apiHeader {string} Auth_Code Authentication Code
         * @apiHeader {string} Content-Type application/json
         * 
         * @apiHeaderExample {json} Header-Example:
         *  {
         *    "Auth_Code": "Authentication code generated using Auth API" ,
         *    "Content-Type": "application/json"
         *  }
         *    
         * @apiParam {String} emailId Email Id.
         * @apiParam {String} phoneNumber Phone number.
         * @apiParam {String} checkUserExistence check User Existence.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *  "emailId": "",
         *  "phoneNumber": "9849345086",
         *  "checkUserExistence": true
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Successs",
          "Status": 200
         }
         * @apiError ERROR_GENERATING_OTP Error Generating OTP.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error Generating OTP",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GenerateOTP(string emailId, string phoneNumber, bool checkUserExistence);

        /**
         * @api {post} v1/ValidateOTP Validate OTP
         * @apiName ValidateOTP
         * @apiGroup Customer
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
         * @apiParam {String} phoneNumber Phone number.
         * @apiParam {String} OTP OTP to login.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *   "phoneNumber": "9849345086",
         *   "OTP": "E3rwSC"
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Successs",
          "Status": 200
         }
         * @apiError INVALID_OTP Invalid OTP.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid OTP",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ValidateOTP(string phoneNumber, string OTP);

        /**
         * @api {post} v1/SignUp SignUp 
         * @apiName SignUp
         * @apiGroup Customer
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
         * @apiParam {String} name name of customer.
         * 
         * @apiParam {String} emailId Email.
         * 
         * @apiParam {String} phoneNumber Phone number.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *   "name": "srikanth test",
         *   "emailId": "srikanth.penmetsa@gmail.com",
         *   "phoneNumber": "9849345086"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
                    "__type": "LoginInfo:#Tasko.Model",
                    "TokenId": "5064D3286F70DB4D955D74BD81D58C1F",
                    "UserId": "401C251B97FC624CB35D94088F1378DA"
                  },
          "Error": false,
          "Message": "Successs",
          "Status": 200
         }
         * @apiError INVALID_AUTHCODE Invalid Authcode.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Authcode",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response SignUp(string name, string emailId, string phoneNumber);

        /**
         * @api {post} v1/Login Login 
         * @apiName Login
         * @apiGroup Customer
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
         * @apiParam {String} name name of customer.
         * 
         * @apiParam {String} OTP OTP.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *   "phoneNumber": "9849345086",
         *   "OTP": "8FTLYc"
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": {
                    "__type": "LoginInfo:#Tasko.Model",
                    "TokenId": "5E1A3D0D493A754D820AECB8AC40E790",
                    "UserId": "F501CE6E98E3A549B024E1565561EC62"
                  },
          "Error": false,
          "Message": "Successs",
          "Status": 200
         }
         * @apiError INVALID_OTP_PHONENUMBER Invalid Phone Number Or OTP.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Phone Number Or OTP",
          "Status": 400
        }
         */
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response Login(string phoneNumber, string OTP);

        /**
         * @api {post} c1/auth Get Auth Code
         * @apiName auth
         * @apiGroup Customer
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
         * @api {post} c1/GetCustomerDetails Get Customer Details
         * @apiName GetCustomerDetails
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "customerId": "Customer id" 
         *  }
         * 
         * @apiSuccessExample Success-Response:
         {
          "Data": {
                    "__type": "Customer:#Tasko.Model",
                    "EmailAddress": "srikanth.penmetsa@gmail.com",
                    "Id": "F501CE6E98E3A549B024E1565561EC62",
                    "MobileNumber": "9849345086",
                    "Name": "srikanth test"
                  },
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError CUSTOMER_NOT_FOUND Customer not found.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Customer not found",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerDetails(string customerId);

        /**
         * @api {post} c1/DeleteFavoriteVendor Delete Favorite Vendor
         * @apiName DeleteFavoriteVendor
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.         
         * @apiParam {string} vendorId Vendor Id.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "customerId": "customer Id that you would like to remove association for the given vendor Id" 
         *    "vendorId": "Vendor Id that you would like to remove from favorite list" 
         *  }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_DETAILS Invalid Details.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Details",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeleteFavoriteVendor(string customerId, string vendorId);

        #region Complaints
        /**
         * @api {post} c1/AddComplaint Add Complaint
         * @apiName AddComplaint
         * @apiGroup Customer
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
         * @apiParam {string} complaint complaint.
         *
         * @apiParamExample {json} Param-Example:
         * {
                "complaint":
         *                   {
         *                   "__type": "Complaint:#Tasko.Model",
         *                   "OrderId": "TASKO1000",
         *                   "Title": "Test",
         *                   "ComplaintChats": [
         *                                       {
         *                                         "__type": "ComplaintChat:#Tasko.Model",
         *                                         "ChatContent": "testing"
         *                                       }
         *                                   ]
         *                  }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": "Complaint#1001",
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError ERROR_ADDING_COMPLAINT Error Adding Complaint.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Error Adding Complaint",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddComplaint(Complaint complaint);

        /**
         * @api {post} c1/AddComplaintChat Add Complaint Chat
         * @apiName AddComplaintChat
         * @apiGroup Customer
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
         * @apiParam {string} complaint complaint.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *       "complaintChat":
         *                       {
         *                       "__type": "ComplaintChat:#Tasko.Model",
         *                       "ComplaintId": "Complaint#1004",
         *                       "ChatContent": "test data"
         *                      }
         * }
         *
         * @apiSuccessExample Success-Response:
         {
          "Data": null,
          "Error": false,
          "Message": "Success",
          "Status": 200
        }
         * @apiError INVALID_TOKEN_CODE Invalid Token code.
         *
         * @apiErrorExample Error-Response:
         {
          "Data": null,
          "Error": true,
          "Message": "Invalid Token code",
          "Status": 400
        }
         */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddComplaintChat(ComplaintChat complaintChat);

        /**
         * @api {post} c1/GetCustomerComplaints Get Customer Complaints
         * @apiName GetCustomerComplaints
         * @apiGroup Customer
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
         * @apiParam {string} customerId customer Id.
         *
         * @apiParamExample {json} Param-Example:
         * {
         *       {
                  "customerId": "D519EDD9B0713B4699E75C0D24F54370"
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
        Response GetCustomerComplaints(string customerId);

        #endregion

        #region Maps

        /**
        * @api {post} c1/GetNearbyVendors Get Nearby Vendors
        * @apiName GetNearbyVendors
        * @apiGroup Customer
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
        *
        * @apiParam {string} longitude Longitude of Vendor.
        *
        * @apiParam {string} latitude Latitude of Vendor.
        * 
        * @apiParamExample {json} Param-Example:
        *  {
        *     "latitude": "17.3850440",
              "longitude": "78.4866710"
        *  }
        *
        * @apiSuccessExample Success-Response:
        {
        *  "Data": [
        *            {
        *              "__type": "VendorSummary:#Tasko.Model",
        *              "Distance": 4,
        *              "DueDate": null,
        *              "EmailAddress": null,
        *              "IsVendorLive": false,
        *              "Latitude": 17.385,
        *              "Longitude": 78.4867,
        *              "MobileNumber": null,
        *              "MonthlyCharge": 0,
        *              "Name": "Srikanth",
        *              "UniqueId": 0,
        *              "UserName": "srikanth",
        *              "VendorId": "F3E6D9CBF8EF6A4289E1FC3509076D54",
         *              "ETA":"21 mins"
        *            }
        *          ],
        *  "Error": false,
        * "Message": "Success",
        * "Status": 200
       }
        * @apiError NO_NEARBY_VENDORS No Nearby Vendors
        *
        * @apiErrorExample Error-Response:
        {
         "Data": null,
         "Error": true,
         "Message": "No Nearby Vendors",
         "Status": 400
       }
        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetNearbyVendors(string latitude, string longitude);
        #endregion

        #region Notifications
        /**
        * @api {post} c1/StoreCustomerGCMUser Store Vendor GCM User
        * @apiName StoreCustomerGCMUser
        * @apiGroup Customer
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
        * 
        * @apiParam {string} name GCM User Name . 
        * 
        * @apiParam {string} gcmRedId GCMREDID. 
        * 
        * @apiParamExample {json} Param-Example:
        *  {
        *    "customerId":"Customer Id",
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
        Response StoreCustomerGCMUser(string name, string customerId, string gcmRedId);

        #endregion

        #region Offline Vendors
        /**
         * @api {post} c1/SaveOfflineVendorRequest Save Offline Vendor Request
         * @apiName SaveOfflineVendorRequest
         * @apiGroup Customer
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
         * @apiParam {string} customerId Customer Id.         
         * @apiParam {string} serviceId Service Id.
         * @apiParam {string} area area.
         *
         * @apiParamExample {json} Param-Example:
         *  {
         *    "customerId": "customer Id that you would like to remove association for the given vendor Id" 
         *    "serviceId": "Service Id that the customer wants" 
         *    "area": "Area where the customer wants service for" 
         *  }
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
        Response SaveOfflineVendorRequest(string customerId, string serviceId, string area);
        #endregion
    }
}
