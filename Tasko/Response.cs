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
    [KnownType(typeof(MessageDetail))]
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
    [KnownType(typeof(List<User>))]
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
    [KnownType(typeof(DashboardMeter))]
    [KnownType(typeof(RecentActivities))]   
    [KnownType(typeof(List<RecentActivities>))]
    [KnownType(typeof(VendorOverview))]
    [KnownType(typeof(Payment))]
    [KnownType(typeof(List<Payment>))]
    [KnownType(typeof(VendorPaymentInvoice))]
    [KnownType(typeof(ServiceOverview))]
    [KnownType(typeof(CustomerOverview))]
    [KnownType(typeof(List<Customer>))]
    [KnownType(typeof(List<CustomerRating>))]
    [KnownType(typeof(Complaint))]
    [KnownType(typeof(List<Complaint>))]
    [KnownType(typeof(ComplaintChat))]
    [KnownType(typeof(List<ComplaintChat>))]
    [KnownType(typeof(GcmUser))]
    [KnownType(typeof(List<GcmUser>))]
    [KnownType(typeof(OfflineVendorRequest))]
    [KnownType(typeof(List<OfflineVendorRequest>))]
    [KnownType(typeof(VendorDocuments))]
    [KnownType(typeof(List<Vendor>))]
    [KnownType(typeof(State))]
    [KnownType(typeof(List<State>))]
    [KnownType(typeof(City))]
    [KnownType(typeof(List<City>))]
    [KnownType(typeof(RateCard))]
    [KnownType(typeof(List<RateCard>))]
    [KnownType(typeof(SocialMediaPost))]
    [KnownType(typeof(List<SocialMediaPost>))]
    [KnownType(typeof(SocialMediaLikedCustomer))]
    [KnownType(typeof(List<SocialMediaLikedCustomer>))]
    [KnownType(typeof(PostReport))]
    [KnownType(typeof(List<PostReport>))]
    [KnownType(typeof(PostLikes))]
    [KnownType(typeof(List<PostLikes>))]
    
    public class Response
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Response()
        {
            this.Status = 400;
            this.Error = true;
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