using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// Vendor Overview
    /// </summary>
    [DataContract]
    public class VendorOverview
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// Vendor Name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Orders Today.
        /// </summary>
        /// <value>
        /// Orders Today.
        /// </value>
        [DataMember]
        public int OrdersToday { get; set; }

        /// <summary>
        /// Gets or sets the Orders this week.
        /// </summary>
        /// <value>
        /// Orders this week.
        /// </value>
        [DataMember]
        public int OrdersThisWeek { get; set; }

        /// <summary>
        /// Gets or sets the total Orders.
        /// </summary>
        /// <value>
        /// Total Orders.
        /// </value>
        [DataMember]
        public int TotalOrders { get; set; }

        /// <summary>
        /// Gets or sets the total Order amount.
        /// </summary>
        /// <value>
        /// Total Order amount.
        /// </value>
        [DataMember]
        public decimal TotalOrderAmount { get; set; }

        [DataMember]
        public decimal WeeklyOrderAmount { get; set; }

        [DataMember]
        public decimal HighestOrderAmount { get; set; }

        [DataMember]
        public decimal AverageMonthlyAmount { get; set; }
    }
}
