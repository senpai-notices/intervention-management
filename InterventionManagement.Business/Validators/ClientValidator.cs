using System;
using System.Linq;

namespace ASDF.ENETCare.InterventionManagement.Business.Validators
{
    public static class ClientValidator
    {

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !name.Any(char.IsLetter))
                throw new ArgumentException("Please enter a valid name. Name must not contain numbers.");

            // TODO: Extract Name length and place into config/variable folder
            if (name.Length >= 100)
                throw new ArgumentException("Please enter a valid name. Name must contain less that 100 characters.");

            return true;
        }

        public static bool ValidateLocation(string location)
        {
            //TODO: Extract StringLength and Place into Config/Variable File
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Please enter a location description.");

            if (location.Length >= 150)
                throw new ArgumentException("Please enter a valid Location. Must contain less that 150 characters.");

            return true;
        }
    }
}
