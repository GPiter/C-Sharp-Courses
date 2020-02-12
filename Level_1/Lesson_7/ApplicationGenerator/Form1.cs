using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Template_rest_generator
{
    // Создание структуры, связывающую некоторый тег со строкой (например - <name1>)
    struct Element
    {
        public string tag;
        public string str;

        // Описание конструктора для того, чтобы проще было заполнить массив
        public Element(string tag, string newString)
        {
            this.tag = tag;
            str = newString;
        }
    }

    public partial class Form1 : Form
    {
        string text_template;

        public Form1()
        {
            InitializeComponent();
            text_template = File.ReadAllText("Template.txt");   // Считываем текст шаблона заявления
        }

        // Ограничение на ввод символов в поле "Результат"
        private void TxtbResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // Обработка события нажатия на кнопку
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            TextReader();   // Вызов метода обработки текста по шаблону
            txtbResult.Text = text_template;    // Вывод полученного текста в поле "Результат"
            text_template = File.ReadAllText("Template.txt");   // Возвращаем переменной text_template исходное значение, чтобы в заявление можно было вносить правки
        }

        // Метод обработки текстового шаблона
        private void TextReader()
        {
            // Заполним массив элементов, сопоставив тегам текст соответствующего элемента TextBox
            Element[] elements = new Element[8] {   new Element("name1",txtbName1.Text),
                                                    new Element("name2",txtbName2.Text),
                                                    new Element("name3",txtbName3.Text),
                                                    new Element("name4",txtbName4.Text),
                                                    new Element("name5",txtbName5.Text),
                                                    new Element("data1",txtbDate1.Text),
                                                    new Element("data2",txtbDate2.Text),
                                                    new Element("data3",txtbDate3.Text),
                                                };

            // Проходим по массиву и меняем все вхождения тегов на текст
            foreach (Element el in elements)
            {
                Regex reg = new Regex("<" + el.tag + ">");
                text_template = reg.Replace(text_template, el.str);
            }

        }

    }
}
