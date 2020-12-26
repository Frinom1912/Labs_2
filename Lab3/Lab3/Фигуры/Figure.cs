using System;

namespace Lab3
{
    abstract class Figure : IComparable, IPrint
    {
        protected string Type;
        public abstract double getArea();
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
        public int CompareTo(object obj)
        {
            Figure robj = obj as Figure;
            if (robj != null)
            {
                return this.getArea().CompareTo(robj.getArea());
            }
            else
                throw new InvalidOperationException(message:"Несравнимые объекты");
        }
        public override string ToString()
        {
            return $"[{this.Type} площадью {this.getArea()}]";
        }
    }
}
