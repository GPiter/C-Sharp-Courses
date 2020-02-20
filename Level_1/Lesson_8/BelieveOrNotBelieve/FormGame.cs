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
    public partial class FormGame : Form
    {
        TrueFalse database = new TrueFalse();
        bool isTrue;
        int countPoint = 0;
        int countQuestion = 1;
        int numberQuestion = 0;

        public FormGame()
        {
            InitializeComponent();
            database.LoadXml("questions.xml");
            tbQuestion.Text = database.ListQuestion[0].Text;
            lblNumbQuestion.Text = "Вопрос " + countQuestion + " из " + database.ListQuestion.Count;
        }

        private void BtnTrue_Click(object sender, EventArgs e)
        {
            isTrue = true;
            CheckQuestion();
        }

        private void BtnFalse_Click(object sender, EventArgs e)
        {
            isTrue = false;
            CheckQuestion();
        }

        private void CheckQuestion()
        {
            if (numberQuestion < database.ListQuestion.Count - 1)
            {
                if (isTrue == database.ListQuestion[numberQuestion].Truth) countPoint++;
                numberQuestion++;
                countQuestion++;
                tbQuestion.Text = database.ListQuestion[numberQuestion].Text;
                lblNumbQuestion.Text = "Вопрос " + countQuestion + " из " + database.ListQuestion.Count;
            }

            else
            {
                if (isTrue == database.ListQuestion[numberQuestion].Truth) countPoint++;
                MessageBox.Show("Игра окончена! Вы набрали " + countPoint + " очков!");
                this.Close();
            }
        }
    }
}
