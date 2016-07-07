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
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        [DataMember]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the base rate.
        /// </summary>
        /// <value>
        /// The base rate.
        /// </value>
        [DataMember]
        public double BaseRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is vendor live].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is vendor live]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsVendorLive { get; set; }

        /// <summary>
        /// Gets or sets the no of employees.
        /// </summary>
        /// <value>
        /// The no of employees.
        /// </value>
        [DataMember]
        public int NoOfEmployees { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is vendor verified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is vendor verified]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsVendorVerified { get; set; }

        /// <summary>
        /// Gets or sets the time spent on application.
        /// </summary>
        /// <value>
        /// The time spent on application.
        /// </value>
        //[DataMember]
        ////public string TimeSpentOnApp { get; set; }

        /// <summary>
        /// Gets or sets the active time per day.
        /// </summary>
        /// <value>
        /// The active time per day.
        /// </value>
        //[DataMember]
        ////public string ActiveTimePerDay { get; set; }

        /// <summary>
        /// Gets or sets the data consumption.
        /// </summary>
        /// <value>
        /// The data consumption.
        /// </value>
        //[DataMember]
        //public int DataConsumption { get; set; }

        /// <summary>
        /// Gets or sets the calls to customer care.
        /// </summary>
        /// <value>
        /// The calls to customer care.
        /// </value>
        //[DataMember]
        //public int CallsToCustomerCare { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [DataMember]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the vendor details.
        /// </summary>
        /// <value>
        /// The Vendor Details.
        /// </value>
        [DataMember]
        public VendorDetails VendorDetails { get; set; }
        
        /// <summary>
        /// Gets or sets the address details.
        /// </summary>
        /// <value>
        /// The Address Details.
        /// </value>
        [DataMember]
        public AddressInfo AddressDetails { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The Password.
        /// </value>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Vendor photo
        /// </summary>
        /// <value>
        /// The Vendor photo.
        /// </value>
        [DataMember]
        public byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets the VendorServices
        /// </summary>
        /// <value>
        /// The VendorServices.
        /// </value>
        [DataMember]
        public List<ServicesForVendor> VendorServices { get; set; }

    }
}
