using System;
using System.Collections.Generic;
using System.Text;


namespace Dot.Library.Database.Model
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Book> PublishedBooks { get; set; }
    }

}

