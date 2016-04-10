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

        public void ViewDistrictStaff() { }
        public void ChangeDistrictOfDistrictStaff() { }
        public void ViewTotalCostsByEngineer() { }
        public void ViewAverageCostsByEngineer() { }
        public void ViewCostsByDistrict() { }
        public void ViewMonthlyCostsForDistrict(DistrictName district) { }
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

        // Some of these methods will be placed in under DistrictStaff

        public void CreateClient(Client client)
        {
            ClientManager.Add(client);
        }

        public List<Client> ViewLocalClients()
        {
            return ClientManager.Clients.Where(s => s.District == this.District).ToList();
        }

        public List<string> ViewClient(Client client)
        {
            var clientDetails = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                client.ClientId.ToString(),
                client.Name,
                client.Location,
                client.District.ToString()
            };
            #region old query
            /*       
                            var interventionsOfClient = (
                            from i in InterventionManager.Interventions
                            where i.ClientId == client.ClientId
                            select i
                            ) as List<Intervention>;
            */
            // Above is the failed version of the below. I think they're the same query but the above couldn't match a result
#endregion
            var interventionsOfClient =
                InterventionManager.Interventions.Where(i => i.ClientId == client.ClientId).ToList();

            clientDetails.Add("");
            clientDetails.Add("Interventions");
            clientDetails.Add("-------------");

            if (interventionsOfClient.Any())
            {
                clientDetails.AddRange(interventionsOfClient.Select(intervention => intervention.InterventionId + " " + intervention.DatePerformed.Date.ToShortDateString()));
            }
            else
            {
                clientDetails.Add("None");

            }

            return clientDetails;
        }

        public void EditQualityManagementInformation()
        {
            
        }

        public void CreateIntervention(Intervention intervention)
        {
            InterventionManager.Add(intervention);
        }

        public void ViewCreatedInterventions()
        { }

        public void CancelIntervention()
        { }

        public void CompleteIntervention()
        { }
    }
}
