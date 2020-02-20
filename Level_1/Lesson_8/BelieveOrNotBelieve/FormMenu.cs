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
    public partial class FormMenu : Form
    {
        Form1 settings = new Form1();
        FormAboutProgram aboutProgram = new FormAboutProgram();        

        public FormMenu()
        {           
            InitializeComponent();            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }

        private void BtnAboutProgram_Click(object sender, EventArgs e)
        {
            aboutProgram.ShowDialog();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            FormGame game = new FormGame();
            this.Hide();
            game.ShowDialog();
            this.Show();
        }
    }
}
