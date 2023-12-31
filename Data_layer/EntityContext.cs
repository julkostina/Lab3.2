﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer
{
    public class EntityContext<T>
    {
        //set of methods for creating/opening a database(DB) file, updating, closing, and deleting a file.
        public EntityContext() { }
        public static string CreateFile(string name)
        {
           return AppDomain.CurrentDomain.BaseDirectory + name;
        }
        public static string ReadFile(string FilePath)
        {
            using(StreamReader streamReader = new(FilePath, System.Text.Encoding.Default))
            {
                return streamReader.ReadToEnd();  // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }
        public static void WriteFile(T data, string FilePath)
        {
            using(StreamWriter streamWriter = new (FilePath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(data);
            }
        }
        public static void DeleteFile(string FilePath)
        {
            File.Delete(FilePath);
        }
    }
}
