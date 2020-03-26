/*
 * а) Сверните обращение к OrderBy с использованием лямбда выражения
 * б) *Разверните обращение к OrderBy с использованием делегата Predicate<T>
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four" , 4 },
                { "two" , 2 },
                { "one" , 1 },
                { "three" , 3 },
            };

            // Решение 1 - с помощью анонимного метода
            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; } );

            // Решение 2 - с помощью лямбда выражения
            //var d = dict.OrderBy(p => p.Value);

            // Решение 3 - с помощью делегата Func
            Func<KeyValuePair<string, int>, int> func = new Func<KeyValuePair<string, int>, int>(MethodInt);

            var d = dict.OrderBy(func);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}" , pair . Key , pair . Value );
            }

        }

        static int MethodInt(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }

    }
}
