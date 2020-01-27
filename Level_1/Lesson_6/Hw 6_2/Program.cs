/* Задание 6-2
 * 1. Написать программу сохранения результатов вычисления заданной функции в файл для дальнейшей
 * обработки файла. Разбить программу на две функции: одна записывает данные функции в файл на
 * промежутке от a до b с шагом h, а другая считывает данные и находит минимум функции. 
 * 
 * 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать
 * функцию в виде делегата. Сделать меню с различными функциями и представьте пользователю
 * выбор для какой функции и на каком отрезке находить минимум.
 *
 */

using System;
using System.IO;

namespace Hw_6_2
{
    class Program
    {
        public delegate double Function(double x);

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double MyFunc(double x)
        {
            return x * x;
        }

        public static void SaveFunction(string filename, Function S, double a, double b, double h)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);    // Создаем файловый поток (байтовый)

            BinaryWriter bw = new BinaryWriter(fs); // BinaryWriter позволяет считывать данные из потока определенного типа (int, double и т.д.)
                                                    // Двоичные файлы не применяются для просмотра человека, а служат только для программной обработки
            double x = a;
            while(x <= b)
            {
                bw.Write(S(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double LoadMin(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);

            double min = double.MaxValue;
            double d;

            for( int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < min) min = d;
            }

            bw.Close();
            fs.Close();
            return min;
        } 

        static void Main(string[] args)
        {
            SaveFunction("data.bin", MyFunc, 2, 5, 1);
            Console.WriteLine(LoadMin("data.bin"));
        }
    }
}
