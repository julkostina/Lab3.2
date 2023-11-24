using lab_work3._2.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work3._2.Entities
{
    public class SoftwareDeveloper : Human
    {
        public override string Activity()
        {
            return "I can code";
        }
        public override string Cycling()
        {
            return "I don't like cycling";
        }
        public override string ToString()
        {
            return $" Software developer {Name} {Surname}\r\n{{\r\n    \"entity\": \"software developer\",\r\n    \"firstName\": \"{Name}\",\r\n    \"lastName\": \"{Surname}\",\r\n     \"passport\": \"{Passport}\"\r\n}}";
        }
        public SoftwareDeveloper(string firstName, string lastName, string passport) : base(firstName, lastName, passport)
        {
            this.Name = firstName;
            this.Surname = lastName;
            this.Passport = passport;
        }
    }
}