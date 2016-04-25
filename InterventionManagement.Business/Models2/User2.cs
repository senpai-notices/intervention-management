using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models2
{
    public abstract class User2
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        protected User2(int userId, string username, string password, string name)
        {
            UserId = UserValidator.ValidateUserId(userId);
            Username = UserValidator.ValidateUsername(username.Trim());
            Password = UserValidator.ValidatePassword(password);
            Name = UserValidator.ValidateName(name.Trim());
        }

        public void ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (oldPassword != Password) throw new Exception("Current password incorrect");
            if (newPassword != confirmNewPassword) throw new Exception("New passwords do not match");

            Password = newPassword;
        }
    }

    public class Accountant2 : User2
    {
        public Accountant2(int userId, string username, string password, string name) 
            : base(userId, username, password, name)
        {
        }

        public void ViewDistrictStaff()
        {
        }

        public void TransferADistrictStaff(int userId, District2 targetDistrict)
        {
        }
        public void ViewTotalCostsByEngineer() { }
        public void ViewAverageCostsByEngineer() { }
        public void ViewCostsByDistrict() { }
        public void ViewMonthlyCostsForDistrict(District2 district) { }
    }

    public abstract class DistrictStaff2 : User2
    {
        public int HoursApprovalLimit { get; set; } // private set?
        public int CostApprovalLimit { get; set; }
        public District2 District { get; set; }

        protected DistrictStaff2(int userId, string username, string password, string name, 
            int hoursApprovalLimit, int costApprovalLimit, District2 district) 
            : base(userId, username, password, name)
        {
            HoursApprovalLimit = hoursApprovalLimit;
            CostApprovalLimit = costApprovalLimit;
            District = district;
        }

        public void ChangeDistrict(District2 targetDistrict)
        {
        }
    }

    public class Manager2 : DistrictStaff2
    {
        public Manager2(int userId, string username, string password, string name,
            int hoursApprovalLimit, int costApprovalLimit, District2 district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }

        public void ViewPendingInterventions()
        {
        }

        public void ApproveIntervention(Intervention2 intervention)
        {
            intervention.ApproveIntervention(UserId);
        }

        public void CancelIntervention(Intervention2 intervention) // interface of district staff?
        {
            intervention.CancelIntervention();
        }
    }

    public class Engineer2 : DistrictStaff2
    {
        public Engineer2(int userId, string username, string password, string name,
            int hoursApprovalLimit, int costApprovalLimit, District2 district) 
            : base(userId, username, password, name, hoursApprovalLimit, costApprovalLimit, 
                  district)
        {
        }

        public void CreateClient(Client2 client)
        {
        }

        public void ViewLocalClients()
        {
        }

        public void ViewClient(Client2 client)
        {
        }

        public void ViewQualityReports(Intervention2 intervention)
        {
        }

        public void EditQualityReport(int qualityReportId, string newNotes, int newEffectiveLife)
        {
        }

        public void AddQualityReport(QualityReport2 qualityReport)
        {
        }

        public void CreateIntervention(Intervention2 intervention)
        {
        }

        public void ViewCreatedInterventions()
        {
        }

        public void CancelIntervention(Intervention2 intervention)
        {
        }

        public void CompleteIntervention(Intervention2 intervention)
        {
        }

        public void ApproveIntervention(Intervention2 intervention)
        {
        }
    }
}
