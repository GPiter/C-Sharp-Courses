using System;
using System.Windows.Forms;

namespace DoublerGame
{
    /// ------- ОПИСАНИЕ КЛАССА ФОРМЫ ИГРЫ --------
    class Form1 : Form
    {
        // ------ ОПИСАНИЕ ПРИМИТИВОВ ------

        Label lblCurrent;
        Label lblFinish;
        Label lblCountClick;
        Button btnPlus;
        Button btnMulti;
        Button btnReset;
        Button btnCansel;
        Doubler dbl;

        // ------ ОПИСАНИЕ КОНСТРУКТОРА ------
        public Form1()
        {
            dbl = new Doubler();    // Создание объекта класса Doubler, описывающего логику работы с числами
            Text = "Удвоитель"; // Заголовок формы

            // Параметры метки "Текущее значение"
            lblCurrent = new Label();
            lblCurrent.Parent = this;
            lblCurrent.Text = "1";
            lblCurrent.Top = 10;
            lblCurrent.Left = 10;
            lblCurrent.Name = "lblCurrent";

            // Параметры метки "Целевое значение"
            lblFinish = new Label();
            lblFinish.Parent = this;
            lblFinish.Text = "Целевое число: " + dbl.GetFinish.ToString();
            lblFinish.Height = 40;
            lblFinish.Top = 50;
            lblFinish.Left = 10;
            lblFinish.Name = "lblFinish";

            // Параметры метки "Количество отданных команд"
            lblCountClick = new Label();
            lblCountClick.Parent = this;
            lblCountClick.Text = "Количество отданных команд: " + dbl.GetCount.ToString();
            lblCountClick.Height = 40;
            lblCountClick.Top = 100;
            lblCountClick.Left = 10;
            lblCountClick.Name = "lblCountClick";

            // Параметры кнопки "Прибавление к текущему значению 1"
            btnPlus = new Button();
            btnPlus.Parent = this;
            btnPlus.Text = "+1";
            btnPlus.Top = 10;
            btnPlus.Left = 200;
            btnPlus.Name = "btnPlus";
            btnPlus.Click += Btn_Is_Clicked;

            // Параметры кнопки "Умножение текущего значения на 2"
            btnMulti = new Button();
            btnMulti.Parent = this;
            btnMulti.Text = "x2";
            btnMulti.Top = 60;
            btnMulti.Left = 200;
            btnMulti.Name = "btnMulti";
            btnMulti.Click += Btn_Is_Clicked;

            // Параметры кнопки "Сброс текущего значения до 1"
            btnReset = new Button();
            btnReset.Parent = this;
            btnReset.Text = "Сброс";
            btnReset.Top = 160;
            btnReset.Left = 200;
            btnReset.Name = "btnReset";
            btnReset.Click += Btn_Is_Clicked;

            // Параметры кнопки "Отмена последнего хода"
            btnCansel = new Button();
            btnCansel.Parent = this;
            btnCansel.Text = "Отмена";
            btnCansel.Top = 110;
            btnCansel.Left = 200;
            btnCansel.Name = "btnCansel";
            btnCansel.Click += Btn_Is_Clicked;
        }

        // ----- ОПИСАНИЕ МЕТОДОВ -----

        // Метод отрисовки меток "Текущее значение" и "Количество отданных команд"
        private void lblDraw()
        {
            lblCurrent.Text = dbl.GetCurrent.ToString();
            lblCountClick.Text = "Количество отданных команд: " + dbl.GetCount.ToString();
        }

        // Метод обработки нажатий кнопок
        private void Btn_Is_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if ((sender as Button).Name == "btnPlus") dbl.NumbPlusOne();

                if ((sender as Button).Name == "btnMulti") dbl.NumbMultiplyTwo();

                if ((sender as Button).Name == "btnReset") dbl.NumbReset();

                if ((sender as Button).Name == "btnCansel") dbl.NumbCansel();
            }

            lblDraw();
            FinishGame();
        }

        // Метод для вывода результата игры
        private void FinishGame()
        {
            if(dbl.GetCurrent == dbl.GetFinish)
            {
                MessageBox.Show("Вы выиграли! Количество ходов: " + dbl.GetCount.ToString());
                this.Close();
            }

            if (dbl.GetCurrent > dbl.GetFinish)
            {
                MessageBox.Show("Ваше число больше целевого. Вы проиграли!");
                this.Close();
            }
        }

    }

}
