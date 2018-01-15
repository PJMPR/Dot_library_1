using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class AuthorDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public List<BookDataContract> publishedBooks { get; set; }
    }
}