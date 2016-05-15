using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Tasko.Model
{
    /// <summary>
    /// Itis the model class for both vendor and customer. 
    /// </summary>
    [DataContract]
    public class Vendor
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public double BaseRate { get; set; }

        [DataMember]
        public bool IsVendorLive { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int NoOfEmployees { get; set; }

        [DataMember]
        public bool IsVendorVerified { get; set; }

        [DataMember]
        public DateTime TimeSpentOnApp { get; set; }

        [DataMember]
        public DateTime ActiveTimePerDay { get; set; }

        [DataMember]
        public int DataConsumption { get; set; }

        [DataMember]
        public int CallsToCustomerCare { get; set; }
    }
}
