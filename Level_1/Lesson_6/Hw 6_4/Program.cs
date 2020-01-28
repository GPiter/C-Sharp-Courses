/* Задание 6-4
 * В файле могут встречаться номера телефонов, записанные в формате
 * xx-xx-xx, xxx-xxx или xxx-xx-xx.
 * Вывести все номера телефонов, которые содержатся в файле.
 */

using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Hw_6_4
{
    // Составленное регулярное выражение для поиска телефонов:
    // (\d{3}(-\d\d){2}) | ((\d\d-){2}\d\d) | (\d{3}-\d{3})

    class Program
    {
        static void Main(string[] args)
        {
            string[] fs = Directory.GetFiles("D:\\test", "*.*", SearchOption.AllDirectories);   // Создаем массив, хранящий список всех директорий, включая подпапки

            foreach(var filename in fs)
            {
                Regex regex = new Regex(@"(\d{3}(-\d\d){2})|((\d\d-){2}\d\d)|(\d{3}-\d{3})");   // Создаем регулярное выражение по составленному шаблону
                string text = File.ReadAllText(filename);   // Считываем весь текст в текущем файле из массива

                foreach (var phone in regex.Matches(text))  // Находим соответсвия телефонов в тексте файла
                {
                    FileInfo description = new FileInfo(filename);  //  Создаем объект для описание файла с найденным телефоном
                    Console.WriteLine("Найден телефон " + phone + " в файле " + description.FullName);
                }
                    
            }
        }
    }
}
