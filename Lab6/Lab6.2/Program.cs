using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._2
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false,
        Inherited = false)]
    public class MyAttribute : System.Attribute
    {
        public string Description { get; set; }
        public MyAttribute()
        {

        }
        public MyAttribute(string Description)
        {
            this.Description = Description;
        }
    }
    public class MyString
    {
        [MyAttribute(Description = "Атрибут MyAttribute: data")]
        public char[] data { get { return _data; } set { data = null; } }
        public int length { get; private set; }
        private char[] _data;
        public MyString()
        {
            data = null;
            length = 0;
        }

        public MyString(char[] str)
        {
            length = str.Length;
            data = new char[length];
            int i = 0;
            foreach (char a in str)
            {
                data[i] = a;
                i++;
            }
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
                Console.Write(data[i]);
        }
        public int getLength() { return length; }
    }

    class Program
    {
        public static bool GetAttributeProperty(PropertyInfo propertyInfo, Type type, out object att)
        {
            bool res = false;
            att = null;
            var isAtt = propertyInfo.GetCustomAttributes(type, false);
            if (isAtt.Length > 0)
            {
                res = true;
                att = isAtt[0];
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tРефлексия");
            Console.ForegroundColor = ConsoleColor.Gray;
            Type type = Type.GetType("Lab6._2.MyString");

            MethodInfo[] methods = type.GetMethods();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вывод методов:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("\t" + method.Name);
            }

            PropertyInfo[] props = type.GetProperties();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод свойств:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (PropertyInfo prop in props)
            {
                Console.WriteLine("\t" + prop.PropertyType.ToString() + " " + prop.Name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод свойств с атрибутом:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var x in props) 
            { 
                object attrObj; 
                if (GetAttributeProperty(x, typeof(MyAttribute), out attrObj)) 
                { 
                    MyAttribute attr = attrObj as MyAttribute; 
                    Console.WriteLine(x.Name + " - " + attr.Description); 
                } 
            }

        }
    }
}
