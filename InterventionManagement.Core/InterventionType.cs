using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class InterventionType
    {
        public String Name { get; set; }
        public double Hours { get; set; }
        public double Cost { get; set; }

        public InterventionType(string name, double hours, double cost)
        {
            if (NameIsValid(name))
            {
                Name = name;
            }
            else
            {
                throw new InterventionNameException("The name was either empty, or missing.");
            }

            Hours = hours;
            Cost = cost;
        }

        private bool NameIsValid(string name)
        {
            return (name != null && name != "");
        }
    }


    public class InterventionNameException : Exception
    {
        public InterventionNameException(string message) { }
    }
}
