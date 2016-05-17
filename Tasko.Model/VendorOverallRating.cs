using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class VendorOverallRating
    {
        [DataMember]
        public decimal OverAllRating { get; set; }

        [DataMember]
        public decimal ServiceQuality { get; set; }

        [DataMember]
        public decimal Punctuality { get; set; }

        [DataMember]
        public decimal Courtesy { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}
