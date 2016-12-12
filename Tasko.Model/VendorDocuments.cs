using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasko.Model
{
    [DataContract]
    public class VendorDocuments
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string VendorId { get; set; }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public int PhotoIdProofId { get; set; }

        [DataMember]
        public string PhotoIdProofName { get; set; }

        [DataMember]
        public string PhotoIdProofNumber { get; set; }

        [DataMember]
        public int AddressProofId { get; set; }

        [DataMember]
        public string AddressProofName { get; set; }

        [DataMember]
        public string AddressProofNumber { get; set; }

        [DataMember]
        public int PendingDocumentId { get; set; }

        [DataMember]
        public string PendingDocumentName { get; set; }

        [DataMember]
        public bool IsPassportSizePhoto { get; set; }

        [DataMember]
        public bool IsRegistrationFeePaid { get; set; }

        [DataMember]
        public bool IsBackgroundVerificationInitiated { get; set; }
    }
}
