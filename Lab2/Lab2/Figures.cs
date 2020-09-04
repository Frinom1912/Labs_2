using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IPrint
    {
        void Print();
    }
    public abstract class Figure
    {
        public abstract double getArea();
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
            Circle a = new Circle(4.5);
            a.Print();
        }
    }
}
