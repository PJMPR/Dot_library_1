using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    public class AuthorBooksDataContract
    {
        public int ID { get; set; }
        public string ImgURL { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}