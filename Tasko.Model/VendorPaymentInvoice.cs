using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// VendorPaymentInvoice Class
    /// </summary>
    [DataContract]
    public class VendorPaymentInvoice
    {
        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        [DataMember]
        public Payment Payment { get; set; }

        /// <summary>
        /// Gets or sets the vendor address.
        /// </summary>
        /// <value>
        /// The vendor address.
        /// </value>
        [DataMember]
        public AddressInfo VendorAddress { get; set; }
    }
}
