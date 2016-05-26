﻿using System;
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
    }
}