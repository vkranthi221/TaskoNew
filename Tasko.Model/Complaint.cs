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

        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string LoggedDate { get; set; }

        [DataMember]
        public string DueDate { get; set; }

        [DataMember]
        public int ComplaintStatus { get; set; }

        [DataMember]
        public List<ComplaintChat> ComplaintChats { get; set; }

    }
}
