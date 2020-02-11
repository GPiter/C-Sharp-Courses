/*
 * Класс Удвоитель. Описывает логику работы с числами.
 * 
 */

using System;

namespace DoublerGame
{
    class Doubler
    {
        int count = 0;
        int current = 1;
        int finish;
        int buffer;

        /* ----- ОПИСАНИЕ КОНСТРУКТОРОВ ----- */

        // Задание случайного целевого числа в диапазоне от 2 до 100
        public Doubler()
        {
            Random rnd = new Random();
            finish = rnd.Next(1, 101);
        }

        // Задание целевого числа вручную
        public Doubler(int number)
        {
            finish = number;
        }

        /* ------- ОПИСАНИЕ МЕТОДОВ ------- */

        // Метод увеличения текущего числа на 1
        public void NumbPlusOne()
        {
            buffer = current;
            current += 1;
            count++;
        }

        // Метод умножения текущего числа на 2
        public void NumbMultiplyTwo()
        {
            buffer = current;
            current *= 2;
            count++;
        }

        // Метод сброса текущего числа до 1
        public void NumbReset()
        {
            buffer = current;
            current = 1;
            count++;
        }

        public void NumbCansel()
        {
            current = buffer;
            count++;
        }

        /* ------- ОПИСАНИЕ СВОЙСТВ ------- */

        // Получение текущего значения
        public int GetCurrent
        {
            get { return current; }
        }

        // Получение целевого значения
        public int GetFinish
        {
            get { return finish; }
        }

        // Получение количества ходов
        public int GetCount
        {
            get { return count; }
        }

        // Получение предыдущего значения
        public int GetPrevious
        {
            get { return buffer; }
        }

    }

}
