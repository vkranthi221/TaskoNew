using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tasko.Model
{
    /// <summary>
    /// Vendor Service
    /// </summary>
    [DataContract]
    public class ServiceVendor
    {
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
        /// Gets or sets the vendor service identifier.
        /// </summary>
        /// <value>
        /// The vendor service identifier.
        /// </value>
        [DataMember]
        public string VendorServiceId { get; set; }

        /// <summary>
        /// Gets or sets the base rate.
        /// </summary>
        /// <value>
        /// The base rate.
        /// </value>
        [DataMember]
        public double BaseRate { get; set; }

        /// <summary>
        /// Gets or sets Is Favorite Vendor.
        /// </summary>
        /// <value>
        /// The Is Favorite Vendor.
        /// </value>
        [DataMember]
        public bool IsFavoriteVendor { get; set; }

        /// <summary>
        /// Gets or sets the over all rating.
        /// </summary>
        /// <value>
        /// The over all rating.
        /// </value>
        [DataMember]
        public decimal OverAllRating { get; set; }

        /// <summary>
        /// Gets or sets the total reviews.
        /// </summary>
        /// <value>
        /// The total reviews.
        /// </value>
        [DataMember]
        public int TotalReviews { get; set; }

        [DataMember]
        public decimal Longitude { get; set; }

        [DataMember]
        public decimal Latitude { get; set; }

        [DataMember]
        public decimal Distance { get; set; }

        [DataMember]
        public string ETA { get; set; }

        [DataMember]
        public string FacebookUrl { get; set; }

        [DataMember]
        public string Photo { get; set; }

        [DataMember]
        public decimal HomeLongitude { get; set; }

        [DataMember]
        public decimal HomeLatitude { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember(IsRequired = false)]
        public bool IsEntireCityAccessible { get; set; }

        [DataMember(IsRequired = false)]
        public string VendorCity { get; set; }
    }
}
