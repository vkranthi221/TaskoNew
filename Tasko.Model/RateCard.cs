using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class RateCard
    {
        [DataMember]
        public string ServiceId { get; set; }

        [DataMember]
        public string CityId { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string CityName { get; set; }
    }
}
