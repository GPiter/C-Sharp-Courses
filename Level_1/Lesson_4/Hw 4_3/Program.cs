/* Задание 4-3
 * Существует алгоритмическая игра “Удвоитель”. В этой игре человеку предлагается какое-то
 * число, а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число
 * шагов. Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и
 * сбросить число до 1. Начальное значение удвоителя равно 1.
 * Реализовать класс “Удвоитель”. Класс хранит в себе поле current текущее
 * значение, finish число, которого нужно достичь, конструктор, в котором задается конечное число. 
 * Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое
 * возвращает текущее значение, свойство Finish,которое возвращает конечное значение. Создать с
 * помощью этого класса игру, в которой компьютер загадывает число, а человек. выбирая из меню на
 * экране, отдает команды удвоителю и старается получить это число за наименьшее число ходов.
 * Если человек получает число больше положенного, игра прекращается.
 */

using System;

namespace Hw_4_3
{
    class Doubler
    {
        int current = 1;
        int finish;

        public Doubler()
        {
            Random rnd = new Random();
            finish = rnd.Next(1, 11);
        }

        public Doubler(int number)
        {
            finish = number;
        }

        public void NumbPlusOne()
        {
            current += 1;
        }

        public void NumbMultiplyTwo()
        {
            current *= 2;
        }

        public void NumbReset()
        {
            current = 1;
        }

        public int GetCurrent
        {
            get { return current; }
        }

        public int GetFinish
        {
            get { return finish; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            string key;
            int count = 1;
            Doubler numb = new Doubler();

            Console.WriteLine("Добро пожаловать в игру Удвоитель! \nКлавиши управления: \n+ - прибавить 1; \n* - умножить на два; \nr - сбросить до 1 \n\n--------------------\n");
            Console.WriteLine("Компьютер загадал число: " + numb.GetFinish);
            Console.WriteLine("Текущее значение: " + numb.GetCurrent);

            while (!flag)
            {
                Console.Write(":>");
                key = Console.ReadLine();

                switch(key)
                {
                    case "*":
                        numb.NumbMultiplyTwo();
                        break;

                    case "+":
                        numb.NumbPlusOne();
                        break;

                    case "r":
                        numb.NumbReset();
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }

                if (numb.GetCurrent >= numb.GetFinish)
                {
                    Console.WriteLine("Игра окончена! Число ходов: " + count);
                    flag = true;
                }

                else
                {
                    Console.WriteLine("Текущее значение: " + numb.GetCurrent);
                }

                count++;

            }
        }
    }
}
