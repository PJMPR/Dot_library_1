using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Dot.Library.Database.Model
{
    [DataContract(IsReference=true)]
    public class Author
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public List<Book> publishedBooks { get; set; }
    }
}