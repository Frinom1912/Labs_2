using System;
namespace Lab1
{
    class Program
    {
        /// <summary>
        /// Получение корней уравнения в зависимости от коэффициентов
        /// </summary>
        /// <param name="ks">Коэффициенты уравнения</param>
        static void GetResults(double[] ks)
        {  
            
            double D = ks[1] * ks[1] - 4 * ks[0] * ks[2];
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Дискриминант меньше 0 - Нет действительных решений");
                Console.ResetColor();
            }
            else
            {
                if (D == 0)
                {
                    double y = (-1 * ks[1]) / (2 * ks[0]);

                    if (y < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нет действительных решений");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Два корня: " + -1*Math.Sqrt(y) + "\nДва корня: " + Math.Sqrt(y));
                        Console.ResetColor();
                    }
                    
                }
                else
                {
                    double y1 = ((-1 * ks[1]) + Math.Sqrt(D)) / (2 * ks[0]);
                    double y2 = ((-1 * ks[1]) - Math.Sqrt(D)) / (2 * ks[0]);
                    if (y1 < 0 && y2 < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нет действительных решений");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (y1 >= 0 && y2 >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Корень №1: " + Math.Sqrt(y1) + "\nКорень №2: " + 
                                + -1 * Math.Sqrt(y1) + "\nКорень №3: " + Math.Sqrt(y2) + "\nКорень №4: " + 
                                + -1 * Math.Sqrt(y2));
                            Console.ResetColor();
                        }
                        else
                        {
                            if (y1 < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Корень №1: " + Math.Sqrt(y2) + "\nКорень №2: " + 
                                    + -1 * Math.Sqrt(y2));
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Два остальных корня явлюятся мнимыми");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (y2 < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Корень №1: " + Math.Sqrt(y1) + 
                                        "\nКорень №2: " + -1 * Math.Sqrt(y1));
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Два остальных корня явлюятся мнимыми");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Считывание коэффициентов с консоли
        /// </summary>
        /// <param name="number">Текущий номер параметра</param>
        /// <returns>Полученный и распаршеный коэффициент</returns>
        static double GetK(int number)
        {
            double k = 0;
            bool res = false;
            while (!res)
            {
                Console.ResetColor();
                Console.Write("Коэффициент " + (char)('a' + number) + ": ");
                string line = Console.ReadLine();
                if (line != "")
                {
                    res = Double.TryParse(line, out k);
                }
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат коэффициента!");
                    Console.ResetColor();
                }
            }
            return k;
        }
        /// <summary>
        /// Проверяет аргументы при запуске с консоли
        /// </summary>
        /// <param name="args">Массив аргументов при запуске</param>
        /// <returns>Массив численных аргументов</returns>
        static double[] CheckArgs(string[] args)
        {
            double[] ks = default(double[]);
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
                        ks = new double[3];
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (!Double.TryParse(args[i], out ks[i]))
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
            Console.WriteLine("Студент: Бондаренко Иван");
            Console.WriteLine("Группа: ИУ5-31Б\n");
            double[] ks;

            try
            {
                ks = CheckArgs(args);
            }
            catch(FormatException e)
            {
                ks = null;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            if (ks == null)
            {
                ks = new double[3];

                for (int i = 0; i < 3; i++)
                {
                    ks[i] = GetK(i);
                }
            }
            GetResults(ks);
            Console.ReadLine();
        }
    }
}
