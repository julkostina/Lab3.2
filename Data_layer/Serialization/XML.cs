using Data_layer.Serialization.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bussiness_layer.Serialization
{
    public class XML<T> : DataProvider<T>
    {
        public void Write(string file,T[] data)

        {
            using (FileStream fileStream = new FileStream(file + ".xml", FileMode.OpenOrCreate))

            {
                XmlSerializer formatter = new XmlSerializer(typeof(T[]));
                formatter.Serialize(fileStream, data);
            }
        }

        public T[] Read(string file)
        {
            T[] deserializedObj;
            using (FileStream fileStream = new FileStream(file + ".xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
                deserializedObj= (T[])xmlSerializer.Deserialize(fileStream);
            }
            return deserializedObj;
        }
//        public static void writeXML(List<T> data, string file)

//        {
//            using (FileStream fs = new FileStream(file + ".xml", FileMode.OpenOrCreate))
//            {
//                XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
//                formatter.Serialize(fs, data);
//            }

//        }
//        public static List<T> readXML(string file)

//        {
//            List<T> deserializedObjects = new List<T>();
//            using (FileStream fs = new FileStream(file + ".xml", FileMode.Open))
//            {
//                XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
//                deserializedObjects = (List<T>)formatter.Deserialize(fs);
//            }
//            return deserializedObjects;
//        }

 

    }
}
