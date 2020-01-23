/* Задание 2_3
 * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
положительных чисел;
 */

using System;

namespace Lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numb = 1;
            int count = 0;
            int res = 0;

            Console.WriteLine("Вводите числа, для выхода введите 0.");

            while (numb != 0)
            {
                Console.Write("> ");
                numb = Convert.ToInt32(Console.ReadLine());
                if (numb % 2 != 0 && numb > 0)
                {
                    res += numb;
                    ++count;
                }
            }

            Console.WriteLine("Сумма: " + res);
            Console.WriteLine("Количество нечетных чисел: " + count);
        }
    }
}
