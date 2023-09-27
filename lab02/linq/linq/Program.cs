using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace linq
{
    class Student
    {
        public Student(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }

        public string Name { get; set; }
        public int Credits { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 8, 3, 1, 5, 4, 3 };
            string[] avengers = { "Tony", "Thor", "Peter", "Sam", "Wanda", "Natasha" };

            List<Student> students = new List<Student>();
            students.Add(new Student("Kovács András", 34));
            students.Add(new Student("Nagy Réka", 123));
            students.Add(new Student("Horváth Ádám", 78));
            students.Add(new Student("Sipos Miklós", 201));

            // OrderBy
            var result = numbers.OrderBy(x => x);
            ;
            var result2 = avengers.OrderByDescending(x => x.Length);
            ;

            // Where / Count
            var result3 = numbers.Where(x => x % 2 == 1);
            ;
            var result4 = avengers.Count(x => x.Length == 5);
            ;

            // Szűrés
            var result5 = students.Where(x => x.Credits % 2 == 0);
            ;

            // Kiválasztás
            var result6 = students.Select(x => x.Name);
            ;

            var result7 = students.Where(x => x.Credits % 2 == 1).OrderBy(x => x.Name).Reverse().Select(x => x.Name.ToUpper());
            ;

            // Query syntax
            var result8 = from x in students
                          where x.Credits % 2 == 1
                          orderby x.Name descending
                          select x.Name.ToUpper();
            ;

            // Aggregálás
            var result9 = numbers.Sum();
            ;
            var result10 = numbers.Average();
            ;

            // GroupBy
            var result11 = numbers.GroupBy(x => x % 2);
            foreach (var g in result11)
            {
                Console.WriteLine($"{g.Key}: {g.Count()}");
            }

            // Load xml
            XDocument xdoc = XDocument.Load("http://users.nik.uni-obuda.hu/prog3/_data/war_of_westeros.xml");
            Console.WriteLine(xdoc);

            // Example
            var res = xdoc.Descendants("name").Select(x => x.Value).Distinct();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            };

        }
    }
}
