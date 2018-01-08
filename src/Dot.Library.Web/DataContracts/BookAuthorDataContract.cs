using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    public class BookAuthorDataContract
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}