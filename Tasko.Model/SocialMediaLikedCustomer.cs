using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class SocialMediaLikedCustomer
    {

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string PostId { get; set; }

        [DataMember]
        public string CustomerId { get; set; }
    }
}
