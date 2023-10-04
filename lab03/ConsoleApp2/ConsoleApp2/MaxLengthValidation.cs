using System;
using System.Reflection;

namespace ConsoleApp2
{
    internal class MaxLengthValidation : IValidation
    {
        MaxLengthAttribute maxLength;

        public MaxLengthValidation(MaxLengthAttribute maxLength)
        {
            this.maxLength = maxLength;
        }

        // Name
        public bool Validate(object obj, PropertyInfo info)
        {
            var value = (string)info.GetValue(obj);
            return value.Length <= maxLength.Length;
        }
    }
}