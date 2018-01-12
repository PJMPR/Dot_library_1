using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class UserDataContract
    {
        [DataMember]
        public int id { set; get; }
        [DataMember]
        public string name { set; get; }
        [DataMember]
        public string login { set; get; }
        [DataMember]
        public string pass { set; get; }
        [DataMember]
        public string surname { set; get; }
        [DataMember]
        public string adress { set; get; }
        [DataMember]
        public string postalCode { set; get; }
    }
}