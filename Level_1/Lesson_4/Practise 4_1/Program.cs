/* Задача 1
 * Разработать класс для работы с одномерным массивом. Предусмотреть конструктор, заполняющий
 * массив конкретными значениями и конструктор заполняющий массив случайными числами. Сделать
 * методы поиска среднего значения, максимального элемента массива, минимального элемента массива,
 * подсчета количества положительных чисел и метод, возвращающий массив в виде строки.
 * 
 */

using System;

namespace L_4
{
    class ImprovedArray
    {
        int[] array;


        /*----- Описание конструкторов -----*/

        public ImprovedArray(int n, int el)
        {
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = el;
            }
        }

        public ImprovedArray(int n, int min, int max)
        {
            array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(min, max);
            }
        }

        /*----- Описание свойств -----*/
        /*----- Поиск максимального элемента -----*/
        public int MaxElementOfArray
        {
            get
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max) max = array[i];
                }
                return max;
            }
        }

        /*----- Поиск минимального элемента -----*/
        public int MinElementOfArray
        {
            get
            {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                }
                return min;
            }
        }

        /*----- Количество положительных чисел -----*/
        public int CountPositiveNumbers
        {
            get
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0) count++;
                }
                return count;
            }
        }

        /*----- Метод для форматированного вывода -----*/
        public string DisplayToString()
        {
            string s = "";
            foreach (int element in array)
            {
                s = s + element + " ";
            }
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сгенерированный массив: ");
            ImprovedArray arr_a = new ImprovedArray(5, -10, 10);
            Console.WriteLine(arr_a.DisplayToString());

            Console.WriteLine("Количество положительных чисел: ");
            Console.WriteLine(arr_a.CountPositiveNumbers);

            Console.WriteLine("Максимальное число: ");
            Console.WriteLine(arr_a.MaxElementOfArray);

            Console.WriteLine("Минимальное число: ");
            Console.WriteLine(arr_a.MinElementOfArray);

        }
    }
}
