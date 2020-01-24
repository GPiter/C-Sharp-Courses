using System;
using System.Text;

namespace Practise_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] count_array = new int[26];    // частотный массив
            int i, code_get_symbol, code_char_A;
            char c; // символ строки

            i = 0;  // переменная цикла

            code_char_A = (int)('a');   // код символа 'a'
            string s = "ajdsj2jfj34234jaasdadj3j32fjjsckcskdj423412jjcjjsajdj4.";

            do
            {
                c = s[i];
                code_get_symbol = (int)(s[i]); // получаем код символа строки

                if (c >= 'a' && c <= 'z')      // если символ маленькая буква
                    count_array[code_get_symbol - code_char_A]++;   // увеличиваем элемент частотного массива, соответствущий этому символу (формула: текущий код символа - код символа а = номер элемента массива)

                i++;

            } while (c != '.');

            for (i = 0; i < count_array.Length; i++)
            {
                if (count_array[i] > 0)
                {
                    Console.WriteLine("{0}{1}", (char)(code_char_A + i), count_array[i]);
                }

            }
        }
    }
}
