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
            VendorDocumentId,
            StateId,
            CityId
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

        public enum DocumentProofs
        {
            None = 0,
            AadharCard = 1,
            DrivingLicense = 2,
            VoterID = 3,
            Passport = 4,
            BankPassbook = 5,
            PanCard = 6,
        }
    }
}
