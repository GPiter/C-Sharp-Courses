/* Задание 6-3
 * Есть файл в формате csv представляющий собой информацию о студентах.
 * Считать файл и решить следующие задачи:
 * Подсчитать количество студентов,
 * а) учащихся на 5 и 6 факультетах;
 * б) подсчитайте сколько студентов на каком курсе учатся;
 * в) отсортируйте список по возрасту студента
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace Hw_6_3
{
    class Student
    {
        public string firstName;
        string secondName;
        string univercity;
        string faculty;
        string department;
        public int age;
        public int course;
        int group;
        string city;

        public Student(string firstName, string secondName, string univercity, string faculty, string department, int age, int course, int group, string city)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.univercity = univercity;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }
    }

    class Program
    {
        static int SortBySurname(Student student_1, Student student_2)
        {
            return String.Compare(student_1.firstName, student_2.firstName);
        }

        static int SortByAge(Student student_1, Student student_2)
        {
            if (student_1.age > student_2.age) return -1;
            if (student_1.age < student_2.age) return 1;
            return 0;
        }

        static void Main(string[] args)
        {
            int bachelor = 0;
            int master = 0;
            int count_5_faculty = 0;
            int count_6_faculty = 0;
            int[] course_counter = new int[7];  // Частотный массив
            List<Student> student_list = new List<Student>();
            DateTime dt = DateTime.Now;

            StreamReader sr = new StreamReader("students.csv");

            while(!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    student_list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[6]) < 5) bachelor++;
                    if (s[3] == "5") count_5_faculty++;
                    if (s[3] == "6") count_6_faculty++;
                    else master++;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка! ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            student_list.Sort(new Comparison<Student>(SortByAge)); // Передаем делегат - сортировка по возрасту
            Console.WriteLine("Всего студентов: " + student_list.Count);
            Console.WriteLine("Магистров: {0}", master);
            Console.WriteLine("Бакалавров: {0}", bachelor);

            Console.WriteLine("Учащихся на 5 факультете: {0}", count_5_faculty);    // Количество учащихся на 5 и 6 факультетах
            Console.WriteLine("Учащихся на 6 факультете: {0}", count_6_faculty);

            foreach (var student in student_list)   // Вывод отсортированных по возрасту студентов
            {
                Console.WriteLine(student.firstName);
                Console.WriteLine(student.age);
            }

            foreach (var student in student_list)   // Заполняем частотный массив, в зависимости от курса студента. i-ый курс соответствует i-ому элементу массива
            {
                course_counter[student.course] += 1;
            }

            for (int i = 1; i < course_counter.Length; i++) // Выводим количество студентов на каждом курсе
            {
                if (course_counter[i] != 0)
                    Console.WriteLine("На " + i + " факультете учится " + course_counter[i] + " студентов");
            }

            Console.WriteLine(DateTime.Now - dt);
        }
    }
}
