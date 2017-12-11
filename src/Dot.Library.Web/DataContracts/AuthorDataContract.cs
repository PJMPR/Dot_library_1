using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    public class AuthorDataContract
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<AuthorBooksDataContract> publishedBooks { get; set; }
    }
}