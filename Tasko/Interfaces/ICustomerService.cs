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

        /**
         * @api {post} c1/GetRecentOrder Get Recent Order
         * @apiName GetRecentOrder
         * @apiGroup Customer
         *
         * @apiParam {String} customerId Customer Id.
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
         * @apiParam {String} serviceId Service Id.
         * @apiParam {String} customerId Customer Id.
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
                      "VendorServiceId": "CF9A27B3DA0D5E418B1A8E6CC79218AD"
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
        Response GetServiceVendors(string serviceId, string customerId);

        /**
         * @api {post} c1/ConfirmOrder Confirm Order
         * @apiName ConfirmOrder
         * @apiGroup Customer
         *
         * @apiParam {Order} order order.
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
         * @apiParam {Customer} Customer Customer.
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {int} orderStatus Order Status.
         * 
         * @apiParam {int} pageNumber Page Number.
         * 
         * @apiParam {int} recordsPerPage Records Per Page.
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {AddressInfo} addressInfo Address Info.
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
         * @apiParam {AddressInfo} addressInfo Address Info.
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {string} addressId Address Id.
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiSuccessExample Success-Response:
         {
          "Data": [
                    {
                      "__type": "AddressInfo:#Tasko.Model",
                      "Address": "plot no 101, vivekanandaNagar",
                      "AddressId": "B7DD393239CE854FA5596C67DBF12DD0",
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
         * @apiParam {string} orderId Order Id.
         * 
         * @apiParam {VendorRating} vendorRating Vendor Rating.
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
         * @apiParam {string} customerId Customer Id.
         * 
         * @apiParam {string} vendorId Vendor Id.
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
         * @apiParam {string} customerId Customer Id.
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
         * @apiParam {String} emailId Email Id.
         * @apiParam {String} phoneNumber Phone number.
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
        Response GenerateOTP(string emailId, string phoneNumber);

        /**
         * @api {post} v1/ValidateOTP Validate OTP
         * @apiName ValidateOTP
         * @apiGroup Customer
         *
         * @apiParam {String} phoneNumber Phone number.
         * @apiParam {String} OTP OTP to login.
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
         * @apiParam {String} name name of customer.
         * 
         * @apiParam {String} emailId Email.
         * 
         * @apiParam {String} phoneNumber Phone number.
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
         * @apiParam {String} name name of customer.
         * 
         * @apiParam {String} OTP OTP.
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
         * @api {post} c1/GetAuthCode Get Auth Code
         * @apiName GetAuthCode
         * @apiGroup Customer
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
         * @api {post} c1/GetCustomerDetails Get Customer Details
         * @apiName GetCustomerDetails
         * @apiGroup Customer
         *
         * @apiParam {string} customerId Customer Id.
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
    }
}
