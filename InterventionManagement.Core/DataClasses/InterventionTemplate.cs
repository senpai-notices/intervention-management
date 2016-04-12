using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.DataClasses
{
    public class InterventionTemplate
    {
        public string Name { get; set; }
        public decimal Hours { get; set; }
        public decimal Cost { get; set; }

        public InterventionTemplate(string name, decimal hours, decimal cost)
        {
            if (!NameIsValid(name)) throw new InterventionTemplateNameException("The name was either empty, or missing.");
            if (!NumberIsPositive(hours)) throw new InterventionTemplateNumberException("Hours was not positive number");
            if (!NumberIsPositive(cost)) throw new InterventionTemplateNumberException("Cost was not positive number");
            else
            {
                Name = name;
                Hours = hours;
                Cost = cost;
            }
        }

        private bool NameIsValid(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        private static bool NumberIsPositive(decimal number)
        {
            return number >= 0;
        }
    }
}
