/* Задание 2_4 
 * Реализовать метод проверки логина и пароля. На вход подается логин и пароль. На выходе
 * истина, если прошел авторизацию, и ложь, если не прошел. Используя метод проверки логина и
 * пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его
 * дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками;
 * 
 */

using System;

namespace Lesson_2_4
{
    class Program
    {
        static bool CheckLogin(string user_login, string user_password)
        {
            string true_login = "admin";
            string true_password = "admin";
            return (user_login == true_login) && (user_password == true_password) ? true : false;
        }

        static void Main(string[] args)
        {
            int count = 0;

            do
            {
                Console.Write("Введите логин: > ");
                string user_login = Console.ReadLine();

                Console.Write("Введите пароль: > ");
                string user_password = Console.ReadLine();

                bool isChecked = CheckLogin(user_login, user_password);

                if (isChecked)
                {
                    Console.WriteLine("Вы прошли авторизацию.");
                    break;
                }
                else
                {
                    Console.WriteLine("Вы не прошли авторизацию.");
                    count++;
                }

                if (count == 3) Console.WriteLine("Вы заблокированы!");

            } while (count < 3);

            Console.ReadKey();
        }
    }
}
