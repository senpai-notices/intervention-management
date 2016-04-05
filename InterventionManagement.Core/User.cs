using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            UserId = userId;
            Username = username;
            Password = password;
            Name = name;
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

        public DistrictStaff(int userId, string username, string password, string name, 
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
