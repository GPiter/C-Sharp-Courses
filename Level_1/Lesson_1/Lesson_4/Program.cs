using System;

namespace Lesson_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int t;

            // 1 способ
            t = a;
            a = b;
            b = t;
            Console.WriteLine(a);
            Console.WriteLine(b);

            // 2 способ
            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);

        }
    }
}
