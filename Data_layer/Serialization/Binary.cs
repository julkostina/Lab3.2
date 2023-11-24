using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Data_layer.Serialization.Interface;

namespace Bussiness_layer.Serialization
{
    public class Binary<T> : DataProvider<T>

    {
        public void Write(string file, T[] data)
        {
            using (FileStream fileStream = new (file + ".bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormarter = new ();
                binaryFormarter.Serialize(fileStream,data);
            }
        }
        public  T[] Read(string file)
        {
            T[] deserializedObject;
            using (FileStream fileStream = new (file + ".bin", FileMode.Open))
            {
                BinaryFormatter binaryFormater = new ();
                deserializedObject = (T[])binaryFormater.Deserialize(fileStream);
            }
            return deserializedObject;
        }
    }
}
