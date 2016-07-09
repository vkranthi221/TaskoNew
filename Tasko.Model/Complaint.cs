using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// Complaint Class
    /// </summary>
    [DataContract]
    public class Complaint
    {
        /// <summary>
        /// Gets or sets the complaint identifier.
        /// </summary>
        /// <value>
        /// The complaint identifier.
        /// </value>
        [DataMember]
        public string ComplaintId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Reply { get; set; }

        public string VendorName { get; set; }

        public string CustomerName { get; set; }

        public string LoggedDate { get; set; }

        public string DueDate { get; set; }

        public int ComplaintStatus { get; set; }

        public string CustomerEmailAddress { get; set; }
    }
}
