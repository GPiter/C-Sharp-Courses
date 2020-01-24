/* Задание 5-3
 * Для двух строк написать метод, определяющий, является ли одна строка перестановкой
 * другой. Регистр можно не учитывать.
 * 
 */

using System;

namespace Hw_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str_1 = "Вертеп";
            string str_2 = "петрев";
            int result;

            char[] str2_array = str_2.ToCharArray();
            Array.Reverse(str2_array);

            string str_2_reverse = new string(str2_array);

            result = String.Compare(str_1, str_2_reverse, true);    // Сравниваем без учета регистра

            if (result == 0)
                Console.WriteLine("Строка 2 является перестановкой первой");

            else Console.WriteLine("Строка 2 НЕ является перестановкой первой");

        }
    }
}
