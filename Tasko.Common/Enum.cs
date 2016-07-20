using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Common
{
    public static class TaskoEnum
    {
        public enum IdType
        {
            CustomerId,
            VendorId,
            UserId,
            ServiceId,
            ParentServiceId,
            VendorServiceId,
            VendorAddressId,
            AuthCode,
            SourceAddressId,
            DestinationAddressId,
            AddressId,
            TokenCode,
        }
    }
}
