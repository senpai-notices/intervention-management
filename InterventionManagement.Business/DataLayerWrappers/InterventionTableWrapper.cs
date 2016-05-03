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
    public class InterventionTableWrapper
    {


        public string getInterventionsByManager(string username)
        {
            var interventions = new InterventionTableAdapter().GetDataBy_GetInterventionsByManager(username);

            DataRow row = new DataRow();
            foreach (var row in interventions)
            {
                interventionName = row.Notes;
            }
            return interventionName;
        }
    }
}
