using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.IO;
using Data_layer.Serialization.Interface;

namespace Bussiness_layer.Serialization
{
    public class Custom<T>: DataProvider<T>
    {
        public void Write(string file,T[] data)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(file+".dat", FileMode.OpenOrCreate))
            {
                    formatter.Serialize(fileStream, data);
            }
        }
        public T[] Read(string file)
        {
            IFormatter formatter = new BinaryFormatter();
            T[] deserializedObj;
            using (Stream fileStream = new FileStream(file + ".dat", FileMode.Open))
            {
                 deserializedObj = (T[])formatter.Deserialize(fileStream);
            }
            return deserializedObj;
        }


    } 
}

