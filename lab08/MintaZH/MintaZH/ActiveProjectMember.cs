using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    public class ActiveProjectMember
    {
        [Key]
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"*****\nName: {Name}\nPosition: {Position}\nSalary: {Salary}\n*****\n\n";
        }
    }
}
