using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public abstract class User
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        protected User(int userId, string username, string password, string name)
        {
            // TODO Add specific validation checks
            // TODO Functionise validation
            if (IntegerIsNegative(userId)) throw new UserIdIsNegativeException("UserId is negative");
            if (string.IsNullOrWhiteSpace(username))
                throw new UsernameIsNullOrWhiteSpaceException("Username is null or white space");
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordIsNullOrWhiteSpaceException("Password is null or white space");
            if (string.IsNullOrWhiteSpace(name))
                throw new NameIsNullOrWhiteSpaceException("Name is null or white space");
            /*if (Regex.IsMatch(username, "^[a-z0-9]{3-15}")) throw new UsernameRegexException();
            // Passes John Jones-Smith, Jr.
            if (Regex.IsMatch(name, "/^[a-z ,.'-]+$/i")) throw new NameRegexException();*/

            UserId = userId;
            Username = username;
            Password = password;
            Name = name;
        }

        private static bool IntegerIsNegative(int userId)
        {
            return userId < 0;
        }

    }

    public class Accountant : User
    {
        public Accountant(int userId, string username, string password, string name) 
            : base(userId, username, password, name)
        {
        }
    }

    public abstract class DistrictStaff : User
    {
        public double HoursApprovalLimit { get; set; }
        public double CostApprovalLimit { get; set; }
        public DistrictName District { get; set; }

        protected DistrictStaff(int userId, string username, string password, string name, 
            double hoursApprovalLimit, double costApprovalLimit, DistrictName district) 
            : base(userId, username, password, name)
        {
            HoursApprovalLimit = hoursApprovalLimit;
            CostApprovalLimit = costApprovalLimit;
            District = district;
        }
    }

    public class Manager : DistrictStaff
    {
        public Manager(int userId, string username, string password, string name, 
            double hoursApprovalLimit, double costApprovalLimit, DistrictName district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }
    }

    public class Engineer : DistrictStaff
    {
        public Engineer(int userId, string username, string password, string name, 
            double hoursApprovalLimit, double costApprovalLimit, DistrictName district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }
    }
}
