using lab_work3._2.Entities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work3._2.Entities
{
    public class Student : Human
    {
        int height { get; set; }
        int weight { get; set; }
        string stCard { get; set; }
        public int Weight { get { return weight; } }
        public int Height { get { return height; } }
        public string StudentCard { get { return stCard; } }
        public override string Activity()
        {
            return "I study in university";
        }
        public override string Cycling()
        {
            return "I don't like cycling";
        }
        public static ArrayList StudentsWithIdealWeight(ref ArrayList list)
        {
            var res = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType()==typeof(Student))
                {
                    {
                        Student st = (Student)list[i];

                        if ((st.Height - 110) == (st.Weight))
                        {
                            res.Add(list[i]);

                        }
                    }
                }
            }
                return res; 
        }
        public override string ToString()
        {
            return $"  Student {Name} {Surname}\r\n{{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"{Name}\",\r\n    \"lastName\": \"{Surname}\",\r\n    \"height\": \"{height}\",\r\n    \"weight\": \"{weight}\",\r\n    \"stCard\": \"{stCard}\",\r\n    \"passport\": \"{Passport}\"\r\n}}";
        }
        public Student(string firstName, string lastName, int height, int weight, string passport, string stCard) : base(firstName, lastName, passport)
        {
            this.Name = firstName;
            this.Surname = lastName;
            this.stCard = stCard;
            this.height = height;
            this.weight = weight;
            this.Passport = passport;
        }
    }
}
