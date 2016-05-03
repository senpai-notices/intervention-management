using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Threading.Tasks;

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

    }
}
