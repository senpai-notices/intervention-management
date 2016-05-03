﻿using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class ManagerTableWrapper
    {
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
    }
}