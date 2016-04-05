using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class InterventionType
    {
        public string Name { get; set; }
        public double Hours { get; set; }
        public double Cost { get; set; }

        public InterventionType(string name, double hours, double cost)
        {
            if (!NameIsValid(name)) throw new InterventionTypeNameException("The name was either empty, or missing.");
            if (!NumberIsPositive(hours)) throw new InterventionTypeNumberException("Hours was not positive number");
            if (!NumberIsPositive(cost)) throw new InterventionTypeNumberException("Cost was not positive number");
            else
            {
                Name = name;
                Hours = hours;
                Cost = cost;
            }
        }

        private bool NameIsValid(string name)
        {
            return (name != null && name != "");
        }

        private static bool NumberIsPositive(double number)
        {
            return number > 0;
        }
    }


    public class InterventionTypeNameException : Exception
    {
        public InterventionTypeNameException(string message) { }
    }

    public class InterventionTypeNumberException : Exception
    {
        public InterventionTypeNumberException(string message) { }
    }
}
