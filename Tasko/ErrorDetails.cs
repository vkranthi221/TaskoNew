using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Tasko
{
    [DataContract]
    [KnownType(typeof(FaultException))]
    public class ErrorDetails
    {
        
        [DataMember]
        public string Message;

        [DataMember]
        public string StackTrace;

    }
}