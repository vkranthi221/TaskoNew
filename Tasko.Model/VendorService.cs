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
    public class VendorService
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsActive { get; set; }
    }
}
