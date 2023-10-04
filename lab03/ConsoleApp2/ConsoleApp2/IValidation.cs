using System.Reflection;

namespace ConsoleApp2
{
    public interface IValidation
    {
        bool Validate(object obj, PropertyInfo info);
    }
}