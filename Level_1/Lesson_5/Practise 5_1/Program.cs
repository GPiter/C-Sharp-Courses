/* Задача 1. 
 * Вывести все слова сообщения, которые начинаются и заканчиваются на одну и ту же букву.
 * Дана строка, в которой содержится осмысленное текстовое сообщение. Слова сообщения разделяются
 * пробелами и знаками препинания. Вывести все слова сообщения, которые начинаются и заканчиваются
 * на одну и ту же букву.
 */

using System;
using System.Text;

namespace Practise_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            StringBuilder input_str = new StringBuilder(Console.ReadLine());

            Console.WriteLine("Исходная строка: " + input_str);

            // Удаляем знаки препинания, чтобы потом разделять слова по пробелу
            for (int i = 0; i < input_str.Length; i++)
            {
                if (char.IsPunctuation(input_str[i])) input_str.Remove(i, 1);
                else i++;
            }

            string work_string = input_str.ToString(); // преобразуем и копируем содержимое исходной строки в переменную string

            string[] str_array = work_string.Split(' ');  // создаем массив слов через разделитель - пробел

            Console.WriteLine("Искомые слова: ");
            
            for (int i = 0; i < str_array.Length; i++)
            {
                string current_word = str_array[i];
                char[] current_char = current_word.ToCharArray();

                if (current_char[0] == current_char[current_char.Length - 1])
                    Console.WriteLine(current_word);
            }

        }
    }
}
