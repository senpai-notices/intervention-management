using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers
{
    public static class InterventionValidator
    {

        public static bool RequiresApproval(string username, int interventionID)
        {
            //TODO: Finish RequiresApproval. (Uncomment when Methods are implemented)
            EngineerTableWrapper engineerWrapper = new EngineerTableWrapper();
           // InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();

            var engineers = engineerWrapper.GetEngineerByEngineerUsername(username);
            // var intervention = interventionWrapper.GetInterventionByID(interventionID);

            int hoursLimit = (int)engineers[0]["HoursApprovalLimit"];
            int costLimit = (int)engineers[0]["CostApprovalLimit"];
            // int hoursMin = (int)intervention[0]["EstimatedHours"];
            // int costMin = (int)intervention[0]["EstimatedCost"];


           // if (hoursLimit > hoursMin || costLimit > costMin)   return false;

            return true;
        }
        
    }
}
