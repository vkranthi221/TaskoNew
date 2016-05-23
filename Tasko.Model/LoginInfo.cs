using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// LoginInfo Class
    /// </summary>
    [DataContract]
    public class LoginInfo
    {
        /// <summary>
        /// Gets or sets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        [DataMember]
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember]
        public string UserId { get; set; }
    }
}
