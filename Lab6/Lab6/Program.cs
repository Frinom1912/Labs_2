using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public delegate int delegateEx(int a, int b);

        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b; 
        }

        public static int SimpleCalc(int a, int b, delegateEx deg)
        {
            return deg.Invoke(a, b);
        }

        public static int SimpleCalcFunc(int a, int b, Func<int,int,int> deg)
        {
            return deg.Invoke(a, b);
        }

        static void Main(string[] args)
        {
            int a, b;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tДелегаты");
            Console.ForegroundColor = ConsoleColor.Gray;
            while (true)
            {
                Console.Write("Введите число №1: ");
                string line = Console.ReadLine();
                if (!Int32.TryParse(line, out a))
                {
                    Console.WriteLine("Ошибка ввода!");
                }
                else
                    break;
            }
            while (true)
            {
                Console.Write("Введите число №2: ");
                string line = Console.ReadLine();
                if (!Int32.TryParse(line, out b))
                {
                    Console.WriteLine("Ошибка ввода!");
                }
                else
                    break;
            }

            Console.Write($"Функция в качестве аргумента: {a} + {b} = ");
            Console.WriteLine(SimpleCalc(a, b, Sum));
            Console.Write($"Лямбда-выражение в качестве аргумента: {a} + {b} = ");
            Console.WriteLine(SimpleCalc(a, b, (m, n) => (m + n)));
            Func<int, int, int> res = Sum;
            Console.Write($"Func<> в качестве аргумента: {a} + {b} = ");
            Console.WriteLine(SimpleCalcFunc(a, b, res));
        }
    }
}
