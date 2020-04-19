/* Класс Memory предназначен для хранения текста и даты */

using System;

namespace DailyPlanner
{
    public class Memory
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Memory()
        {
            Text = "";
            Date = DateTime.Now;
        }
    }
}
