﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Tasko.Model;

namespace Tasko
{
    [DataContract]
    [KnownType(typeof(User))]
    [KnownType(typeof(Order))]
    [KnownType(typeof(Vendor))]
    [KnownType(typeof(VendorService))]
    [KnownType(typeof(List<VendorService>))]
    public class Response
    {
        [DataMember]
        public bool Error { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public object Data { get; set; }
    }
}