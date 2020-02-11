using System;
using System.Windows.Forms;

namespace DoublerGame
{
    class Program
    {  
        public static void Main()
        {
            FormMenu menu = new FormMenu();
            Application.Run(menu);  // Запуск приложения начинается с формы меню
        }
    }

    /// ------- ОПИСАНИЕ КЛАССА ФОРМЫ МЕНЮ --------
    class FormMenu : Form
    {
        // ------ ОПИСАНИЕ ПРИМИТИВОВ ------

        Button btnPlay;
        Button btnExit;
        Form GameForm;

        // ------ ОПИСАНИЕ КОНСТРУКТОРА ------
        public FormMenu()
        {
            // Параметры формы меню FormMenu
            Text = "Удвоитель"; // Заголовок формы
            StartPosition = FormStartPosition.CenterScreen; // Установка позиции формы по центру

            // Параметры кнопки "Играть"
            btnPlay = new Button();
            btnPlay.Parent = this;
            btnPlay.Text = "Играть";
            btnPlay.Top = 10;
            btnPlay.Left = 10;
            btnPlay.Width = 260;
            btnPlay.Height = 100;
            btnPlay.Name = "btnPlay";
            btnPlay.Click += BtnPlay_Click;

            // Параметры кнопки "Выход"
            btnExit = new Button();
            btnExit.Parent = this;
            btnExit.Text = "Выход";
            btnExit.Top = 220;
            btnExit.Left = 10;
            btnExit.Width = 260;
            btnExit.Name = "btnExit";
            btnExit.Click += BtnExit_Click;

            // Параметры игровой формы Form1
            GameForm = new Form1(); // Создание формы с игрой
            GameForm.StartPosition = FormStartPosition.CenterScreen; // Установка позиции формы по центру
            GameForm.FormClosed += GameForm_FormClosed; // Привязка к событию при закрытии формы с игрой
        }

        // ----- ОПИСАНИЕ МЕТОДОВ -----

        // Метод при событии нажатия на копку играть.
        // Открывает форму с игрой GameForm; скрывает текущую форму меню FormMenu.
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            GameForm.Show();
            this.Hide();
        }

        // Метод при событии нажатия на копку выход. Закрывает приложение.
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Метод при событии закрытия формы с игрой. Закрывает приложение.
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

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
