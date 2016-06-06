using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// Favorite Vendor 
    /// </summary>
    [DataContract]
    public class FavoriteVendor
    {
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
        /// Gets or sets the total ratings for the venodr.
        /// </summary>
        /// <value>
        /// Total ratings of the vendor.
        /// </value>
        [DataMember]
        public int TotalRatings { get; set; }
        
        /// <summary>
        /// Gets or sets the overall rating.
        /// </summary>
        /// <value>
        /// The overall rating.
        /// </value>
        [DataMember]
        public int OverallRating { get; set; }
    }
}
