using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCalendar
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Person()
        {
            Name = "";
            Date = DateTime.Now;
        }
    }
}
