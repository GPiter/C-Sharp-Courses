/* Задание 5_1
 * Создать программу, которая будет проверять корректность ввода логина. Корректным логином
 * будет строка от 2х до 10ти символов, содержащая только буквы и цифры, и при этом цифра не
 * может быть первой.
 * а) без использования регулярных выражений?
 * б) **с использованием регулярных выражений.
 * 
 */

using System;
using System.Text.RegularExpressions;


namespace Hw_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*-------------------------- Задание 1 --------------------------------*/

            Console.WriteLine("Проверка авторизации с помощью методов string");

            string login = "Peter1G";
            string input_login = "Peter1G";

            char[] login_ch = input_login.ToCharArray();

            bool isMatch = (input_login == login);    // Совпадают ли логины

            bool isCorrectLength = (input_login.Length >= 2) && (input_login.Length <= 10); // Длина пароля от 2 до 10 символов

            bool isDigit = char.IsDigit(login_ch[0]);   // Первый символ - не цифра

            bool isCorrectFormat = false;   // Содержит только буквы и цифры
            foreach (char i in login_ch)
            {
                if (char.IsLetter(i) || char.IsDigit(i))
                    isCorrectFormat = true;
                else
                {
                    isCorrectFormat = false;
                    break;
                }
            }

            if (!isMatch)
                Console.WriteLine("Введен неверный логин!");
            else
            {
                if (isMatch && isCorrectLength && !isDigit && isCorrectFormat)
                    Console.WriteLine("Авторизация прошла успешно!");
                else Console.WriteLine("Логин имеет неверный формат!");
            }

            /*-------------------------- Задание 2 --------------------------------*/

            Console.WriteLine("\n\n\nПроверка авторизации с помощью регулярного выражения");
            // Регулярное выражение:
            // ^ - начало строки; $ - конец строки
            // [A-Za-z]{1} - первый символ - латинская буква
            // [a-zA-Z0-9]{1,9} - со 2 по 10 символы могут быть только буквы и цифры

            string pattern = @"^[A-Za-z]{1}[a-zA-Z0-9]{1,9}$";

            if (!isMatch)
                Console.WriteLine("Введен неверный логин!");
            else
            {
                if (Regex.IsMatch(input_login, pattern))
                    Console.WriteLine("Авторизация прошла успешно!");
                else Console.WriteLine("Логин имеет неверный формат!");
            }

        }
    }
}
