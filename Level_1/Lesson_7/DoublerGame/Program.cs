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
        Button btnPlus;
        Button btnMulti;
        Button btnReset;

        public Form1()
        {
            Text = "Удвоитель";
            lblCurrent = new Label();
            lblCurrent.Parent = this;
            lblCurrent.Text = "1";
            lblCurrent.Top = 10;
            lblCurrent.Left = 10;
            lblCurrent.Name = "lblCurrent";


            btnPlus = new Button();
            btnPlus.Parent = this;
            btnPlus.Text = "+1";
            btnPlus.Top = 10;
            btnPlus.Left = 200;
            btnPlus.Name = "btnPlus";

            btnMulti = new Button();
            btnMulti.Parent = this;
            btnMulti.Text = "x2";
            btnMulti.Top = 100;
            btnMulti.Left = 200;
            btnMulti.Name = "btnMulti";

            btnReset = new Button();
            btnReset.Parent = this;
            btnReset.Text = "Сброс";
            btnReset.Top = 190;
            btnReset.Left = 200;
            btnReset.Name = "btnReset";

        }
    }

}
