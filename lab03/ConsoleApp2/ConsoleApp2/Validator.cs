using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Validator
    {
        public bool Validate(object obj)
        {
            ValidationFactory factory = new ValidationFactory();

            // összes property
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var propInfo in properties)
            {
                // adott property attribútumai
                IEnumerable<Attribute> attributes = propInfo.GetCustomAttributes();
                foreach (var attribute in attributes)
                {
                    // melyik attribútum
                    IValidation validation = factory.GetValidation(attribute);

                    // érték valid-e
                    if (!validation.Validate(obj, propInfo))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
