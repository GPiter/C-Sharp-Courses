/* Задание 4-4
 * Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий
 * массив случайными числами. Создать методы, которые возвращают сумму всех элементов
 * массива, сумму всех элементов массива больше заданного, свойство, возвращающее
 * минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
 * возвращающий номер максимального элемента массива (через параметры, используя
 * модификатор ref или out)
 * 
 */

using System;

namespace Hw_4_4
{
    class TwoDimensionalArray
    {
        int[,] array;

        /*----- ОПИСАНИЕ КОНСТРУКТОРОВ -----*/
        public TwoDimensionalArray(int n, int min, int max)
        {
            array = new int[n, n];

            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
        }

        /*----- ОПИСАНИЕ СВОЙСТВ -----*/

        /*----- Максимальный элемент массива -----*/
        public int MaxElementOfArray
        {
            get
            {
                int max = array[0,0];

                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] > max)
                            max = array[i, j];
                    }

                return max;
            }
        }

        /*----- Минимальный элемент массива -----*/
        public int MinElementOfArray
        {
            get
            {
                int min = array[0, 0];

                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] < min)
                            min = array[i, j];
                    }

                return min;
            }
        }

        /*----- ОПИСАНИЕ МЕТОДОВ -----*/

        /*----- Сумма элементов массива -----*/
        public int SummElementsOfArray(int n)
        {
            int summ = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    summ += array[i, j];

            return summ;
        }

        /*----- Сумма элементов массива больше заданного числа -----*/
        public int SummElementsOfArray(int n, int minLimit)
        {
            int summ = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (array [i,j] > minLimit)
                        summ += array[i, j];
                }

            return summ;

        }

        /*----- Поиск номера максимального элемента -----*/
        public void SearchMax()
        {
            int max = MaxElementOfArray;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == max)
                        Console.WriteLine("Номер максимального размера массива: " + (i+1) + " " + (j+1) );
                }
        }

        /*----- Вывод массива -----*/
        public void DisplayArray(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write("{0, 5}", array[i, j]);
            }
            Console.WriteLine("\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 5; // Размерность массива
            int minLimit = 0;

            TwoDimensionalArray arr_a = new TwoDimensionalArray(n, -100, 100);
            arr_a.DisplayArray(n);

            Console.WriteLine("Сумма элементов массива: " + arr_a.SummElementsOfArray(n));
            Console.WriteLine("Сумма элементов массива больше заданного числа " + minLimit + ": " + arr_a.SummElementsOfArray(n, minLimit) );

            Console.WriteLine("Максимальный элемент массива: " + arr_a.MaxElementOfArray);
            Console.WriteLine("Минимальный элемент массива: " + arr_a.MinElementOfArray);

            arr_a.SearchMax();

        }
    }
}
