using Data_layer.Serialization.Interface;
using System;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace Bussiness_layer.Serialization
{
    internal class JSON<T>: DataProvider<T> 
    {
        public  void Write(string file,T[] data)
        {
            using (FileStream fileStream = new FileStream(file + ".json", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T[]));
                dataContractJsonSerializer.WriteObject(fileStream, data);
            }
        }
        public  T[] Read(string file)
        {
            using (FileStream fileStream = new FileStream(file + ".json", FileMode.Open))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T[]));
                return (T[])dataContractJsonSerializer.ReadObject(fileStream);
            }
        }
       
    }
}
