using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class MessageDetail
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerLocation { get; set; }

        [DataMember]
        public AddressInfo CustomerAddress { get; set; }

        [DataMember]
        public string CustomerDistance { get; set; }

        [DataMember]
        public string CustomerETA { get; set; }

        [DataMember]
        public int Orderstatus { get; set; }

        [DataMember]
        public string CustomerLatitude { get; set; }

        [DataMember]
        public string CustomerLongitude { get; set; }
      
        [DataMember]
        public string CustomerPhone { get; set; }
        
        [DataMember]
        public string VendorPhone { get; set; }

        [DataMember]
        public string ServiceName { get; set; }
    }
}
