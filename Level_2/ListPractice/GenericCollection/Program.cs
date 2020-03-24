/*
 * Дана коллекция List<T> требуется подсчитать сколько раз каждый элемент встречается в данной коллекции.
 * а) для целых чисел;
 * б) *для обобщенной коллекции;
 * в) **используя Linq
 */

using System;
using System.Collections.Generic;

namespace CollectionLearning
{
    class Program
    {
        // Обобщенный метод обработки входной коллекции типа IDictionary<T, int>. Входной аргумент - обобщенная коллекция типа ICollection<T>.
        // Словарь Dictionary<T, int> uniques используется для хранения отобранных значений типа T и количества повторений <int>.
        // Словарь Dictionary<T, bool> found используется для проверки, находится ли текущий элемент коллекции в отобранном словаре.
        static IDictionary<T, int> GetUniques<T>(ICollection<T> list)
        {
            Dictionary<T, int> uniques = new Dictionary<T, int>();
            Dictionary<T, bool> found = new Dictionary<T, bool>();

            foreach (T val in list)
            {
                if (!found.ContainsKey(val))
                {
                    found[val] = true;
                    uniques.Add(val, 0);
                }

                if (found.ContainsKey(val))
                {
                    uniques[val] += 1;
                }
            }

            return uniques;
        }

        static void Main(string[] args)
        {
            List<int> myIntList = new List<int>() { 1, 2, 3, 3, 7, 2, 1, 7, 3, 8, 0 };
            List<string> myStringList = new List<string>() { "abc", "bca", "bca", "bca", "wsa", "abc", "qwe", "obj", "zzz", "zzz", "zzz" };

            Dictionary<int, int> unique_int = new Dictionary<int, int>(GetUniques<int>(myIntList));
            Dictionary<string, int> unique_string = new Dictionary<string, int>(GetUniques<string>(myStringList));

            Console.WriteLine("Обобщенная коллекция типа <int>: ");
            foreach (var i in unique_int) Console.WriteLine(i);

            Console.WriteLine("\nОбобщенная коллекция типа <string>: ");
            foreach (var i in unique_string) Console.WriteLine(i);
        }
    }
}
