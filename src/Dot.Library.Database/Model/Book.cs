using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Dot.Library.Database.Model
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ImgURL { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        public List<Author> Authors { get; set; }
        public string Description { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
