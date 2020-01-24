/* Задание 5-4
 * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
 * школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит
 * 100, каждая из следующих N строк имеет следующий формат:
 * <Фамилия> <Имя> <оценки>,
 * где <Фамилия> – строка, состоящая не более чем из 20 символов,
 *     <Имя> – строка, состоящая не более чем из 15 символов,
 *     <оценки> – через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
 * <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
 * Пример входной строки:
 * Иванов Петр 4 5 3
 * Требуется написать как можно более эффективную программу, которая будет выводить на экран
 * фамилии и имена трех худших по среднему баллу учеников. Если среди остальных есть ученики,
 * набравшие тот же средний балл, что и один из трех худших, то следует вывести и их фамилии и имена.
 * 
 */

using System;
using System.IO;

namespace Hw_5_4
{
    struct Student
    {
        public string FIO;
        public double grades;
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("data.txt");
            int N = int.Parse(sr.ReadLine());

            Student[] student_array = new Student[N];
            double[] grades_array = new double[3];  // Массив оценок, для подсчета средней оценки в цикле
            double sum_grades;  // Сумма оценок

            for (int i = 0; i < N; i++)
            {
                string[] str_work = sr.ReadLine().Split(' ');   // Разделяем строчку с помощью разделителя

                student_array[i].FIO = str_work[0] + " " + str_work[1];   // Фамилия и имя - первые два слова

                grades_array[0] = double.Parse(str_work[2]);    // Три оценки
                grades_array[1] = double.Parse(str_work[3]);
                grades_array[2] = double.Parse(str_work[4]);

                sum_grades = grades_array[0] + grades_array[1] + grades_array[2];

                student_array[i].grades = sum_grades / 3;   // Считаем среднюю оценку

            }

            sr.Close();

            double[] sort_grades = new double[student_array.Length];    // Создаем массив со средними оценками всех учеников

            for (int i = 0; i < student_array.Length; i++)
            {
                sort_grades[i] = student_array[i].grades;
            }

            Array.Sort(sort_grades);    // Сортируем

            for (int i = 0; i < student_array.Length; i++)  // Выводим тройку худших
            {
                if (student_array[i].grades == sort_grades[0])
                    Console.WriteLine(student_array[i].FIO + " " + student_array[i].grades);

                if (student_array[i].grades == sort_grades[1])
                    Console.WriteLine(student_array[i].FIO + " " + student_array[i].grades);

                if (student_array[i].grades == sort_grades[2])
                    Console.WriteLine(student_array[i].FIO + " " + student_array[i].grades);
            }

        }
    }
}
