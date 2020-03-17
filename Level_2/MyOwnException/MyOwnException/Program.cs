/*
 * Создайте собственное исключение MyOwnException.Реализуйте ввод данных в массив. Если
 * при вводе данных вводится данное, которое уже есть в списке, создайте срабатывание вашего
 * события и перехват его.
*/

using System;
using System.Collections.Generic;

namespace MyOwnException
{

    class MyException : Exception
    {
        public MyException ()
        {
            Console.WriteLine(base.Message);
        }
    }

    class Program
    {
        static int[] arr = new int[15];
        static List<int> buffer = new List<int>();
        static void Main(string[] args)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    arr[i] = int.Parse(Console.ReadLine());

                    foreach (int numb in buffer)
                    {
                        if (numb == arr[i]) throw new MyException();
                    }

                    buffer.Add(arr[i]);
                }

                catch (MyException)
                {
                    Console.WriteLine("Данное значение уже было введено!");
                }

                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат введенных данных!");
                    continue;
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число!");
                    continue;
                }
            }

        }
    }
}
