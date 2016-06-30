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
         * @apiParam {String} orderId Order Id.
         *
         * @apiSuccess {String} firstname Firstname of the User.
         * @apiSuccess {String} lastname  Lastname of the User.
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
         * @apiError OrderIdNotFound The Order id was not found.
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

        /// <summary>
        /// Gets the recent order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetRecentOrder(string customerId);

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetServices();

        /// <summary>
        /// Gets the service vendors.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetServiceVendors(string serviceId, string customerId);

        /// <summary>
        /// Confirms the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ConfirmOrder(Order order);

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateCustomer(Customer customer);

        /// <summary>
        /// Gets the customer orders.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderStatus">The order status.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerOrders(string customerId, int orderStatus, int pageNumber, int recordsPerPage);

        /// <summary>
        /// Adds the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressInfo">The address information.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddCustomerAddress(string customerId, AddressInfo addressInfo);

        /// <summary>
        /// Updates the customer address.
        /// </summary>
        /// <param name="addressInfo">The address information.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response UpdateCustomerAddress(AddressInfo addressInfo);

        /// <summary>
        /// Deletes the customer address.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response DeleteCustomerAddress(string customerId, string addressId);

        /// <summary>
        /// Gets the customer addresses.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerAddresses(string customerId);

        /// <summary>
        /// Adds the vendor rating.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="vendorRating">The vendor rating.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response AddVendorRating(string orderId, VendorRating vendorRating);

        /// <summary>
        /// Sets the vendor as favorite vendor for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response SetFavoriteVendor(string customerId, string vendorId);

        /// <summary>
        /// Gets the favorite vendors for customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// Response Object
        /// </returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetFavoriteVendors(string customerId);

        /// <summary>
        /// Generates the otp.
        /// </summary>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GenerateOTP(string emailId, string phoneNumber);

        /// <summary>
        /// Validates the otp.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response ValidateOTP(string phoneNumber, string OTP);

        /// <summary>
        /// Signs up.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response SignUp(string name, string emailId, string phoneNumber);

        /// <summary>
        /// Logins the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="OTP">The otp.</param>
        /// <returns>Response Object</returns>
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response Login(string phoneNumber, string OTP);

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns>Response Object</returns>
        [OperationContract]
        [FaultContract(typeof(ErrorDetails))]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "auth")]
        Response GetAuthCode();

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Response Object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Response GetCustomerDetails(string customerId);
    }
}
