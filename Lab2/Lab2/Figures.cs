using System;

namespace Lab2
{
    interface IPrint
    {
        void Print();
    }
    public abstract class Figure : IPrint
    {
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public abstract double GetArea();
    }

    class Rectangle : Figure
    {
        protected double length, width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override double GetArea()
        {
            return length * width;
        }
        public override string ToString()
        {
            return $"Фигура:\tПрямоугольник\nВысота:\t{this.length}\n" +
                $"Ширина:\t{this.width}\nПлощадь: {this.GetArea()}\n";
        }
    }

    class Square : Rectangle
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            return $"Фигура:\tКвадрат\nДлина стороны:" +
                $"\t{this.length}\nПлощадь: {this.GetArea()}\n";
        }
    }

    class Circle : Figure
    {
        private double rad;

        public Circle(double rad)
        {
            this.rad = rad;     
        }
        public override double GetArea()
        {
            return rad * rad * Math.PI;
        }
        public override string ToString()
        {
            return $"Фигура:\tКруг\nРадиус:" +
                $"\t{this.rad}\nПлощадь: {this.GetArea()}\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(2, 4.5);
            rec.Print(); 
            
            Square sq = new Square(3);
            sq.Print();

            Circle cr = new Circle(3.14);
            cr.Print();
        }
    }
}
