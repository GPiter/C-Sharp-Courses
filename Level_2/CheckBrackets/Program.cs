/* Задание 4-3
 * С клавиатуры вводится скобочное выражение. Требуется проверить
 * правильность расстановки скобок.(Использовать обобщенную коллекцию Stack<char>)
 *
 */
using System;
using System.Collections.Generic;

namespace CheckBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();

            char input = 'a';
            char output;

            Console.WriteLine("Проверка скобочного выражения \n1. Вводить скобки посимвольно \n2. Для выхода и проверки ввести 0");

            while (input != '0')
            {
                try
                {
                    input = char.Parse(Console.ReadLine());
                }

                catch(FormatException)
                {
                    Console.WriteLine("Неверный формат входных данных! Введите символ!");
                    continue;
                }

                if (input == '(')
                {
                    brackets.Push(input);
                }

                if (input == ')')
                {
                    if (brackets.Count == 0)
                    {
                        Console.WriteLine("Неверное начало выражения! Начните с )");
                        continue;
                    }

                    if ( brackets.Peek() == '(' ) output = brackets.Pop();
                }
            }

            if (brackets.Count == 0) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
