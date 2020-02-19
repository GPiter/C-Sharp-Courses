using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class FormAboutProgram : Form
    {
        public FormAboutProgram()
        {
            InitializeComponent();
            btnOK.Focus();
            btnOK.Select();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
