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
    [DataContract]
    [KnownType(typeof(Order))]
    [KnownType(typeof(User))]
    [KnownType(typeof(Vendor))]
    [KnownType(typeof(VendorOverallRating))]
    [KnownType(typeof(VendorRating))]
    [KnownType(typeof(List<VendorRating>))]
    [KnownType(typeof(Tasko.Model.VendorService))]
    [KnownType(typeof(List<Tasko.Model.VendorService>))]
    [KnownType(typeof(List<Order>))]
    [KnownType(typeof(List<AddressInfo >))]
    [KnownType(typeof(List<LoginInfo>))]
    [KnownType(typeof(FaultException))]
    [KnownType(typeof(ErrorDetails))]
    [KnownType(typeof(List<Service>))]
    [KnownType(typeof(List<ServiceVendor>))]    
    [KnownType(typeof(Customer))]
    [KnownType(typeof(OrderSummary))]
    [KnownType(typeof(List<OrderSummary>))]     
    public class Response
    {
        [DataMember]
        public bool Error { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public object Data { get; set; }
    }
}