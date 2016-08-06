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
        public enum OrderStatus
        {
            CustomerRequested = 1,
            VendorAccepted = 2,
            VendorRejected = 3,
            CustomerAccepted = 4,
            OrderCompleted = 5,
            CustomerCancelled = 6,
            VendorCancelled = 7,
        }
    }
}
