/* Задание 6-1
 * 1. Создать метод, который будет выводить значения некоторых функций от a до b. Чтобы иметь
 * возможность использовать метод с различными функциями, использовать механизм делегатов.
 * 2. Изменить программу вывода функции так, чтобы можно было передавать функции типа
 * double(double,double). Продемонстировать работу на функции с параметром a*x^2. 
 * 
 */

using System;

namespace Hw_6_1
{
    public delegate double Fun(double x);   // объявление делегата и сигнатуры функции. Делегат - это коллекция (хранилище методов с определенной сигнатурой)

    public delegate double Fun2params(double a, double x);

    class Program
    {
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("|{0,8:0.000}|{1,8:0.000}|", x, F(x));
                x += 1;
            }
            Console.WriteLine("--------------------");
        }

        public static void Table2params(Fun2params F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("|{0,8:0.000}|{1,8:0.000}|", x, F(a,x));
                x += 1;
            }
            Console.WriteLine("--------------------");
        }

        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double MySecondFunc(double a, double x)
        {
            return a * x * x;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции MyFunc:");
            Table(MyFunc, -2, 2);   // Передаем наш метод, имеющий сигнатуру делегата

            Console.WriteLine("Таблица функции Cos:");
            Table(Math.Cos, -2, 2); // Передаем метод Math.Cos(), имеющий ту же сигнатуру

            Console.WriteLine("Таблица функции x^2:");
            Table(delegate (double x) { return x * x; }, -2, 2); // Анонимный метод

            Console.WriteLine("Таблица функции  a * x * x:");
            Table2params(MySecondFunc, 2, -2, 2); // Делегат с двумя параметрами
        }
    }
}
