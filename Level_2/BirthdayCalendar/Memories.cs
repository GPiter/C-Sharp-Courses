using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCalendar
{
    public class Memories
    {
        List<Person> memories = new List<Person>();
        DateTime creationDate = DateTime.Now;

        public List<Person> MemoriesDate
        {
            get { return memories; }
            set { memories = value; }
        }

        public DateTime[] Dates
        {
            get
            {
                DateTime[] dates = new DateTime[memories.Count];
                for (int i = 0; i < memories.Count; i++)
                    dates[i] = memories[i].Date;
                return dates;
            }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
    }
}
