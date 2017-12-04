using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    class User
    {
        private int id { get; }
        private string name { set; get; }
        private string login { set; get; }
        private string pass { set; get; }
        private string surname { set; get; }
        private string adress { set; get; }
        private string postalCode { set; get; }

        public List<Int32> UserRent { get; set; } = new List<int>();
    }
}
