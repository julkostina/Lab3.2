using Data_layer;
using System.Collections.Generic;
using System;
using lab_work3._2.Entities.Interfaces;
using lab_work3._2.Entities;
using System.Collections;

namespace lab_work3._2
{
    public class EntityService<T> where T : Human
    {
        public static void Add(T data, string FilePath, ArrayList list)
        {
            EntityContext<T>.WriteFile(data,FilePath);
            list.Add(data);
        }
        public static void Remove(int index,string FilePath, ArrayList list)
        {
            list.Remove(list[index]);
            EntityContext<T>.DeleteFile(FilePath);
            EntityContext<T>.CreateFile(FilePath);
            foreach (T item in list)
            {
                EntityContext<T>.WriteFile(item, FilePath);
            }
        }
        public static T Get(int index, ArrayList list)
        {
            if(list.Count == 0 || index < 0 || index > list.Count)
            {
                throw new ArgumentException();
            }

            return (T)list[index];
        }

        public static bool SearchByLastName(string lastName, ArrayList list, out int index)
        {
            index = 0;
            bool res = false;

            for (int i = 0; i < list.Count; i++)
            {
                Human human = (Human)list[i];
                if (lastName == human.Surname) { res = true; index = i; }

            }
            return res;
        }
        

        //        methods to add, remove, and retrieve
        //information about a specified entity.To perform the necessary operations, data must
        //be received either after interaction with the EntityContext class (for example, read

        //all information from a file), or after it is entered by the user in the Menu class. The
        //EntityService class should not directly work with files and interact with the end user
        //through the console.Using the Console and Stream classes with their derivatives in
        //this class is prohibited.
    }
}
