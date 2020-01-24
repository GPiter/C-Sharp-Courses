/* Задача 2
 * Дана последовательность целых чисел, записанная в текстовый файл. Требуется считать данные из
 * файла в массив, найти среднее арифметическое элементов и вывести минимальный и максимальный
 * элементы массива на экран. Отсортировать массив.
 * 
 */

using System;
using System.IO;

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

        public ImprovedArray(string filename)
        {
            StreamReader sr = new StreamReader("data.txt");
            int N = int.Parse(sr.ReadLine());               // 1-я строка - кол-во элементов, далее - каждая строчка - отдельный элемент
            array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = int.Parse(sr.ReadLine());
            }

            sr.Close();
        }

        /*----- Описание свойств -----*/

        /*----- Длинна массива -----*/
        public int LenghtOfArray
        {
            get
            {
                return array.Length;
            }
        }

        /*----- Сумма элементов массива -----*/
        public double SumOfArrayElements
        {
            get
            {
                double sum = 0;
                foreach (int element in array)
                {
                    sum += element;
                }
                return sum;
            }
        }

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

        public void PrintArray()
        {
            foreach (int element in array)
                Console.WriteLine("{0, 4}", element);
        }

        public void PrintArray(string msg)
        {
            Console.WriteLine(msg);
            PrintArray();
        }

        /*----- Сортировка массива методом пузырька -----*/
        public void BubbleSort()
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j+1])
                    {
                        int t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ImprovedArray arr_a = new ImprovedArray("data.txt");
            arr_a.PrintArray();

            Console.WriteLine("Максимальное число: {0}", arr_a.MaxElementOfArray);
            Console.WriteLine("Минимальное число: {0}", arr_a.MinElementOfArray);
            Console.WriteLine("Среднее арифметическое: {0}", arr_a.SumOfArrayElements/arr_a.LenghtOfArray);

            arr_a.BubbleSort();
            arr_a.PrintArray("Отсортированный массив: ");

        }
    }
}
