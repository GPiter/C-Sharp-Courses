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

    class Doubler
    {
        int current = 1;
        int finish;

        public Doubler()
        {
            Random rnd = new Random();
            finish = rnd.Next(1, 11);
        }

        public Doubler(int number)
        {
            finish = number;
        }

        public void NumbPlusOne()
        {
            current += 1;
        }

        public void NumbMultiplyTwo()
        {
            current *= 2;
        }

        public void NumbReset()
        {
            current = 1;
        }

        public int GetCurrent
        {
            get { return current; }
        }

        public int GetFinish
        {
            get { return finish; }
        }
    }

    class Form1 : Form
    {
        Label lblCurrent;
        Label lblFinish;
        Button btnPlus;
        Button btnMulti;
        Button btnReset;
        Doubler dbl;

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
            lblFinish.Height = 50;
            lblFinish.Top = 50;
            lblFinish.Left = 10;
            lblFinish.Name = "lblFinish";

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
                MessageBox.Show("Вы выиграли!");
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
