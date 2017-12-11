using System;

using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
public class Category
    {

       
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Category> SubCategories { get; set; }
        public Category Parent { get; set; }

    }
}
