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
        public int Id;

        [DataMember]
        public string Name;
    }
}
