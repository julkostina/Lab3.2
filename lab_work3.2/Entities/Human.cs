using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_work3._2.Entities.Interfaces;

namespace lab_work3._2.Entities
{
    public class Human:IHuman
    {
        string firstName;
        string lastName;
        string passport;
        public virtual  string Activity()
        {
            return "I do some activity";
        }
        public  virtual string Cycling()
        {
            return "I cannot cycling";
        }
        public string Name { get { return firstName; } protected set { firstName = value; } }
        public string Surname { get { return lastName; } protected set { lastName = value; } }
        public string Passport { get { return passport; }protected set { passport = value; } }
        public Human(string firstName, string lastName, string passport)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
        }
    }
}
