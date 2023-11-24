using lab_work3._2.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace lab_work3._2.Entities
{
    public class Librarian : Human
    {
        public override string Activity()
        {
            return "I like reading";
        }
        public override string Cycling()
        {
            return "I like cycling";
        }
        public override string ToString()
        {
            return $" Librarian {Name} {Surname}\r\n{{\r\n    \"entity\": \"librarian\",\r\n    \"firstName\": \"{Name}\",\r\n    \"lastName\": \"{Surname}\",\r\n     \"passport\": \"{Passport}\"\r\n}}";
        }
        public Librarian(string firstName, string lastName, string passport) : base(firstName, lastName, passport)
        {
            this.Name = firstName;
            this.Surname = lastName;
            this.Passport = passport;
        }

    }
}
