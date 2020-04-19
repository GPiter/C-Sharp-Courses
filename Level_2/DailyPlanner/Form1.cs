using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DailyPlanner
{
    public partial class Form1 : Form
    {
        string notepadFilename;

        BindingSource bindSrc = new BindingSource();

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(MemorFile));
        const string strFilter = "XML files (*.xml) | *.xml";

        public Form1()
        {
            InitializeComponent();
            lblTimer.DataBindings.Add("Text", trbTimer, "Value");

            // Связывание данных во вкладке "Календарь"
            BindingMemory();

        }

        // ------ Изучение BindingSource -----
        // Метод привязки данных с использованием BindingSource
        private void BindingMemory()
        {
            // Инициализация BindingSource
            MemorFile memoryFiles = new MemorFile();
            memoryFiles.Memories.Add(new Memory());
            bindSrc.DataSource = memoryFiles;
            bindSrc.DataMember = "Memories";

            // Связываем через BindingSource dtpMemory с объектом memoryFiles
            dtpMemory.DataBindings.Add("Value", bindSrc, "Date");
            dtpMemory.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            tbMemory.DataBindings.Add("Text", bindSrc, "Text");
            tbMemory.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            // Связывание BindingNavigator и BindingSource
            bindNavigator.BindingSource = bindSrc;

            // Добавление DataGridView
            grid.AutoGenerateColumns = false;
            grid.DataSource = bindSrc;
            DataGridViewTextBoxColumn tbColumn = new DataGridViewTextBoxColumn();
            grid.Columns.Add(tbColumn);
            grid.Columns[0].DataPropertyName = "Text";
            grid.Columns[0].Name = "Text";
            CalendarColumn calColumn = new CalendarColumn();
            grid.Columns.Add(calColumn);
            grid.Columns[1].DataPropertyName = "Date";
            grid.Columns[1].Name = "Date";
        }

        // Обработка клавиш Сохранить и Загрузить. Сериализация и десериализация в XML
        private void BtnCalendarSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = strFilter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);
                xmlSerializer.Serialize(sw, bindSrc.DataSource);
                sw.Close();
            }
        }

        private void BtnCalendarLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = strFilter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlg.FileName);
                bindSrc.DataSource = xmlSerializer.Deserialize(sr);
                sr.Close();
            }
        }
        // ---------------------------------

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
            try
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

            catch
            {
                MessageBox.Show("Ошибка подключения к веб-службе!", "Внимание!");
            }

        }

        private void BtnRestCount_Click(object sender, EventArgs e)
        {
            int daysCount;
            daysCount = (dtpRestFinish.Value.ToUniversalTime() - dtpRestStart.Value.ToUniversalTime()).Days;
            lblRestDuration.Text = "Количество дней: " + daysCount.ToString();
        }

        private void TbGetRate_Click(object sender, EventArgs e)
        {
            try
            {
                var rate = new ru.cbr.www.DailyInfo();
                var str_xml = rate.GetCursOnDateXML(DateTime.Now);  // получаемый объект имеет тип XmlNode

                foreach (XmlNode xmlNode in str_xml)
                {
                    // Считываем содержимое первого дочернего элемента узла
                    string nodeChildConvert = xmlNode.FirstChild.InnerText;

                    // Как выяснилось, он приходит в странном формате с кучей пробелов в конце, поэтому очищаем полученную строку от них
                    nodeChildConvert = nodeChildConvert.Trim();

                    tbRateInfo.Text += nodeChildConvert + '\r' + '\n';

                    if (nodeChildConvert == "Доллар США")
                    {
                        // Проходим по содержимому остальных дочерних элементов
                        foreach (XmlNode xmlNodeChild in xmlNode.ChildNodes)
                        {
                            if (xmlNodeChild.Name == "Vcurs")
                            {
                                lblCurrentRate.Text = "Курс доллара: " + xmlNodeChild.InnerText;
                            }
                        }
                    }

                    if (nodeChildConvert == "Евро")
                    {
                        foreach (XmlNode xmlNodeChild in xmlNode.ChildNodes)
                        {
                            if (xmlNodeChild.Name == "Vcurs")
                            {
                                lblEuroRate.Text = "Курс евро: " + xmlNodeChild.InnerText;
                            }
                        }
                    }

                    if (nodeChildConvert == "Японская иена")
                    {
                        break;
                    }
                }
            }

            catch
            {
                MessageBox.Show("Ошибка подключения к веб-службе!", "Внимание!");
            }

        }

        private void CalDays_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpMemory.Value = calDays.SelectionStart;
            calDays.BoldedDates = (bindSrc.DataSource as MemorFile).Dates;
        }
    }
}
