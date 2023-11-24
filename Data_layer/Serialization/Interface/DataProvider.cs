using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Serialization.Interface
{
    public interface DataProvider<T>
    {
        void Write(string file, T[] data);
        T[] Read(string file);
    }
}

