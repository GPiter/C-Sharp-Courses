using System;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class Form1 : Form
    {
        TrueFalse database = new TrueFalse();       
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddQuestion_Click(object sender, EventArgs e)
        {
            database.ListQuestion.Add(new Question(tbTextQuestion.Text, cbTruth.Checked));
            tbTextQuestion.Text = "";
            cbTruth.Checked = false;
            lblCountQuestion.Text = "Всего вопросов: " + database.ListQuestion.Count;
            nudNumbQuestion.Maximum = database.ListQuestion.Count - 1;
        }

        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот вопрос?","Подтвердите удаление вопроса",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                database.ListQuestion.RemoveAt((int)nudNumbQuestion.Value);
                lblCountQuestion.Text = "Всего вопросов: " + database.ListQuestion.Count;
                nudNumbQuestion.Maximum = database.ListQuestion.Count - 1;
            }
        }

        private void NudNumbQuestion_ValueChanged(object sender, EventArgs e)
        {
            tbTextQuestion.Text = database.ListQuestion[(int)nudNumbQuestion.Value].Text;
            cbTruth.Checked = database.ListQuestion[(int)nudNumbQuestion.Value].Truth;
        }

        private void BtnSaveQuestion_Click(object sender, EventArgs e)
        {
            database.ListQuestion[(int)nudNumbQuestion.Value].Text = tbTextQuestion.Text;
            database.ListQuestion[(int)nudNumbQuestion.Value].Truth = cbTruth.Checked;
        }

        private void TsmiNew_Click(object sender, EventArgs e)
        {
            tbTextQuestion.Text = "";
            cbTruth.Checked = false;
            database.ListQuestion.Clear();
            lblCountQuestion.Text = "Всего вопросов: " + database.ListQuestion.Count;
            nudNumbQuestion.Maximum = 0;
        }

        private void TsmiSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xml|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database.SaveToXml(dlg.FileName);
            }
        }

        private void TsmiLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.xml|*.xml|Все файлы(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database.LoadXml(dlg.FileName);
                tbTextQuestion.Text = database.ListQuestion[0].Text;
                cbTruth.Checked = database.ListQuestion[0].Truth;
                nudNumbQuestion.Maximum = database.ListQuestion.Count-1;
                lblCountQuestion.Text = "Всего вопросов: " + database.ListQuestion.Count;
            }
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsmiAboutProgram_Click(object sender, EventArgs e)
        {
            FormAboutProgram aboutProgtam = new FormAboutProgram();
            aboutProgtam.ShowDialog();
        }
    }
}
