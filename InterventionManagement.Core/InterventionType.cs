using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    class InterventionType
    {
        public String Name { get; set; }
        public double Hours { get; set; }
        public double Cost { get; set; }

        public InterventionType(string name, double hours, double cost)
        {
            Name = name;
            Hours = hours;
            Cost = cost;
        }
    }
}
