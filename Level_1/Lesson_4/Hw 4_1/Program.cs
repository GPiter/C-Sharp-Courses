/* Задание 4-1
 * Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые
 * значения от –10 000 до 10 000 включительно. Написать программу, позволяющую найти и вывести
 * количество пар элементов массива, в которых хотя бы одно число делится на 3. В данной задаче
 * под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти
 * элементов: 6; 2; 9; –3; 6 – ответ: 4.
 * 
 */

using System;

namespace Hw_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array_a = new int[20];
            int count = 0;

            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
                array_a[i] = rnd.Next(-100, 100);

            Console.WriteLine("Сгенерированный массив: ");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(array_a[i] + " ");
            }

            Console.WriteLine("\nНайденные пары: ");
            for (int i = 1; i < 20; i++)
            {
                if (array_a[i] % 3 == 0 || array_a[i - 1] % 3 == 0)
                {
                    Console.WriteLine(array_a[i - 1] + " " + array_a[i]);
                    count++;
                }
            }

            Console.WriteLine("\nКоличество пар кратных 3: " + count);

        }
    }
}
