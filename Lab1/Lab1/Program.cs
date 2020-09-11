using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static int getK(int number)
        {
            int k = 0;
            bool res = false;
            while (!res)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Коэффициент " + (char)('a' + number) + ": ");
                string line = Console.ReadLine();
                res = Int32.TryParse(line, out k);
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат коэффициента!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return k;
        }
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
                            bool res = Int32.TryParse(args[i], out ks[i]);
                            if (!res)
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
                Console.WriteLine(e.Message);
            }

            if (ks == null)
            {
                ks = new int[3];

                for (int i = 0; i < 3; i++)
                {
                    ks[i] = getK(i);
                }
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
                        Console.WriteLine("Два корня корня: " + Math.Sqrt((-1 * ks[1]) / (2 * ks[0])) + "и два корня: " + -1* Math.Sqrt((-1 * ks[1]) / (2 * ks[0]))) ;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корень 1: " + Math.Sqrt((((-1 * ks[1]) + Math.Sqrt(D)) / (2 * ks[0]))) + "\nКорень 2: " + -1*Math.Sqrt((((-1 * ks[1]) + Math.Sqrt(D)) / (2 * ks[0])))+ "\nКорень 3: " + Math.Sqrt((((-1 * ks[1]) - Math.Sqrt(D)) / (2 * ks[0])))+ "\nКорень 4: " + -1*Math.Sqrt((((-1 * ks[1]) - Math.Sqrt(D)) / (2 * ks[0]))));
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }
    }
}
