/* Класс MemorFile предназначен для хранения списка объектов Memory */

using System;
using System.Collections.Generic;

namespace DailyPlanner
{
    public class MemorFile
    {
        DateTime dtCreation = DateTime.Now;
        List<Memory> memories = new List<Memory>();

        public DateTime CreationDate
        {
            get { return dtCreation; }
            set { dtCreation = value; }
        }

        public List<Memory> Memories
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
                {
                    dates[i] = memories[i].Date;
                }
                return dates;
            }
        }
    }
}
