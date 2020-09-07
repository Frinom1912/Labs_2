using System;

namespace Lab3
{
    class Circle : Figure
    {
        protected double rad;

        public Circle(double rad)
        {
            this.rad = rad;
            Type = "Круг";
        }
        public override double getArea()
        {
            return rad * rad * Math.PI;
        }
    }
}
