/* Задание 3_2
 * а) Из файла вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется
 * подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран;
 * б) Добавить обработку исключительной исключений на то, что в файле могут быть не
 * корректные данные. При возникновении ошибки вывести сообщение.
 */

using System;
using System.IO;

namespace L_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader str = new StreamReader("input.txt");

            int numb = 0, sum = 0;

            do
            {
                try
                {
                    numb = int.Parse(str.ReadLine());
                    if (numb % 2 != 0) sum += numb;
                    Console.WriteLine(numb);
                }
                
                catch
                {
                    Console.WriteLine("Неверный формат данных!");
                }
                   
            } while (numb != 0);

            str.Close();

            Console.WriteLine("\nСумма: " + sum);
        }
    }
}
