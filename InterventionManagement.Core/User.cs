using System.Collections.Generic;
using System.Linq;

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

        // It should be void with cw but I am making this testable
        public List<Client> ViewLocalClients()
        {
            return ClientManager.Clients.Where(s => s.District == this.District).ToList();
            
            /*
            foreach (var client in result)
            {
                Console.WriteLine(client.Name);
            }
            */
        }

        public void ViewClient()
        {
        }

        public void ViewInterventionsByClient(Client client)
        {
            // ClientManager.Clients.Where(s => s.)
        }

        public void EditQualityManagementInformation()
        {
            
        }

        public void CreateIntervention()
        {
            
        }

        public void ViewCreatedInterventions()
        { }

        public void ChangeInterventionState()
        { }

        // http://www.thedatastack.com/2015/05/05/unit-test-a-repository-with-mocking-using-nsubstitute/
    }
}
