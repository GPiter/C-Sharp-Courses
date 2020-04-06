using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyPlanner
{
    public partial class Form1 : Form
    {
        string notepadFilename;
        public Form1()
        {
            InitializeComponent();
            lblTimer.DataBindings.Add("Text", trbTimer, "Value");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tsslCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void TsbCurrentTimeInsert_Click(object sender, EventArgs e)
        {
            // Формируем текст в формате .rtf
            //      \rtf1 - формат rtf
            //      \b    - жирный шрифт
            //      \b0   - окончание жирного шрифта
            //      \par  - отступ параграфа
            //      \line - отступ строки (аналог \n)

            string rtfText = @"{\rtf1\b " + DateTime.Now.ToString() + @"\b0\par\line}}";

            // Устанавливаем фокус ввода
            rtbNotepad.Focus();

            // Устанавливаем курсор в начало текстового поля
            rtbNotepad.Select(0, 0);

            // Копируем в буфер обмена данные с указанием типа данных
            Clipboard.SetData(DataFormats.Rtf, rtfText);

            // Вставляем данные из буфера обмена
            rtbNotepad.Paste();

            // Устанавливаем курсор для ввода данных
            rtbNotepad.Select(rtbNotepad.SelectionStart - 1, 0);
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            rtbNotepad.SaveFile(notepadFilename);
            Properties.Settings.Default.notepadFilename = notepadFilename;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notepadFilename = Properties.Settings.Default.notepadFilename;
            if (System.IO.File.Exists(notepadFilename)) rtbNotepad.LoadFile(notepadFilename);
        }

        private void TsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Файл rtf|*.rtf|Все файлы|*.*";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                notepadFilename = dlg.FileName;
                rtbNotepad.SaveFile(notepadFilename);
            }
        }

        private void TsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файл rtf|*.rtf|Все файлы|*.*";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                notepadFilename = dlg.FileName;
                rtbNotepad.LoadFile(notepadFilename);
            }
        }

        private void TsmiNew_Click(object sender, EventArgs e)
        {
            rtbNotepad.Clear();
        }

        private void TsmiSave_Click(object sender, EventArgs e)
        {
            rtbNotepad.SaveFile(notepadFilename);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (trbTimer.Value > 0) trbTimer.Value--;
            else
            {
                timer2.Stop();
                MessageBox.Show(txtbTimerMsg.Text);
            }
        }

        private void BtnGetWeather_Click(object sender, EventArgs e)
        {
            // Используем веб сервис для получения погоды
            var weather = new com.cobbnz.weather.clsWebService();
            // Записываем результат запроса в формат xml
            var str_xml = weather.GetCurrentConditionsAsXML("Saint-Petersburg");
            // Отображаем xml-формат в поле textbox
            tbWeatherInfo.Text = str_xml.ToString();

            // Десериализация полученного xml
            // Создаем объкект типа "XmlDocument"
            var document = new System.Xml.XmlDocument();
            document.LoadXml(str_xml);

            // Создаем объект типа "Чтение узлов xml"
            var reader = new System.Xml.XmlNodeReader(document);
            var name = String.Empty;
            var temp = String.Empty;

            // Цикл по узлам xml-документа
            while (reader.Read() == true)
            {
                // Читаем последовательно каждый узел, выясняя тип узла
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                    name = reader.Name;

                // Каждый раз запоминаем имя узла
                if (reader.NodeType != System.Xml.XmlNodeType.Text)
                    continue;

                // Выход из цикла, когда прочитали данные узла TemperatureCurrent
                if (name == "TemperatureCurrent")
                {
                    temp = reader.Value;
                    break;
                }

            }

            lblCurrentTemp.Text = "Температура: " + temp + " С";
        }
    }
}
