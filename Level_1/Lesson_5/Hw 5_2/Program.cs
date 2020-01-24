/* Задание 5_2
 * Разработать методы для решения следующих задач. Дано сообщение:
 * Вывести только те слова сообщения, которые содержат не более чем n букв;     +
 * Удалить из сообщения все слова, которые заканчиваются на заданный символ;    +
 * Найти самое длинное слово сообщения;
 * Найти все самые длинные слова сообщения.
 * 
 */

using System;
using System.Text;

namespace Hw_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder msg_input = new StringBuilder("Я помню чудное мгновенье: передо мной явилась ты, как мимолетное виденье, как гений чистой красоты.");
            string msg_work;

            Console.WriteLine("Исходное сообщение: " + msg_input);

            /*-------------------------- Задание 1 --------------------------------*/

            Console.WriteLine("\n\n----- Задание 1 -----\n\n");

            int n = 6;  // Ограничение на количество букв в слове
            int word_count = 0; // Счетчик количества слов с заданным количеством букв

            // Проходим строку. Если содержатся знаки препинания, удаляем их.
            for (int i = 0; i < msg_input.Length; i++)
            {
                if (char.IsPunctuation(msg_input[i]))
                    msg_input.Remove(i, 1);
            }

            msg_work = msg_input.ToString();    // Преобразуем объект StringBuilder в строку

            string[] msg_array = msg_work.Split(' ');   // Создаем массив слов, с помощью разделителя пробел.

            Console.WriteLine("Слова, которые содержат не более " + n + " букв:");
            foreach (string word in msg_array)
            {
                if (word.Length <= n)
                {
                    Console.WriteLine(word);
                    word_count++;
                }
            }

            if (word_count == 0) Console.WriteLine("Слов с таким количеством букв не обнаржуено!");


            /*-------------------------- Задание 2 --------------------------------*/

            Console.WriteLine("\n\n----- Задание 2 -----\n\n");

            char del_symbol = 'е';  // Символ, удаляющий слово

            string[] msg_array_del_symb = new string[msg_array.Length];    // Массив с отобранными словами

            for (int i = 0; i < msg_array.Length; i++)
            {
                string current_word = msg_array[i];    // текущее слово в массиве
                char[] current_ch = current_word.ToCharArray(); // преобразуем в массив символов

                if (current_ch[current_ch.Length - 1] != del_symbol)  // если последний символ не равен указанному, то добавляем текущее слово в массив
                {
                    msg_array_del_symb[i] = current_word;
                }
            }

            Console.WriteLine("Сообщение без слов, оканчивающееся на букву " + del_symbol);
            foreach (string word in msg_array_del_symb)
                Console.Write(word + " ");

            /*-------------------------- Задание 3 --------------------------------*/

            Console.WriteLine("\n\n----- Задание 3 -----\n\n");

            int max = 0;
            string longest_word;

            Console.WriteLine("Самое длинное слово в сообщении: ");

            foreach (string word in msg_array)
            {
                if (word.Length > max) max = word.Length;
            }

            foreach (string word in msg_array)
            {
                if (word.Length == max)
                {
                    longest_word = word;
                    Console.WriteLine(word);
                }
            }

        }
    }
}
