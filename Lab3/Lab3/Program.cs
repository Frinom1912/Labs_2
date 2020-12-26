using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объекты фигур
            Rectangle rec = new Rectangle(4.5, 2);
            Square sq = new Square(3.14);
            Circle circle = new Circle(1);

            // Проверка через ArrayList
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tArrayList");
            Console.ResetColor();
            ArrayList alist = new ArrayList();
            
            alist.Add(4);
            alist.Add(sq);
            alist.Add(rec);
            alist.Add(circle);
            
            foreach (object item in alist)
                Console.WriteLine(item);

            try
            {
                alist.Sort();
            }
            catch (InvalidOperationException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('\n'+e.Message);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПосле сортировки:\n");
            Console.ResetColor();
            
            foreach (object item in alist)
                Console.WriteLine(item);

            alist.Remove(4);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nУдаление мешающего элемента\n");
            Console.ResetColor();
            
            foreach (object item in alist)
                Console.WriteLine(item);

            alist.Sort();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПосле сортировки:\n");
            Console.ResetColor();
            
            foreach (object item in alist)
                Console.WriteLine(item);

            // Проверка через List<>
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tList<Figure>");
            Console.ResetColor();
            List<Figure> list = new List<Figure>();
            list.Add(rec);
            list.Add(sq);
            list.Add(circle);
            foreach (Figure item in list)
                Console.WriteLine(item);
            list.Sort();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПосле сортировки:\n");
            Console.ResetColor();
            
            foreach (Figure item in list)
                Console.WriteLine(item);

            // Проверка доработанной трехмерной матрицы
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tМатрица");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix<Figure> matrix = new Matrix<Figure>(new FigureMatrixCheckEmpty(), 3, 3, 3);
            matrix[0, 0, 0] = rec;
            matrix[1, 0, 1] = sq;
            matrix[1, 1, 1] = sq;
            matrix[2, 2, 0] = circle;
            Console.WriteLine(matrix.ToString());

            // Проверка SimpleStack
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tSimpleStack<Figure>");
            Console.ForegroundColor = ConsoleColor.Gray;
            SimpleStack<Figure> slist = new SimpleStack<Figure>();
            slist.Push(rec);
            slist.Push(sq);
            slist.Push(circle);
            while(slist.Count != 0)
                slist.Pop().Print();
            slist.Push(rec);
            slist.Push(sq);
            slist.Push(circle);
            slist.Sort();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПосле сортировки:\n");
            Console.ResetColor();

            foreach (Figure item in slist)
                Console.WriteLine(item);

            Console.WriteLine("\n");
        }
    }
}
