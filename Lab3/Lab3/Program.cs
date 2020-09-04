using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    interface IPrint
    {
        void Print();
    }
    abstract class Figure : IComparable, IPrint
    {
        public abstract double getArea();
        public abstract void Print();
        public int CompareTo(object obj)
        {
            Figure robj = obj as Figure;
            if (robj != null)
            {
                return this.getArea().CompareTo(robj.getArea());
            }
            else
                throw new Exception("Несравнимые объекты");
        }
    }
    class Rectangle : Figure
    {
        protected double length, width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override double getArea()
        {
            return length * width;
        }
        public override string ToString()
        {
            return $"Фигура:\tПрямоугольник\nВысота:\t{this.length}\nШирина:\t{this.width}\nПлощадь: {this.getArea()}\n";
        }
        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rectangle
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            return $"Фигура:\tКвадрат\nДлина стороны:\t{this.length}\nПлощадь: {this.getArea()}\n";
        }
        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Circle : Figure
    {
        protected double rad;

        public Circle(double rad)
        {
            this.rad = rad;
        }
        public override double getArea()
        {
            return rad * rad * Math.PI;
        }
        public override string ToString()
        {
            return $"Фигура:\tКруг\nРадиус:\t{this.rad}\nПлощадь: {this.getArea()}\n";
        }
        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(4.5, 2);
            Square sq = new Square(3.14);
            Circle circle = new Circle(1);

            ArrayList alist = new ArrayList();
            alist.Add(rec);
            alist.Add(sq);
            alist.Add(circle);
            alist.Sort();
            for (int i = 0; i < alist.Count; i++)
                Console.WriteLine(alist[i]);

            List<Figure> list = new List<Figure>();
            list.Add(rec);
            list.Add(sq);
            list.Add(circle);
            list.Sort();
            for (int i = 0; i < alist.Count; i++)
                Console.WriteLine(alist[i]);


        }
    }
}
