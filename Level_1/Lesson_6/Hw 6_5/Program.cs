/* Задание 6-5
 * В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок.
 */

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Hw_6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Регулярное выражение для поиска тега в формате <img src=...>
            string pattern_teg = "[<]img src=[" + "\"" + "]\\D[a-zA-Z0-9]*[.](jpg|jpeg|bmp)[" + "\"" + "][>]";

            // Регулярное выражние для поиска названия картинки
            string pattern_img_name = "[a-zA-Z0-9]+[.](jpg|jpeg|bmp)";
            
            Regex reg_teg = new Regex(pattern_teg); // [<]img src=["]\D[a-zA-Z0-9]*[.](jpeg|bmp|jpg)["][>]
            Regex reg_img = new Regex(pattern_img_name); // [a-zA-Z0-9]+[.](jpg|jpeg|bmp)           

            List<string> tegs = new List<string>(); // список для хранения найденных тегов

            string[] fs = Directory.GetFiles("D:\\test", "*.html", SearchOption.AllDirectories);  // получение списка файлов из папок и подпапок

            //-----------------------------------------------------------------------------------------------//

            // 1. Просматриваем каждый .html файл
            // 2. В переменную text считываем содержимое файла
            // 3. Находим соответсвие тега по регулярному выражению pattern_teg, результат добавляем в список tegs
            // 4. Проходим по списку tegs, находим соответсвие по регулярному выражению pattern_img_name
            // 5. Выводим результат на экран

            foreach (var filename in fs)
            {
                string text = File.ReadAllText(filename, System.Text.Encoding.Default);

                foreach(var html_teg in reg_teg.Matches(text))
                {
                    tegs.Add(Convert.ToString(html_teg));
                }
            }

            foreach (string teg in tegs)
            {
                foreach (var img in reg_img.Matches(teg)) 
                    Console.WriteLine(img);
            }

        }
    }
}
