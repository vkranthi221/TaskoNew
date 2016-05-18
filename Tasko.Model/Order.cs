using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tasko.Model
{
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        [DataMember]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [DataMember]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        [DataMember]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the vendor service identifier.
        /// </summary>
        /// <value>
        /// The vendor service identifier.
        /// </value>
        [DataMember]
        public string VendorServiceId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        [DataMember]
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        [DataMember]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [DataMember]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>
        /// The name of the service.
        /// </value>
        [DataMember]
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the order status identifier.
        /// </summary>
        /// <value>
        /// The order status identifier.
        /// </value>
        [DataMember]
        public short OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        /// <value>
        /// The order status.
        /// </value>
        [DataMember]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>
        /// The requested date.
        /// </value>
        [DataMember]
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [DataMember]
        public string Location { get; set; }
    }
}
