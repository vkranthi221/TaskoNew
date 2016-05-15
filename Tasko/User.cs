using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tasko
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string PassWord { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }
    }
}
