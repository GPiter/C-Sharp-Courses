using System;

namespace Lesson_1_5
{
    class Program
    {
        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);

        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 5;
            string msg = "Hello World!";
            Print(msg, x, y);
        }
    }
}
