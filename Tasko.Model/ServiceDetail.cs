using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// ServiceDetail Class
    /// </summary>
    [DataContract]
    public class ServiceDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDetail"/> class.
        /// </summary>
        public ServiceDetail()
        {
            this.Service = new Service();
        }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        [DataMember]
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the total vendors.
        /// </summary>
        /// <value>
        /// The total vendors.
        /// </value>
        [DataMember]
        public short TotalVendors { get; set; }

        /// <summary>
        /// Gets or sets the total orders.
        /// </summary>
        /// <value>
        /// The total orders.
        /// </value>
        [DataMember]
        public short TotalOrders { get; set; }
    }
}
