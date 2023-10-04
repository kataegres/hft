using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog a = new Dog(3, "Morzsi");
            Dog b = new Dog(-5, "Morzsi");
            Dog c = new Dog(1, "Morzsiiiiiiiiiiiiiiiii");

            Validator v = new Validator();
            Console.WriteLine(v.Validate(a));
            Console.WriteLine(v.Validate(b));
            Console.WriteLine(v.Validate(c));
        }
    }

    class Dog
    {
        public Dog(int age, string name)
        {
            Age = age;
            Name = name;
        }

        [RangeAttribute(0, 20)]
        public int Age { get; set; }

        [MaxLengthAttribute(20)]
        public string Name { get; set; }
    }
}
