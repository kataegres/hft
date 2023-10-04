using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class RangeAttribute : Attribute
    {
        public RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; set; }
        public int Max { get; set; }
    }

    internal class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int length)
        {
            Length = length;
        }
        public int Length { get; set; }

    }
}
