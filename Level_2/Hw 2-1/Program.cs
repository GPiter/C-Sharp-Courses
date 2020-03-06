/*
 Построить три класса (базовый и 2 потомка), описывающих некоторых работников
с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной
платы. Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата
= 20.8 * 8 * почасовую ставку»,для работников с фиксированной оплатой «среднемесячная
заработная плата = фиксированной месячной оплате».
б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
в) **Реализовать интерфейсы для возможности сортировки массива используя Array.Sort().
г) ***Реализовать возможность вывода данных с использованием foreach

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_2_2_1
{
    abstract class BaseObject:IComparable
    {
        protected string name;
        public abstract int CompareTo(object obj);
        public abstract double Payment();
    }

    class WorkerConst : BaseObject
    {

        double fix_pay;

        public WorkerConst(string name, double fix_pay)
        {
            this.name = name;
            this.fix_pay = fix_pay;
        }

        public override double Payment()
        {
            return fix_pay;
        }

        public override int CompareTo(object obj)
        {
            BaseObject compareObj = obj as BaseObject;
            if (compareObj != null)
                return this.Payment().CompareTo(compareObj.Payment());
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override string ToString()
        {
            return name + " - " + Payment().ToString();
        }
    }

    class WorkerFree : BaseObject
    {
        double hourly_rate;

        public WorkerFree(string name, double hourly_rate)
        {
            this.name = name;
            this.hourly_rate = hourly_rate;    
        }

        public override double Payment()
        {
            return 20.8 * 8 * hourly_rate;
        }

        public override int CompareTo(object obj)
        {
            BaseObject compareObj = obj as BaseObject;
            if (compareObj != null)
                return this.Payment().CompareTo(compareObj.Payment());
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override string ToString()
        {
            return name + " - " + Payment().ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BaseObject[] workers = new BaseObject[4];

            workers[0] = new WorkerConst("Петр - постоянная зп", 120000);
            workers[1] = new WorkerFree("Василий - (700/ч.)", 700);
            workers[2] = new WorkerConst("Иван - постоянная зп", 60000);
            workers[3] = new WorkerFree("Илья - (300/ч.)", 300);

            Array.Sort(workers);

            foreach (BaseObject obj in workers)
                Console.WriteLine(obj.ToString());
        }
    }
}
