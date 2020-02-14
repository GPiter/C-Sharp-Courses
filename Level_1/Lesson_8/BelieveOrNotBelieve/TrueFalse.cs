using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlvOrNotBlv
{

    // Класс описывающий вопрос (состоит из самого вопроса - Text, и ответа на вопрос - TruthFalse)
    [Serializable]
    class Question
    {
        public string Text { get; set; }
        public bool TruthFalse { get; set; }

        public Question()
        {

        }

        public Question(string text, bool truthFalse)
        {
            Text = text;
            TruthFalse = truthFalse;
        }
    }

    // Класс, хранящий список вопросов и методы работы с ним
    class TrueFalse
    {
        public List<Question> listQuestion;
        string fileName;

        string FileName
        {
            set { FileName = value; }
        }

        public TrueFalse(string FileName)
        {
            this.FileName = FileName;
            listQuestion = new List<Question>();
        }

        public void AddQuestion(string text, bool trueFalse)
        {
            listQuestion.Add(new Question(text, trueFalse));
        }

        public void RemoveQuestion(int index)
        {
            if (listQuestion != null && index < listQuestion.Count && index >= 0) listQuestion.RemoveAt(index);
        }

        // Индексатор свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get { return listQuestion[index]; }
        }

        public void SaveToXml()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fileStream, listQuestion);
            fileStream.Close();
        }

        public void LoadXml()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            listQuestion = (List<Question>)xmlFormat.Deserialize(fileStream);
            fileStream.Close();
        }

        public int Count
        {
            get { return listQuestion.Count; }
        }
    }
}
