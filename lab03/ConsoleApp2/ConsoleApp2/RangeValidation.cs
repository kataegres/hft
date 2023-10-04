using System;
using System.Reflection;

namespace ConsoleApp2
{
    internal class RangeValidation : IValidation
    {
        RangeAttribute range;

        public RangeValidation(RangeAttribute range)
        {
            this.range = range;
        }

        // Age
        public bool Validate(object obj, PropertyInfo info)
        {
            var value = (int)info.GetValue(obj);
            return value >= range.Min && value <= range.Max;
        }
    }
}