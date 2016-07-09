using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// DashboardMeter Class
    /// </summary>
    [DataContract]
    public class DashboardMeter
    {
        /// <summary>
        /// Gets or sets the total orders.
        /// </summary>
        /// <value>
        /// The total orders.
        /// </value>
        [DataMember]
        public int TotalOrders { get; set; }

        /// <summary>
        /// Gets or sets the total vendors.
        /// </summary>
        /// <value>
        /// The total vendors.
        /// </value>
        [DataMember]
        public int TotalVendors { get; set; }

        /// <summary>
        /// Gets or sets the total customers.
        /// </summary>
        /// <value>
        /// The total customers.
        /// </value>
        [DataMember]
        public int TotalCustomers { get; set; }

        /// <summary>
        /// Gets or sets the total vendor reviews.
        /// </summary>
        /// <value>
        /// The total vendor reviews.
        /// </value>
        [DataMember]
        public int TotalVendorReviews { get; set; }

        /// <summary>
        /// Gets or sets the total customer reviews.
        /// </summary>
        /// <value>
        /// The total customer reviews.
        /// </value>
        [DataMember]
        public int TotalCustomerReviews { get; set; }

        /// <summary>
        /// Gets or sets the total users.
        /// </summary>
        /// <value>
        /// The total users.
        /// </value>
        [DataMember]
        public int TotalUsers { get; set; }

        /// <summary>
        /// Gets or sets the total services.
        /// </summary>
        /// <value>
        /// The total services.
        /// </value>
        [DataMember]
        public int TotalServices { get; set; }

        /// <summary>
        /// Gets or sets the total payments.
        /// </summary>
        /// <value>
        /// The total payments.
        /// </value>
        [DataMember]
        public double TotalPayments { get; set; }
    }
}
