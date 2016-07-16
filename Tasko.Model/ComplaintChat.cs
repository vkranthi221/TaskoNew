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
    public class ComplaintChat
    {
        [DataMember]
        public string ChatId { get; set; }

        [DataMember]
        public string ComplaintId { get; set; }

        [DataMember]
        public string ChatDate { get; set; }

        [DataMember]
        public string ChatContent { get; set; }
    }
}
