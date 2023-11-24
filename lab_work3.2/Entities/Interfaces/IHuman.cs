using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace lab_work3._2.Entities.Interfaces
{
    public interface  IHuman
    {
   
        public abstract string Activity();
        public abstract string Cycling();
    }
}
