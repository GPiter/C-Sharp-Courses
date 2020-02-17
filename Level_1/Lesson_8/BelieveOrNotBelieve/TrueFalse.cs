using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BlvOrNotBlv
{

    // Класс описывающий вопрос (состоит из самого вопроса - Text, и ответа на вопрос - TruthFalse)
    [Serializable]
    class Question
    {
        public string Text { get; set; }
        public bool TruthFalse { get; set; }

        // Для сериализации должен быть создан конструктор без параметров
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
        List<Question> listQuestion;
        string fileName;

        public string FileName
        {
            set { FileName = value; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            listQuestion = new List<Question>();
        }

        // Метод добавления вопроса в список
        public void AddQuestion(string text, bool trueFalse)
        {
            listQuestion.Add(new Question(text, trueFalse));
        }

        // Метод удаления вопроса из списка
        public void RemoveQuestion(int index)
        {
            if (listQuestion != null && index < listQuestion.Count && index >= 0) listQuestion.RemoveAt(index);
        }

        // Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get { return listQuestion[index]; }
        }

        // Метод сохранения списка вопросов в xml
        public void SaveToXml()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fileStream, listQuestion);
            fileStream.Close();
        }

        // Метод считывания списка вопросов из xml
        public void LoadXml()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            listQuestion = (List<Question>)xmlFormat.Deserialize(fileStream);
            fileStream.Close();
        }

        // Свойство - количество вопросов в списке
        public int Count
        {
            get { return listQuestion.Count; }
        }
    }
}
