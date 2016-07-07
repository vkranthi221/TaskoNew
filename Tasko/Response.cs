using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using Tasko.Model;

namespace Tasko
{
    /// <summary>
    /// Response class
    /// </summary>
    [DataContract]
    [KnownType(typeof(Order))]
    [KnownType(typeof(User))]
    [KnownType(typeof(Vendor))]
    [KnownType(typeof(VendorOverallRating))]
    [KnownType(typeof(VendorRating))]
    [KnownType(typeof(List<VendorRating>))]
    [KnownType(typeof(VendorService))]
    [KnownType(typeof(List<VendorService>))]
    [KnownType(typeof(List<Order>))]
    [KnownType(typeof(AddressInfo))]
    [KnownType(typeof(List<AddressInfo >))]
    [KnownType(typeof(List<LoginInfo>))]
    [KnownType(typeof(FaultException))]
    [KnownType(typeof(ErrorDetails))]
    [KnownType(typeof(List<Service>))]
    [KnownType(typeof(List<ServiceVendor>))]    
    [KnownType(typeof(Customer))]
    [KnownType(typeof(OrderSummary))]
    [KnownType(typeof(List<OrderSummary>))]
    [KnownType(typeof(FavoriteVendor))]
    [KnownType(typeof(List<FavoriteVendor>))]  
    [KnownType(typeof(List<ServiceDetail>))]
    [KnownType(typeof(List<Vendor>))]
    [KnownType(typeof(VendorSummary))]
    [KnownType(typeof(List<VendorSummary>))]
    [KnownType(typeof(ServicesForVendor))]
    [KnownType(typeof(List<ServicesForVendor>))]
    public class Response
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Response()
        {
            this.Status = 400;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool Error { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [DataMember]
        public object Data { get; set; }
    }
}