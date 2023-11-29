using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    public class WorkerFilter
    {
        public static IEnumerable<Worker> Filter(IEnumerable<Worker> workers)
        {
            return workers.Where(x => ValidateNumOfChildren(x));
        }

        static bool ValidateNumOfChildren(Worker worker)
        {
            var property = worker.GetType().GetProperty("Children");
            var propValue = (int)property.GetValue(worker, null);
            
            var attribute = (MinimumChildAttribute)property.GetCustomAttributes(typeof(MinimumChildAttribute), false).FirstOrDefault();
            var attrValue = attribute.Number;

            return propValue > attrValue;
        }
    }
}
