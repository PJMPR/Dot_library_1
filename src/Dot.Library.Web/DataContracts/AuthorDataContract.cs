using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class AuthorDataContract
    {
        [DataModel]
        public int ID { get; set; }

        [DataModel]
        public string Name { get; set; }

        [DataModel]
        public string Surname { get; set; }

        [DataModel]
        public List<AuthorBooksDataContract> publishedBooks { get; set; }
    }
}