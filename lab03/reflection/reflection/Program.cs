using System;
using System.Collections.Generic;
using System.Reflection;

namespace reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Típusinformáció osztályról
            Type t = typeof(int);
            Type t2 = typeof(string);
            Type t3 = typeof(List<int>);
            Type t4 = typeof(Dog);
            ;

            // Objektumról
            Dog d = new Dog(2, "Morzsi");
            Spaniel s = new Spaniel(2, "Morzsi");
            GetInfo(s);

            // Tulajdonság
            PropertyInfo info = typeof(Dog).GetProperty("Age");
            ;
            Console.WriteLine(info);
        }
        static void GetInfo(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine(t.Name);
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.BaseType);
        }
    }
}
