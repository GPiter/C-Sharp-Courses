/* Задание 2_1
 * Написать метод, возвращающий минимальное из трех чисел
 */

using System;

namespace Lesson_2_1
{
    class Program
    {
        static int Min(int a, int b, int c)
        {
            int min = a;
            min = min < b ? min : b;
            min = min < c ? min : c;
            return min;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Min(3, 1, 5));
        }
    }
}
