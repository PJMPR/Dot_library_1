using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class AuthorBooksDataContract
    {
        [DataModel]
        public int ID { get; set; }

        [DataModel]
        public string ImgURL { get; set; }

        [DataModel]
        public string Title { get; set; }

        [DataModel]
        public string Publisher { get; set; }

        [DataModel]
        public string Description { get; set; }

        [DataModel]
        public int Quantity { get; set; }
    }
}