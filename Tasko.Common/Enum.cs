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
            OrderPending = 1,
            OrderAccepted = 2,
            OrderConfirmed = 3,
            OrderCancelled = 4,
            OrderWorkCompleted = 5,
            OrderCompleted = 6,
            OrderMissed = 7,
            OrderRejected = 8
        }
    }
}
