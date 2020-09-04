using System;
using System.Collections;


namespace Lab3
{
    public interface IComparable
    {
        int CompareTo(object obj);
    }
    interface IPrint
    {
        void Print();
    }
    public abstract class Figure : IComparable
    {
        public abstract double getArea();
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
    class Rectangle : Figure, IPrint
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
        public void Print()
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
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Circle : Figure
    {
        private double rad;

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
        public void Print()
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
            ArrayList list = new ArrayList();
            list.Add(rec);
            list.Add(sq);
            list.Add(circle);
            list.Sort();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }
    }
}
