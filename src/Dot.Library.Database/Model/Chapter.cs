using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    public class Chapter
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public List<Chapter> SubChapters { get; set; }
    }
}
