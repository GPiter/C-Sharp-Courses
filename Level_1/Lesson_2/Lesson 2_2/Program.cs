/* Задание 2_2
 * Написать метод подсчета количества цифр числа
 */

using System;

namespace Lesson_2_2
{
    class Program
    {
        static int Calc_Numbers(string numb)
        {
            int res = Convert.ToInt32(numb);
            int count = 0;

            while (res != 0)
            {
                count++;
                res /= 10;
            }

            return count;
        }

        static void Main(string[] args)
        {
            string numb = "15256";
            Console.WriteLine(Calc_Numbers(numb));
        }
    }
}
