/* Задание 3_1
 * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
 * Продемонстрировать работу структуры;
 * б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить
 * работу класса;
 *
 */

using System;

namespace Lesson_3
{
    struct Complex
    {
        public double im;
        public double re;

        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = im * x.im + re * x.im;
            y.re = re * x.im - im * x.re;
            return y;
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    class Complex_class
    {
        private double re, im;

        public Complex_class()
        {
            re = 0;
            im = 0;
        }

        public Complex_class(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public double Im
        {
            get { return im; }
            set
            {
                if (value >= 0) im = value;
            }
        }

        public Complex_class Plus(Complex_class x)
        {
            Complex_class z = new Complex_class();
            z.im = im + x.im;
            z.re = re + x.re;
            return z;
        }

        public Complex_class Minus(Complex_class x)
        {
            Complex_class z = new Complex_class();
            z.im = im - x.im;
            z.re = re - x.re;
            return z;
        }

        public Complex_class Multi(Complex_class x)
        {
            Complex_class z = new Complex_class();
            z.im = im * x.im + re * x.im;
            z.re = re * x.im - im * x.re;
            return z;
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex a, b;
            a.im = 1; a.re = 2;
            b.im = 3; b.re = 1;

            Complex z = a.Minus(b);
            Complex m = a.Multi(b);

            Console.WriteLine(z.ToString());
            Console.WriteLine(m.ToString());

            Complex_class x;
            x = new Complex_class(3, 5);
            Complex_class y = new Complex_class(11,-4);

            y.Im = -10;

            Complex_class res;
            res = x.Plus(y);
            Console.WriteLine(res.ToString());

        }
    }
}
