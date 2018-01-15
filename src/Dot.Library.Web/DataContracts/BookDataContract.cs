using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class BookDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ImgURL { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public List<AuthorDataContract> Authors { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
