/*
 * Дана коллекция List<T> требуется подсчитать сколько раз каждый элемент встречается в данной коллекции.
 * а) для целых чисел;
 * б) *для обобщенной коллекции;
 * в) **используя Linq
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            /* --- Решение 1 - с помощью двух коллекций List --- 
             * 
            List<int> myIntList = new List<int>() { 1, 2, 3, 3, 7, 2, 1, 7, 3, 8, 0 };
            List<int> buffer = new List<int>();
            int count;
            for (int i = 0; i < myIntList.Count; i++)
            {
                count = 0;
                foreach (int j in myIntList)
                {
                    if (myIntList[i] == j) count++;
                }
                buffer.Add(count);
            }

            for (int i = 0; i < myIntList.Count; i++)
            {
                Console.WriteLine(myIntList[i] + " - " + buffer[i]);
            }
            */

            /* --- Решение 2 - с помощью коллекций List и Dictionary --- */
               
            List<int> myIntList = new List<int>() { 1, 2, 3, 3, 7, 2, 1, 7, 3, 8, 0 };
            List<int> buffer = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int count, index;

            for (int i = 0; i < myIntList.Count; i++)
            {
                index = myIntList[i];
                count = 0;

                // Проверка на индекс
                if (buffer.Contains(index)) continue;
                else
                {
                    buffer.Add(index);
                    foreach (int j in myIntList)
                    {
                        if (myIntList[i] == j) count++;
                    }

                    dict[index] = count;
                }
            }

            foreach (var i in dict)
            {
                Console.WriteLine(i);
            }      

        }
    }
}
