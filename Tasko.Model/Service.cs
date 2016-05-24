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
    public class Service
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
        /// Gets or sets the parent service identifier.
        /// </summary>
        /// <value>
        /// The parent service identifier.
        /// </value>
        [DataMember]
        public string ParentServiceId { get; set; }

        /// <summary>
        /// Gets or sets the ImageURL.
        /// </summary>
        /// <value>
        /// The ImageURL.
        /// </value>
        [DataMember]
        public string ImageURL { get; set; }
    }
}
