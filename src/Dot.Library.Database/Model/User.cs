using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    class User
    {
        private int id;
        private string name;
        private string login;
        private string pass;
        private string surname;
        private string adress;
        private string postalCode;
        private List<int> userRent = new List<int>();

        public global::System.String Name { get => name; set => name = value; }
        public global::System.String Login { get => login; set => login = value; }
        public global::System.String Pass { get => pass; set => pass = value; }
        public global::System.String Surname { get => surname; set => surname = value; }
        public global::System.String Adress { get => adress; set => adress = value; }
        public global::System.String PostalCode { get => postalCode; set => postalCode = value; }
        public global::System.Int32 Id { get => id;  }
        public global::System.Int32 Rent { get => rent; set => rent = value; }
        public List<global::System.Int32> UserRent { get => userRent; set => userRent = value; }
    }
}
