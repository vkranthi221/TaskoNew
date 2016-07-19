using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    /// <summary>
    /// GCM User Class
    /// </summary>
    [DataContract]
    public class GcmUser
    {
        [DataMember]
        public string GcmId { get; set; }

        [DataMember]
        public string GcmRegId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}
