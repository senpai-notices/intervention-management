using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Collections.Generic;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class ClientTableWrapper
    {
        //public void addEngineer(string username, int hoursApprovalLimit, int costApprovalLimit, int districtId, string name)
        //{

        //    // add a new engineer
        //    MainDataSet.EngineerDataTable engineers = new EngineerTableAdapter().GetData();
        //    MainDataSet.EngineerRow newEngineer = engineers.NewEngineerRow();

        //    newEngineer.EngineerUsername = username;
        //    newEngineer.HoursApprovalLimit = hoursApprovalLimit;
        //    newEngineer.CostApprovalLimit = costApprovalLimit;
        //    newEngineer.DistrictId = districtId;

        //    engineers.Rows.Add(newEngineer);

        //    // update the database
        //    new EngineerTableAdapter().Update(engineers);
        //}

        public List<string> getClientsForEngineer(string username)
        {
            List<string> clientNames = new List<string>();
            var clients = new ClientTableAdapter().GetDataBy_GetClientsByEngineerUsername(username);

            foreach (var client in clients)
            {
                clientNames.Add(client.Name.ToString());
            }

            return clientNames;
        }
    }
}