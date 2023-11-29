using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    class MinimumChildAttribute : Attribute
    {
        public int Number { get; }
        public MinimumChildAttribute(int num)
        {
            Number = num;
        }
    }
}
