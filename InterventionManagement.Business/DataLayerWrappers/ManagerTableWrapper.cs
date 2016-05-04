using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class ManagerTableWrapper
    {
        #region DEPRECATED
        public void addManager(string username, int hoursApprovalLimit, int costApprovalLimit, int districtId, string name)
        {
            // add a user to the user table first (Manager primary key has constraint to require User with same primary key)
            new UserTableWrapper().addUser(username, name);

            // add a new Manager
            MainDataSet.ManagerDataTable managers = new ManagerTableAdapter().GetData();
            MainDataSet.ManagerRow newManager = managers.NewManagerRow();

            newManager.ManagerUsername = username;
            newManager.HoursApprovalLimit = hoursApprovalLimit;
            newManager.CostApprovalLimit = costApprovalLimit;
            newManager.DistrictId = districtId;

            managers.Rows.Add(newManager);

            // update the database
            new ManagerTableAdapter().Update(managers);
        }
        #endregion

        public MainDataSet.ManagerDataTable GetManagers()
        {
            return new ManagerTableAdapter().GetData();
        }

        public MainDataSet.ManagerDataTable GetManagerByManagerUsername(string username)
        {
            return new ManagerTableAdapter().GetDataBy_ManagerUsername(username);
        }

        public void InsertManager(string username, string name, int hours, int cost, int districtId)
        {
            var dataTable = GetManagerByManagerUsername(username);

            if (dataTable.Rows.Count == 0)
            {
                new ManagerTableAdapter().InsertManager(username, name, hours, cost, districtId);
            }
            else
            {
                throw new Exception("Duplicate username.");
            }
        }

        public void DeleteManager(string username)
        {
            new ManagerTableAdapter().DeleteManager(username);
        }

        public void UpdateManagerDistrict(string username, int targetDistrict)
        {
            new ManagerTableAdapter().UpdateManagerDistrict(username, targetDistrict);
        }
    }
}
