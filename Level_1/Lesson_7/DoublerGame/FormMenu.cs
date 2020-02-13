using System;
using System.Windows.Forms;

namespace DoublerGame
{
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
        }

        // ----- ОПИСАНИЕ МЕТОДОВ -----

        // Метод при событии нажатия на копку играть.
        // Открывает форму с игрой GameForm; скрывает текущую форму меню FormMenu.
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            GameForm = new Form1(); // Создание формы с игрой
            GameForm.StartPosition = FormStartPosition.CenterScreen; // Установка позиции формы по центру
            this.Hide();
            GameForm.ShowDialog();  // Открыть форму с игрой как модальное окно
            this.Show();
        }

        // Метод при событии нажатия на кнопку выход. Закрывает приложение.
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

}
