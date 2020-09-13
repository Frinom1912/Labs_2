using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        delegate int delegateEx(int a, int b);

        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b; 
        }
        static void Main(string[] args)
        {
            delegateEx obj =  Sum;
            Console.WriteLine(obj.Invoke(4, 5));

        }
    }
}
