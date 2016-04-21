using System;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Exceptions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers
{
    public static class ClientValidator
    {
        public static int ValidateClientId(int clientId)
        {
            if (IsNegative(clientId))
                throw new ClientIdIsNegativeException("ClientId is negative");

            return clientId;
        }

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !name.Any(char.IsLetter))
                throw new ArgumentException("Please enter a valid name. Name must not contain numbers.");

            return name;
        }

        public static string ValidateLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Please enter a location description.");
            
            return location;

            // TODO make locationException
        }

        private static bool IsNegative(int userId)
        {
            return userId < 0;
        }
    }
}
