using System;
using System.Collections.Generic;
namespace Dot.Library.Database.Model
{
    public class BookReservation
    {
        public int ID { get; set; }
        public User user { get; set; }
        public DateTime date { get; set; }
        public List<Book> reservatedBooks { get; set; }
    }
}
