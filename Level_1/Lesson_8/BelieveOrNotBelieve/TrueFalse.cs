using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BelieveOrNotBelieve
{
    // Класс описывающий вопрос (состоит из самого вопроса - Text, и ответа на вопрос - TruthFalse)
    [Serializable]
    public class Question
    {
        public string Text { get; set; }
        public bool Truth { get; set; }

        // Для сериализации должен быть создан конструктор без параметров
        public Question()
        {

        }

        public Question(string text, bool truth)
        {
            Text = text;
            Truth = truth;
        }

    }

    // Класс, хранящий список вопросов и методы работы с ним
    class TrueFalse
    {
        List<Question> listQuestion = new List<Question>();

        public List<Question> ListQuestion
        {
            get { return listQuestion; }
            set { listQuestion = value; }
        }

        // Метод сохранения списка вопросов в xml
        public void SaveToXml(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, listQuestion);
            fStream.Close();
        }

        // Метод считывания списка вопросов из xml
        public void LoadXml(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            listQuestion = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

    }
}
