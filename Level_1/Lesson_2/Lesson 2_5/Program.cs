/* Задание 2_5
 * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
 * массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
 * б) Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
 *  
 */

using System;

namespace Lesson_2_5
{
    class Program
    {
        static void Classification(double index)
        {
            if (index <= 16)                        Console.WriteLine("Выраженный дефицит массы тела");
            if (index > 16   && index <= 18.5)      Console.WriteLine("Недостаточная (дефицит) масса тела");
            if (index > 18.5 && index <= 24.99)     Console.WriteLine("Норма");
            if (index >= 25  && index <= 30)        Console.WriteLine("Избыточная масса тела (предожирение)");
            if (index > 30   && index <= 35)        Console.WriteLine("Ожирение");
            if (index > 35   && index <= 40)        Console.WriteLine("Ожирение резкое");
            if (index > 40)                         Console.WriteLine("Очень резкое ожирение");
        }

        static void NormalizeMass(double index)
        {
            double minNorma = 18.5;
            double maxNorma = 24.99;
            double delta;

            if (index < minNorma)
            {
                delta = minNorma - index;
                Console.WriteLine("Рекомендации компьютера: ");
                Console.WriteLine("Вам необходимо набрать " + delta + "кг.");
            }

            if (index > maxNorma)
            {
                delta = index - maxNorma;
                Console.WriteLine("Рекомендации компьютера: ");
                Console.WriteLine("Вам необходимо сбросить " + delta + "кг.");
            }

        }

        static void Main(string[] args)
        {
            double index, m, h;

            Console.Write("Введите массу тела: > ");
            m = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите свой рост (см): > ");
            h = Convert.ToDouble(Console.ReadLine()) / 100;

            index = m / (h * h);
            Console.WriteLine("Индекс массы тела: " + index);

            Console.Write("Результат: ");
            Classification(index);
            NormalizeMass(index);

            Console.ReadKey();
        }
    }
}
