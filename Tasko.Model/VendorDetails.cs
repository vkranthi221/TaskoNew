using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// Vendor Details. 
    /// </summary>
    [DataContract]
    public class VendorDetails
    {

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>
        /// The Gender.
        /// </value>
        [DataMember]
        public short Gender { get; set; }

        /// <summary>
        /// Gets or sets the Date of birth.
        /// </summary>
        /// <value>
        /// The Date of birth.
        /// </value>
        [DataMember]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the Monthly Charge
        /// </summary>
        /// <value>
        /// The Monthly Charge.
        /// </value>
        [DataMember]
        public double MonthlyCharge { get; set; }

        /// <summary>
        /// Gets or sets the Vendor is blocked
        /// </summary>
        /// <value>
        /// The Is Vendor Blocked.
        /// </value>
        [DataMember]
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the Vendor is power seller
        /// </summary>
        /// <value>
        /// The Is Vendor power seller.
        /// </value>
        [DataMember]
        public bool IsPowerSeller { get; set; }

        /// <summary>
        /// Gets or sets the Vendor is blocked from orders
        /// </summary>
        /// <value>
        /// The Is Vendor Blocked from orders.
        /// </value>
        [DataMember]
        public bool AreOrdersBlocked { get; set; }
    }
}
