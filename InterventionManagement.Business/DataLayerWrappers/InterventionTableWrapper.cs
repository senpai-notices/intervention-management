using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Threading.Tasks;
using System.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    class InterventionTableWrapper
    {
        public List<string> getInterventions()
        {
            List<string> namelist = new List<string>();
            MainDataSet.InterventionDataTable interventions = new InterventionTableAdapter().GetData();
            MainDataSet.ClientDataTable clients = new ClientTableAdapter().GetData();
            return namelist;
        }

        public void getInterventionsByManager(string username)
        {
            var interventions = new InterventionTableAdapter().GetDataBy_GetInterventionsByManager(username);

            DataRow row = new DataRow();
            foreach (var row in interventions)
            {
                var placeholder = row.Notes;
            }
        }
    }
}
