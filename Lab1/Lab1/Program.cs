using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        /// <summary>
        /// Получение корней уравнения в зависимости от коэффициентов
        /// </summary>
        /// <param name="ks">Коэффициенты уравнения</param>
        static void getResults(int[] ks)
        {
            double D = ks[1] * ks[1] - 4 * ks[0] * ks[2];
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет решений");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (D == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Два корня корня: " + Math.Sqrt((-1 * ks[1]) / (2 * ks[0])) + " и два корня: " + -1 * Math.Sqrt((-1 * ks[1]) / (2 * ks[0])));
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корень 1: " + Math.Sqrt((((-1 * ks[1]) + Math.Sqrt(D)) / (2 * ks[0]))) + "\nКорень 2: " + -1 * Math.Sqrt((((-1 * ks[1]) + Math.Sqrt(D)) / (2 * ks[0]))) + "\nКорень 3: " + Math.Sqrt((((-1 * ks[1]) - Math.Sqrt(D)) / (2 * ks[0]))) + "\nКорень 4: " + -1 * Math.Sqrt((((-1 * ks[1]) - Math.Sqrt(D)) / (2 * ks[0]))));
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

        }
        /// <summary>
        /// Считывание коэффициентов с консоли
        /// </summary>
        /// <param name="number">Текущий номер параметра</param>
        /// <returns>Полученный и распаршеный коэффициент</returns>
        static int getK(int number)
        {
            int k = 0;
            bool res = false;
            while (!res)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Коэффициент " + (char)('a' + number) + ": ");
                string line = Console.ReadLine();
                if (line != "")
                {
                    res = Int32.TryParse(line, out k);
                }
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат коэффициента!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return k;
        }
        /// <summary>
        /// Проверяет аргументы при запуске с консоли
        /// </summary>
        /// <param name="args">Массив аргументов при запуске</param>
        /// <returns>Массив численных аргументов</returns>
        static int[] checkArgs(string[] args)
        {
            int[] ks = default(int[]);
            if (args.Length > 0 && args.Length != 3)
                throw new FormatException("Недостаточно аргументов");
            else
            {
                if (args.Length == 0)
                    return null;
                else
                {
                    if (args.Length == 3)
                    {
                        ks = new int[3];
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (!Int32.TryParse(args[i], out ks[i]))
                                throw new FormatException("Неверный формат коэффициента в аргументе консоли!");
                        }
                        return ks;
                    }
                }
            }
            return null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Бондаренко Иван Геннадьевич ИУ5-31Б");
            int[] ks;

            try
            {
                ks = checkArgs(args);
            }
            catch(FormatException e)
            {
                ks = null;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (ks == null)
            {
                ks = new int[3];

                for (int i = 0; i < 3; i++)
                {
                    ks[i] = getK(i);
                }
            }
            getResults(ks);
        }
    }
}
