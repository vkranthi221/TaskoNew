using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tasko.Model
{
    [CollectionDataContract]
    public class VendorList: List<Vendor>
    {

    }
}
