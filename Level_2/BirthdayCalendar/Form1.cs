using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthdayCalendar
{
    public partial class Form1 : Form
    {
        BindingSource bindSrc = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            Memories memories = new Memories();
            memories.MemoriesDate.Add(new Person());
            bindSrc.DataSource = memories;
            bindSrc.DataMember = "MemoriesDate";

            tbPersonName.DataBindings.Add("Text", bindSrc, "Name");
            tbPersonName.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            dtpPersonDate.DataBindings.Add("Value", bindSrc, "Date");
            dtpPersonDate.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar.BoldedDates = (bindSrc.DataSource as Memories).Dates;
        }
    }
}
