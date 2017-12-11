using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    public class Book
    {
        public int ID { get; set; }
        public string ImgURL { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public List<Author> Authors { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
