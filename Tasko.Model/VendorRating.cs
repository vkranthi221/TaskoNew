using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// Vendor Rating
    /// </summary>
    [DataContract]
    public class VendorRating
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        [DataMember]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets o sets the name of the vendor 
        /// </summary>
        [DataMember]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets o sets the order id
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }


        /// <summary>
        /// Gets or sets the over all rating.
        /// </summary>
        /// <value>
        /// The over all rating.
        /// </value>
        [DataMember]
        public decimal OverAllRating { get; set; }

        /// <summary>
        /// Gets or sets the service quality.
        /// </summary>
        /// <value>
        /// The service quality.
        /// </value>
        [DataMember]
        public decimal ServiceQuality { get; set; }

        /// <summary>
        /// Gets or sets the punctuality.
        /// </summary>
        /// <value>
        /// The punctuality.
        /// </value>
        [DataMember]
        public decimal Punctuality { get; set; }

        /// <summary>
        /// Gets or sets the courtesy.
        /// </summary>
        /// <value>
        /// The courtesy.
        /// </value>
        [DataMember]
        public decimal Courtesy { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the review date.
        /// </summary>
        /// <value>
        /// The review date.
        /// </value>
        [DataMember]
        public string ReviewDate { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        [DataMember]
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [DataMember]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order price.
        /// </summary>
        /// <value>
        /// The order price.
        /// </value>
        [DataMember]
        public decimal OrderPrice { get; set; }
    }
}
