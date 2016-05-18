using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tasko.Model
{
    /// <summary>
    /// User Class
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the pass word.
        /// </summary>
        /// <value>
        /// The pass word.
        /// </value>
        [DataMember]
        public string PassWord { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        [DataMember]
        public string MobileNumber { get; set; }

    }
}
