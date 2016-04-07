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
            UserId = UserValidator.ValidateUserId(userId);
            Username = UserValidator.ValidateUsername(username.Trim());
            Password = UserValidator.ValidatePassword(password);
            Name = UserValidator.ValidateName(name.Trim());
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
        public decimal HoursApprovalLimit { get; set; }
        public decimal CostApprovalLimit { get; set; }
        public DistrictName District { get; set; }

        protected DistrictStaff(int userId, string username, string password, string name, 
            decimal hoursApprovalLimit, decimal costApprovalLimit, DistrictName district) 
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
            decimal hoursApprovalLimit, decimal costApprovalLimit, DistrictName district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }
    }

    public class Engineer : DistrictStaff
    {
        public Engineer(int userId, string username, string password, string name, 
            decimal hoursApprovalLimit, decimal costApprovalLimit, DistrictName district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }

        public void CreateClient(Client client)
        {
            ClientManager.Add(client);
        }
    }
}
