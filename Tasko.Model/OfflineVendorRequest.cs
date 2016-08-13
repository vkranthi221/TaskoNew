using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class OfflineVendorRequest
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerPhone { get; set; }

        [DataMember]
        public string RequestedServiceId { get; set; }

        [DataMember]
        public string RequestedServiceName { get; set; }

    }
}
