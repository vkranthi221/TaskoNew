using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tasko.Model
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public string OrderId { get; set; }        

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string VendorServiceId { get; set; }

        [DataMember]
        public string VendorId { get; set; }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public string ServiceId { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string OrderStatusId { get; set; }

        [DataMember]
        public string OrderStatus { get; set; }

        [DataMember]
        public DateTime RequestedDate { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}
