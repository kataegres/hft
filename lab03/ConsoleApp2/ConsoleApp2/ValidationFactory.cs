using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ValidationFactory
    {
        public IValidation GetValidation(Attribute attr)
        {
            if (attr is MaxLengthAttribute)
            {
                return new MaxLengthValidation((MaxLengthAttribute)attr);
            }
            if (attr is RangeAttribute)
            {
                return new RangeValidation((RangeAttribute)attr);
            }
            return null;
        }
    }
}
