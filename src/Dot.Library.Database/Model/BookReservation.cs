using System;
using System.Collections.Generic;
namespace Dot.Library.Database.Model
{
    public class BookReservation
    {
        public int ID { get; set; }
        public string user { get; set; }
        public List<Book> reservatedBooks { get; set; }
    }
}
