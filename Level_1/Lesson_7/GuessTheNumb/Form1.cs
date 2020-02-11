using System;
using System.Windows.Forms;

namespace GuessTheNumb
{
    public partial class Form1 : Form
    {
        // ------ ОПИСАНИЕ ПОЛЕЙ ------

        int input_numb;
        int guess_numb;
        int count = 0;

        // ------ ОПИСАНИЕ КОНСТРУКТОРА ------
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // Установка позиции формы по центру

            Random rnd = new Random();
            guess_numb = rnd.Next(1, 101);  // Задаем число, которое нужно отгадать, в диапазоне от 1 до 100
        }

        // ----- ОПИСАНИЕ МЕТОДОВ -----

        // Метод при событии нажатия на копку "Отправить"
        private void BtnSend_Click(object sender, EventArgs e)
        {
            count++;    // Увеличиваем счетчик - число попыток
            lblCount.Text = "Количество попыток: " + count.ToString();   // Обновляем значение счетчика на экране
            CheckNumb();    // Проверяем на соответсвие введенное число
        }

        // Метод для считывания введенного числа
        private void TbNumb_TextChanged(object sender, EventArgs e)
        {
            input_numb = int.Parse(tbNumb.Text);
        }

        // Метод проверки веденного числа
        private void CheckNumb()
        {
            if(input_numb == guess_numb)
            {
                MessageBox.Show("Вы угадали число! Поздравляем с победой! \nКоличество попыток: " + count.ToString());
                Application.Exit();
            }

            if(input_numb > guess_numb) MessageBox.Show("Ваше число больше загаданного");
            else MessageBox.Show("Ваше число меньше загаданного");
        }
    }
}
