using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Hw_6_5
{
    class Program
    {
        // [a-zA-Z0-9]+[.](jpeg|bmp)
        // [<]img src=["]\D[a-zA-Z0-9]*[.](jpeg|bmp)["][>]

        static void Main(string[] args)
        {
            string pattern_teg = "[<]img src=[" + "\"" + "]\\D[a - zA - Z0 - 9]*[.] (jpeg|bmp)[" + "\"" + "][>]";
            List<string> tegs = new List<string>();

            string[] catalogs = Directory.GetFiles("D:\\Projects\\Shop\\", "*.*", SearchOption.AllDirectories);
            Regex reg_teg = new Regex(pattern_teg);

            foreach(var file in catalogs)
            {
                string text = File.ReadAllText(file);
            }
        }
    }
}
