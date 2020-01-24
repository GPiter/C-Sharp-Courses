/* Задание 3_3
 * Описать класс дробей рациональных чисел, являющихся отношением двух целых чисел.
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать
 * программу, демонстрирующую все разработанные элементы класса.
 * 
 */

using System;

namespace L_3_3
{
    class Fractions
    {
        private int a, b;

        public Fractions()
        {
            a = 0;
            b = 1;
        }

        public Fractions(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        // Метод складывания дробей x и y
        public Fractions Sum(Fractions x, Fractions y)
        {
            Fractions result = new Fractions();
            result.a = x.a * y.b + y.a * x.b;
            result.b = x.b * y.b;
            return result;
        }

        // Метод вычитания дробей x и y
        public Fractions Sub(Fractions x, Fractions y)
        {
            Fractions result = new Fractions();
            result.a = x.a * y.b - y.a * x.b;
            result.b = x.b * y.b;
            return result;
        }

        public string ToString()
        {
            return a + "/" + b;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Fractions x = new Fractions(3, 5);
            Fractions y = new Fractions(4, 3);
            Fractions z = new Fractions();
            z = z.Sub(x, y);
            Console.WriteLine(z.ToString());
        }
    }
}
