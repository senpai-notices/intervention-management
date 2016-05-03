using System;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Exceptions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers
{
    public static class ClientValidator
    {
        //public static int ValidateClientId(int clientId)
        //{
        //    if (IsNegative(clientId))
        //        throw new ClientIdIsNegativeException("ClientId is negative");

        //    return clientId;
        //}

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !name.Any(char.IsLetter))
                throw new ArgumentException("Please enter a valid name. Name must not contain numbers.");
            if (name.Length >= 100)
                throw new ArgumentException("Please enter a valid name. Name must contain less that 100 characters.");

            return true;
        }

        public static bool ValidateLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Please enter a location description.");
            if (location.Length >= 100)
                throw new ArgumentException("Please enter a valid Location. Must contain less that 150 characters.");

            return true;
        }

        //private static bool IsNegative(int userId)
        //{
        //    return userId < 0;
        //}
    }
}
