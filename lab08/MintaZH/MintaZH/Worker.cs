using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MintaZH
{
    public class Worker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public bool Active { get; set; }
        public int NumberOfHolidays { get; set; }
        
        [MinimumChild(2)]
        public int Children { get; set; }
        public List<string> Stacks { get; set; }

        public static List<Worker> Import(string path)
        {
            var xdoc = XDocument.Load(path);

            var workersList = new List<Worker>();
            foreach (var worker in xdoc.Element("workers").Elements("worker"))
            {
                IEnumerable<XElement> stacks = worker.Descendants("stack");
                Worker w = new Worker
                {
                    Name = worker.Element("name").Value,
                    Position = worker.Element("position").Value,
                    Salary = int.Parse(worker.Element("salary").Value),
                    Active = worker.Element("active").Value == "true",
                    NumberOfHolidays = int.Parse(worker.Element("numberofholidays").Value),
                    Children = int.Parse(worker.Element("children").Value),
                    Stacks = stacks.Select(x => x.Value).ToList()
                };
                workersList.Add(w);
            }

            return workersList;
        }
        public override bool Equals(object obj)
        {
            return obj is Worker worker &&
                   Name == worker.Name &&
                   Position == worker.Position &&
                   Salary == worker.Salary &&
                   Active == worker.Active &&
                   NumberOfHolidays == worker.NumberOfHolidays &&
                   Children == worker.Children &&
                   EqualityComparer<List<string>>.Default.Equals(Stacks, worker.Stacks);
        }
    }
}
