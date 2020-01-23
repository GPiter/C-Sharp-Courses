/* Задание 1-1.
 * Написать программу “Анкета”. Последовательно задаются вопросы (имя, фамилия, возраст,
 * рост, вес). В результате вся информация выводится в одну строчку.
 * а) используя склеивание;
 * б) используя форматированный вывод.
 * 
 * */

using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, surname, age, height, weight;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter your surname:");
            surname = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            age = Console.ReadLine();

            Console.WriteLine("Enter your height:");
            height = Console.ReadLine();

            Console.WriteLine("Enter your weight:");
            weight = Console.ReadLine();

            Console.WriteLine(name + " " + surname + " " + age + " " + height + " " + weight);
        }
    }
}
