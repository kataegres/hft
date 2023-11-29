using System;
using System.Collections.Generic;
using System.Linq;

namespace MintaZH
{
    class Program
    {
        static void AddToDatabase(IEnumerable<ActiveProjectMember> member)
        {
            var dbContext = new ActiveProjectMemberDbContext();

            dbContext.Members.ToList().ForEach(x => dbContext.Members.Remove(x));
            dbContext.Members.AddRange(member);
            dbContext.SaveChanges();

            var dbData = from members in dbContext.Members
                         select members;

            foreach (var item in dbData)
            {
                Console.WriteLine(item);
            }
        }

        static void Linq(List<Worker> workers)
        {
            // -Mennyi a Juniorok össz fizetése?
            var q1 = workers.Where(x => x.Position == "Junior").Sum(x => x.Salary);

            Console.WriteLine($"Juniorok összfizetése: {q1}");

            // -Hányan értenek a Javahoz? 
            var q2 = workers.Where(x => x.Stacks.Contains("Java")).Count();

            Console.WriteLine($"Ennyien értenek a Javahoz: {q2}");

            // -Mennyi az átlag fizetése az aktív dolgozóknak?
            var q3 = Math.Round(workers.Where(x => x.Active).Average(x => x.Salary), 2);

            Console.WriteLine($"Aktív dolgozók átlagfizetése: {q3}");

            // -Ki rendelkezik a legnagyobb technológiai stackkel?

            var q4 = from worker in workers
                     orderby worker.Stacks.Count descending
                     select new
                     {
                         worker.Name,
                         StackCount = worker.Stacks.Count
                     };

            foreach (var item in q4.Take(1))
            {
                Console.WriteLine($"Legnagyobb stack: {item.Name}, {item.StackCount} db");
            }

            // -Mennyi az átlag fizu pozicióként?
            var q5 = from worker in workers
                     group worker by worker.Position
                     into positions
                     select new
                     {
                         Position = positions.Key,
                         AvgSalary = positions.Average(x => x.Salary)
                     };

            foreach (var item in q5)
            {
                Console.WriteLine(item.Position + ": " + item.AvgSalary);
            }

            Console.WriteLine();

            // Válasszuk ki azokat a .Net fejleszőket akik vagy medior vagy senior szinten vannak.
            var q6 = from worker in workers
                     where worker.Stacks.Contains(".Net") &&
                     (worker.Position.ToLower().Equals("medior")
                        || worker.Position.ToLower().Equals("senior"))
                     select new ActiveProjectMember
                     {
                         Name = worker.Name,
                         Salary = worker.Salary,
                         Position = worker.Position
                     };

            AddToDatabase(q6);
        }
    
        static void Main(string[] args)
        {
            var workers = Worker.Import("workers.xml");
            ;

            var result = WorkerFilter.Filter(workers);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + ": " + item.Children);
            }
            Console.WriteLine();

            Linq(workers);
        }
    }
}
