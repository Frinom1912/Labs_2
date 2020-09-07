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
            Console.ForegroundColor = ConsoleColor.Gray;
            ArrayList alist = new ArrayList();
            alist.Add(sq);
            alist.Add(rec);
            alist.Add(circle);
            foreach (Figure item in alist)
                Console.WriteLine(item);
            alist.Sort();
            Console.WriteLine("\nПосле сортировки:\n");
            foreach (Figure item in alist)
                Console.WriteLine(item);

            // Проверка через List<>
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tList<Figure>");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Figure> list = new List<Figure>();
            list.Add(rec);
            list.Add(sq);
            list.Add(circle);
            foreach (Figure item in list)
                Console.WriteLine(item);
            list.Sort();
            Console.WriteLine("\nПосле сортировки:\n");
            foreach (Figure item in list)
                Console.WriteLine(item);

            // Проверка доработанной трехмерной матрицы
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tМатрица");
            Console.ForegroundColor = ConsoleColor.Gray;
            Matrix<Figure> matrix = new Matrix<Figure>(new FigureMatrixCheckEmpty(), 3, 3, 3);
            matrix[0, 0, 0] = rec;
            matrix[1, 1, 1] = sq;
            matrix[2, 2, 0] = circle;
            Console.WriteLine(matrix.ToString());

            // Проверка SimpleStack
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tSimpleStack<Figure>");
            Console.ForegroundColor = ConsoleColor.Gray;
            SimpleStack<Figure> slist = new SimpleStack<Figure>();
            slist.Add(rec);
            slist.Add(sq);
            slist.Add(circle);
            foreach (Figure item in slist)
                Console.WriteLine(item);
            slist.Sort();
            Console.WriteLine("\nПосле сортировки:\n");
            foreach (Figure item in slist)
                Console.WriteLine(item);

            Console.WriteLine("\n");
        }
    }
}
