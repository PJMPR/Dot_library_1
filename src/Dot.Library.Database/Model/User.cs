using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    public class User
    {
        public int id { get; }
        public string name { set; get; }
        public string login { set; get; }
        public string pass { set; get; }
        public string surname { set; get; }
        public string adress { set; get; }
        public string postalCode { set; get; }

        public List<int> UserRent { get; set; } = new List<int>();
    }
}
