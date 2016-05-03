using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    class EngineerTableWrapper
    {
        public void addEngineer(string username, int hoursApprovalLimit, int costApprovalLimit, int districtId)
        {
            MainDataSet.EngineerDataTable engineers = new EngineerTableAdapter().GetData();
            MainDataSet.EngineerRow newEngineer = engineers.NewEngineerRow();

            newEngineer.EngineerUsername = username;
            newEngineer.HoursApprovalLimit = hoursApprovalLimit;
            newEngineer.CostApprovalLimit = costApprovalLimit;
            newEngineer.DistrictId = districtId;

            engineers.Rows.Add(newEngineer);

            new EngineerTableAdapter().Update(engineers);
        }
    }
}
