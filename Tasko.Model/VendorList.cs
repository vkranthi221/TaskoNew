using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tasko.Model
{
    /// <summary>
    /// Vendor List
    /// </summary>
    [CollectionDataContract]
    public class VendorList : List<Vendor>
    {

    }
}
