using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reflection
{
    [Obsolete]
    internal class Dog
    {
        public bool adopted = false;
        public Dog(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; set; }
        
        [Description("Születési név")]
        public string Name { get; set; }

        [Description("Kutyaugatás")]
        public void Bark()
        {
            Console.WriteLine("Bark");
        }
    }

    class Spaniel : Dog
    {
        public Spaniel(int age, string name) : base(age, name)
        {
        }
    }

    class ValamiAttribute : Attribute
    {
        //...
    }
}
