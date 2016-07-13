using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Tasko.Model
{
    /// <summary>
    /// Itis the model class for both vendor and customer. 
    /// </summary>
    [DataContract]
    public class VendorSummary
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        [DataMember]
        public int UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        [DataMember]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is vendor live].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is vendor live]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsVendorLive { get; set; }
                
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [DataMember]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        [DataMember]
        public string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the monthly charge.
        /// </summary>
        /// <value>
        /// The monthly charge.
        /// </value>
        [DataMember]
        public double MonthlyCharge { get; set; }
    }
}
