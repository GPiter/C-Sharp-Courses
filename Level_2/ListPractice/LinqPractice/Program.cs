/*
 * Дана коллекция List<T> требуется подсчитать сколько раз каждый элемент встречается в данной коллекции.
 * а) для целых чисел;
 * б) *для обобщенной коллекции;
 * в) **используя Linq
 */

using System;
using System.Collections.Generic;
using System.Linq;


namespace CollectionLearning
{

    class Program
    {
        static void Main(string[] args)
        {
            List<int> myIntList = new List<int>() { 1, 2, 3, 3, 7, 2, 1, 7, 3, 8, 0 };

            List<int> buffer = new List<int>(); // Список с отобранными элементами

            for (int i = 0; i < myIntList.Count; i++)
            {
                if (!buffer.Contains(myIntList[i]))
                    buffer.Add(myIntList[i]);
            }

            foreach(int i in buffer)
            {
                Console.WriteLine(myIntList.Where(x => x.Equals(i)).Count());
            }
          
        }
    }
}
