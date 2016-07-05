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
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The Password.
        /// </value>
        [DataMember]
        public string Password { get; set; }

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
        /// Gets or sets the Address Info.
        /// </summary>
        /// <value>
        /// The Address Info.
        /// </value>
        [DataMember]
        public AddressInfo VendorAddress { get; set; }

        /// <summary>
        /// Gets or sets the Monthly Charge
        /// </summary>
        /// <value>
        /// The Monthly Charge.
        /// </value>
        [DataMember]
        public double MonthlyCharge { get; set; }

        /// <summary>
        /// Gets or sets the VendorServices
        /// </summary>
        /// <value>
        /// The VendorServices.
        /// </value>
        [DataMember]
        public List<VendorService> VendorServices { get; set; }
    }
}
