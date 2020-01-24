/* Задание 4-2
 * Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив
 * заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
 * Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий
 * знаки у всех элементов массива, Метод Multi, умножающий каждый элемент массива на
 * определенное число, метод MaxCounter и свойство MaxCount, возвращающее количество
 * максимальных элементов. В Main продемонстрировать работу класса. 
 * 
 */

using System;

namespace Hw_4_2
{
    class ImprovedArray
    {
        int[] array;

        /*----- ОПИСАНИЕ КОНСТРУКТОРОВ -----*/
        #region
        public ImprovedArray(int n, int min, int max)
        {
            array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(min, max);
            }
        }

        public ImprovedArray(int n, int step)
        {
            array = new int[n];
            for (int i = 1; i < n; i++)
            {
                array[i] = array[i - 1] + step;
            }

        }
        #endregion

        /*----- ОПИСАНИЕ СВОЙСТВ -----*/
        #region

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

        /*----- Сумма элементов массива -----*/
        public int SummElementsOfArray
        {
            get
            {
                int summ = 0;
                foreach (int element in array)
                {
                    summ += element;
                }
                return summ;
            }
        }

        /*----- Количество максимальных элементов в массиве -----*/
        public int MaxCount
        {
            get
            {
                int max = MaxElementOfArray;
                int count = 0;
                foreach (int element in array)
                {
                    if (element == max)
                        count++;
                }
                return count;
            }
        }
        #endregion

        /*----- ОПИСАНИЕ МЕТОДОВ -----*/
        #region
        /*----- Инверсия массива -----*/
        public int[] InverseArray()
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = -array[i];
            return array;
        }

        /*----- Умножение элементов массива на заданное число -----*/
        public void MultiElementOfArray(int n, int numb)
        {
            for (int i = 0; i < n; i++)
            {
                array[i] = array[i] * numb;
            }
        }

        /*----- Количество максимальных элементов в массиве -----*/
        public int MaxCounter()
        {
            int max = MaxElementOfArray;
            int count = 0;
            foreach (int element in array)
            {
                if (element == max)
                    count++;
            }
            return count;
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
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 5; // Размерность массива

            Console.WriteLine("Сгенерированный массив: ");
            ImprovedArray arr_a = new ImprovedArray(n, 0, 10);
            Console.WriteLine(arr_a.DisplayToString());

            Console.WriteLine("Количество максимальных элементов в массиве - МЕТОД: " + arr_a.MaxCounter());
            Console.WriteLine("Количество максимальных элементов в массиве - СВОЙСТВО: " + arr_a.MaxCount);

            Console.WriteLine("Сумма элементов массива: " + arr_a.SummElementsOfArray);

            Console.WriteLine("Метод умножения элементов массива на заданное число: ");
            arr_a.MultiElementOfArray(n, 3);
            Console.WriteLine(arr_a.DisplayToString());

            Console.WriteLine("Инверсия массива: ");
            arr_a.InverseArray();
            Console.WriteLine(arr_a.DisplayToString());
        }
    }
}
