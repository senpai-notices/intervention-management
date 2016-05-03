using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class EngineerTableWrapper
    {
        public void addEngineer(string username, int hoursApprovalLimit, int costApprovalLimit, int districtId, string name)
        {
            // add a user to the user table first (Engineer primary key has constraint to require User with same primary key)
            new UserTableWrapper().addUser(username, name);

            // add a new engineer
            MainDataSet.EngineerDataTable engineers = new EngineerTableAdapter().GetData();
            MainDataSet.EngineerRow newEngineer = engineers.NewEngineerRow();

            newEngineer.EngineerUsername = username;
            newEngineer.HoursApprovalLimit = hoursApprovalLimit;
            newEngineer.CostApprovalLimit = costApprovalLimit;
            newEngineer.DistrictId = districtId;

            engineers.Rows.Add(newEngineer);

            // update the database
            new EngineerTableAdapter().Update(engineers);
        }
    }
}
