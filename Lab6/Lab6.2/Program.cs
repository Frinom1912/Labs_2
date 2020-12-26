using System;
using System.Reflection;
using System.Collections.Generic;

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

    public class MyString : IComparable
    {
        public char[] data;
        [MyAttribute(Description = "Атрибут MyAttribute: важная информация")]
        public char[] Data 
        { 
            get { return data; } 
            set { data = null; } 
        }
        
        private int length;
        
        public int Length { get; private set; }
        
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

        public int CompareTo(object obj)
        {
            if (obj.GetType().Name == "MyString")
            {
                foreach(var field in obj.GetType().GetFields())
                {
                    if (field.GetValue(this) != field.GetValue(obj))
                        return 1;
                }
                return 0;
            }
            return 1;
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
                Console.Write(data[i]);
        }
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
            Console.ResetColor();

            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Информация о сборке:");
            Console.WriteLine(i.FullName + '\n');
            Console.WriteLine("Место расположения сборки:");
            Console.WriteLine(i.Location + '\n');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tИнформация о типе");
            Console.ResetColor();

            Type type = typeof(MyString);

            Console.WriteLine("Пространство имен: " + type.Namespace);
            Console.WriteLine("Наследование: " + type.BaseType.FullName);
            Console.WriteLine("Сборка: " + type.AssemblyQualifiedName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод конструкторов:");
            Console.ResetColor();

            foreach (var construct in type.GetConstructors())
            {
                Console.WriteLine("\t" + construct);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод методов:");
            Console.ResetColor();
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine("\t" + method.Name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод свойств:");
            Console.ResetColor();
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine("\t" + prop.PropertyType.ToString() + " " + prop.Name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод public полей:");
            Console.ResetColor();
            foreach (var prop in type.GetFields())
            {
                Console.WriteLine("\t" + prop.Name);
            }

            Console.WriteLine("\nMyString реализует IComparable -> " + new HashSet<Type>(type.GetInterfaces()).Contains(typeof(IComparable)));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВывод свойств с атрибутом:");
            Console.ResetColor();
            foreach (var x in type.GetProperties())
            {
                object attrObj;
                if (GetAttributeProperty(x, typeof(MyAttribute), out attrObj))
                {
                    MyAttribute attr = attrObj as MyAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВызов метода:");
            Console.ResetColor();
            char[] arr = { '1', '2', '3', '4' };
            MyString str = new MyString(arr);
            type.InvokeMember("Print", BindingFlags.InvokeMethod, null, str, new object[] { });
            Console.ReadLine();
        }
    }
}
