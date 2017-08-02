using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class SocialMediaPost
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int Views { get; set; }

        [DataMember]
        public List<string> ImageUrls { get; set; }

        [DataMember]
        public string VendorId { get; set; }

        [DataMember]
        public int Likes { get; set; }

        [DataMember]
        public string PostedDate { get; set; }

        [DataMember]
        public string VendorName { get; set; }
    }
}
