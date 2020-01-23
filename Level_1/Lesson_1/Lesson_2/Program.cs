/* Задание 1-2.
 * Ввести вес и рост человека. Расчитать и вывести индекс массы тела по формуле I=m/(h*h);
 * 
 * */

using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double Index;

            Console.WriteLine("Enter your height:");
            double height = Convert.ToDouble( Console.ReadLine() );
            Console.WriteLine("Enter your weight:");
            double weight = Convert.ToDouble( Console.ReadLine() );

            Index = weight / (height * height);
            Console.WriteLine("Index: {0:E}", Index);

        }
    }
}
