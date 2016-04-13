using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Exceptions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers
{
    public static class UserValidator
    {
        public static int ValidateUserId(int userId)
        {
            if (IsNegative(userId))
                throw new UserIdIsNegativeException("UserId is negative");

            return userId;
        }

        public static string ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new UsernameIsNullOrWhiteSpaceException("Username is null or white space");

            return username;

            // if (Regex.IsMatch(username, "^[a-z0-9]{3-15}")) throw new UsernameRegexException();
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordIsNullOrWhiteSpaceException("Password is null or white space");

            return password;
        }

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NameIsNullOrWhiteSpaceException("Name is null or white space");

            return name;

            // if (!Regex.IsMatch(name, "/([a-z'-]+) ([a-z'-]+)/i")) throw new NameRegexException("REGEX");
            // "/^[a-z ,.'-]+$/i"
            // /([a-z'-]+) ([a-z'-]+)/i
        }

        private static bool IsNegative(int userId)
        {
            return userId < 0;
        }
    }
}
