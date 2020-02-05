using System;
using System.Windows.Forms;

namespace DoublerGame
{
    class Program
    {
        public static void Main()
        {
            Application.Run(new Form1());
        }
    }

    class Form1 : Form
    {
        Label lblCurrent;
        Label lblFinish;
        Label lblCountClick;
        Button btnPlus;
        Button btnMulti;
        Button btnReset;
        Doubler dbl;

        int count_click = 0;

        public Form1()
        {
            dbl = new Doubler(20);

            Text = "Удвоитель";
            lblCurrent = new Label();
            lblCurrent.Parent = this;
            lblCurrent.Text = "1";
            lblCurrent.Top = 10;
            lblCurrent.Left = 10;
            lblCurrent.Name = "lblCurrent";

            lblFinish = new Label();
            lblFinish.Parent = this;
            lblFinish.Text = "Целевое число: " + dbl.GetFinish.ToString();
            lblFinish.Height = 40;
            lblFinish.Top = 50;
            lblFinish.Left = 10;
            lblFinish.Name = "lblFinish";

            lblCountClick = new Label();
            lblCountClick.Parent = this;
            lblCountClick.Text = "Количество отданных команд: " + dbl.GetCount.ToString();
            lblCountClick.Height = 40;
            lblCountClick.Top = 100;
            lblCountClick.Left = 10;
            lblCountClick.Name = "lblCountClick";

            btnPlus = new Button();
            btnPlus.Parent = this;
            btnPlus.Text = "+1";
            btnPlus.Top = 10;
            btnPlus.Left = 200;
            btnPlus.Name = "btnPlus";
            btnPlus.Click += Btn_Is_Clicked;

            btnMulti = new Button();
            btnMulti.Parent = this;
            btnMulti.Text = "x2";
            btnMulti.Top = 100;
            btnMulti.Left = 200;
            btnMulti.Name = "btnMulti";
            btnMulti.Click += Btn_Is_Clicked;

            btnReset = new Button();
            btnReset.Parent = this;
            btnReset.Text = "Сброс";
            btnReset.Top = 190;
            btnReset.Left = 200;
            btnReset.Name = "btnReset";
            btnReset.Click += Btn_Is_Clicked;

        }

        private void lblDraw()
        {
            lblCurrent.Text = dbl.GetCurrent.ToString();
            lblCountClick.Text = "Количество отданных команд: " + dbl.GetCount.ToString();
        }

        private void Btn_Is_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if ((sender as Button).Name == "btnPlus") dbl.NumbPlusOne();

                if ((sender as Button).Name == "btnMulti") dbl.NumbMultiplyTwo();

                if ((sender as Button).Name == "btnReset") dbl.NumbReset();
            }

            lblDraw();
            FinishGame();

        }

        private void FinishGame()
        {
            if(dbl.GetCurrent == dbl.GetFinish)
            {
                MessageBox.Show("Вы выиграли! Количество ходов: " + dbl.GetCount.ToString());
                Application.Exit();
            }

            if (dbl.GetCurrent > dbl.GetFinish)
            {
                MessageBox.Show("Ваше число больше целевого. Вы проиграли!");
                Application.Exit();
            }
        }

    }

}
