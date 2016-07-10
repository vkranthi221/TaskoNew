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
    public class CustomerOverview
    {
        /// <summary>
        /// Gets or sets Total orders
        /// </summary>
        /// <value>
        /// Total orders
        /// </value>
        [DataMember]
        public int TotalOrders { get; set; }

        /// <summary>
        /// Gets or sets the weekly orders
        /// </summary>
        /// <value>
        /// Weekly orders
        /// </value>
        [DataMember]
        public int WeeklyOrders { get; set; }

        /// <summary>
        /// Gets or sets the today orders
        /// </summary>
        /// <value>
        /// Today Orders
        /// </value>
        [DataMember]
        public int TodayOrders { get; set; }

        /// <summary>
        /// Gets or sets the total payments
        /// </summary>
        /// <value>
        /// Total Payments
        /// </value>
        [DataMember]
        public decimal TotalPayments { get; set; }

        /// <summary>
        /// Gets or sets the Weekly payments
        /// </summary>
        /// <value>
        /// Weekly Payments
        /// </value>
        [DataMember]
        public decimal WeeklyPayments { get; set; }

        /// <summary>
        /// gets or sets biggest payments
        /// </summary>
        /// <value>
        /// Biggest payments
        /// </value>
        [DataMember]
        public decimal BiggestPayments { get; set; }

        /// <summary>
        /// Gets or sets the Monthly payments
        /// </summary>
        /// <value>
        /// Monthly Payments
        /// </value>
        [DataMember]
        public decimal MonthlyPayments { get; set; }

        /// <summary>
        /// sets or gets customer name
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
