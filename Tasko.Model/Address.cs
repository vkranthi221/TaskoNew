using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// AddressInfo Class
    /// </summary>
    [DataContract]
    public class AddressInfo
    {
        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        [DataMember]
        public string AddressId { get; set; }

        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        /// <value>
        /// The type of the address.
        /// </value>
        [DataMember]
        public string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the lattitude.
        /// </summary>
        /// <value>
        /// The lattitude.
        /// </value>
        [DataMember]
        public string Lattitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        [DataMember]
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the locality.
        /// </summary>
        /// <value>
        /// The locality.
        /// </value>
        [DataMember]
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the pin code.
        /// </summary>
        /// <value>
        /// The pin code.
        /// </value>
        [DataMember]
        public string Pincode { get; set; }

        /// <summary>
        /// Gets or sets the home lattitude.
        /// </summary>
        /// <value>
        /// The lattitude.
        /// </value>
        [DataMember]
        public string HomeLattitude { get; set; }

        /// <summary>
        /// Gets or sets the home longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        [DataMember]
        public string HomeLongitude { get; set; }
    }
}
