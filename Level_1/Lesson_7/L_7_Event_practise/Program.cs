/* Порядок создания событий
 * 1. Определите условие возникновения события и методы, которые должны сработать.
 * 2. Определите сигнатуру этих методов и создайте делегат на основе этой сигнатуры.
 * 3. Создайте общедоступное событие на основе этого делегата и вызовите, когда условие сработает.
 * 4. Обязательно (где-угодно) подпишитесь на это событие теми методами, которые должны сработать и сигнатуры которых подходят к делегату.      
*/

using System;

namespace L_7_Event_practise
{
    class Counter   // Класс, который выполняет определенные действия, при выполнении которых необходимо определенным образом реагировать
    {
        public delegate void EventCollection();     // Описание делегата - сигнатуры функций, которые событие будет принимать

        public event EventCollection EventShowMsg;  // Описание события: public event <НазваниеДелегата> <НазваниеСобытия> 

        public void Count()
        {
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine("i = " + i);
                if( i == 3)
                {
                    EventShowMsg(); // Если i = 3, вызывается событие (а событие описывается делегатом, хранящий сигнатуру методов, и вызывающий в свою очередь необходимые методы)
                }
            }
        }
    }

    class Handler_I // Подписчик 1
    {
        public void PrintMsg()  // Метод, реагирующий на событие
        {
            Console.WriteLine("Произошло событие! похоже, i = 3...");
        }
    }

    class Handler_II // Подписчик 2
    {
        public void PrintMsg()  // Метод, реагирующий на событие
        {
            Console.WriteLine("Точно! i = 3!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Counter TestEventCount = new Counter();
            Handler_I Handler_1 = new Handler_I();
            Handler_II Handler_2 = new Handler_II();

            // Подписка на событие: <КлассИлиОбъект>.<ИмяСобытия> += <КлассЧейМетодДолженЗапуститься>.<МетодПодходящийПоСигнатуре>
            TestEventCount.EventShowMsg += Handler_1.PrintMsg;
            TestEventCount.EventShowMsg += Handler_2.PrintMsg;

            TestEventCount.Count();
        }
    }
}
