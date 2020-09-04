using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Бондаренко Иван Геннадьевич ИУ5-31Б");
            string line;
            int[] k = new int[3];
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Коэффициент " + (char)('a' + i));
                    line = Console.ReadLine();
                    bool flag = true;
                    foreach (char sym in line)
                    {
                        if (sym >= '0' && sym <= '9')
                            continue;
                        else
                        {
                            flag = !flag;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка, неприемлемый ввод!");
                            break;
                        }
                    }
                    if(flag)
                    {
                        k[i] = Convert.ToInt32(line);
                        break;
                    }
                }
                Console.WriteLine(k[i]);
            }
            double D = k[1] * k[1] - 4 * k[0] * k[2];
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет решений");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (D == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Два корня: " + (-1 * k[1]) / (2 * k[0]));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корень 1: " + ((-1 * k[1]) + Math.Sqrt(D) / (2 * k[0])) + "Корень 2: " + ((-1 * k[1]) - Math.Sqrt(D) / (2 * k[0])));
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
