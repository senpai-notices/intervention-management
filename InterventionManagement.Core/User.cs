using System;
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

        public List<User> ViewDistrictStaff()
        {
            return UserManager.Users.Where(u => u.GetType() == typeof (DistrictStaff)).ToList(); // hope this works
        }

        public void TransferADistrictStaff(int userId, DistrictName targetDistrict)
        {
            ((DistrictStaff) UserManager.GetUserById(userId)).ChangeDistrict(targetDistrict); // hope this works
        }
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

        public void ChangeDistrict(DistrictName targetDistrict)
        {
            District = targetDistrict;
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

        public List<Intervention> ViewPendingInterventions()
        {
            return InterventionManager.Interventions
                .Where(i => i.State == InterventionState.Proposed || 
                ClientManager.GetClientById(i.ClientId).District == District)
                .ToList();
        }

        public void ApproveIntervention(Intervention intervention)
        {
            intervention.ApproveIntervention(UserId);
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

        public List<Client> ViewLocalClients()
        {
            return ClientManager.Clients.Where(s => s.District == District).ToList();
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

        public void EditQualityManagementInformation(Intervention intervention)
        { }

        public void CreateIntervention(Intervention intervention)
        {
            InterventionManager.Add(intervention);
        }

        public List<string> ViewCreatedInterventions()
        {
            var results = InterventionManager.Interventions.Where(i => i.ProposerId == UserId).ToList();

            var output = new List<string>()
            {
                "----------------------",
                "PREVIOUS INTERVENTIONS",
                "----------------------"
            };

            if (results.Any())
            {
                output.AddRange(results.Select(intervention => intervention.InterventionId + " " + intervention.DatePerformed.Date.ToShortDateString()).ToList());
            }
            else
            {
                output.Add("None");
            }

            return output;
        }

        public void CancelIntervention(Intervention intervention)
        {
            if (intervention.ProposerId != UserId) throw new Exception("User does not have permissions for this intervention");

            switch (intervention.State)
            {
                case InterventionState.Proposed:
                case InterventionState.Approved:
                    intervention.CancelIntervention();
                    break;
                case InterventionState.Cancelled:
                    throw new Exception("Intervention already cancelled");
                default:
                    throw new Exception("Invalid state");
            }
        }

        public void CompleteIntervention(Intervention intervention)
        {
            if (intervention.ProposerId != UserId) throw new Exception("User does not have permissions for this intervention");

            switch (intervention.State)
            {
                case InterventionState.Proposed:
                    throw new Exception("Intervention is not approved yet");
                case InterventionState.Approved:
                    intervention.CompleteIntervention();
                    break;
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
