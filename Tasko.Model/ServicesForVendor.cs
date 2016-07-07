using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// The services for Vendor. 
    /// </summary>
    [DataContract]
    public class ServicesForVendor
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        /// <value>
        /// The service name.
        /// </value>
        [DataMember]
        public string ServiceName { get; set; }
    }
}
