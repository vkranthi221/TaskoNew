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
    public class ServiceOverview
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [DataMember]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>
        /// The name of the service.
        /// </value>
        [DataMember]
        public string ServiceName { get; set; }

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
        /// gets or sets biggest payment
        /// </summary>
        /// <value>
        /// Biggest payment
        /// </value>
        [DataMember]
        public decimal BiggestPayment { get; set; }

        /// <summary>
        /// Gets or sets the Monthly payments
        /// </summary>
        /// <value>
        /// Monthly Payments
        /// </value>
        [DataMember]
        public decimal MonthlyPayments { get; set; }
    }
}
