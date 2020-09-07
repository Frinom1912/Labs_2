namespace Lab3
{
    class Rectangle : Figure
    {
        protected double length, width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
            Type = "Прямоугольник";
        }
        public override double getArea()
        {
            return length * width;
        }
    }
}
