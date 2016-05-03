using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services
{
    public static class InterventionManager
    {
        //private static InterventionTableWrapper _intervention = new InterventionTableWrapper();

        
        public static void AddNewIntervention(int InterventionTypeID, int cost, int hours, int clientID, string engineerUsername)
        {
            //TODO: Finish AddNewIntervention (Uncomment Code when Methods are implemented).
            bool approvalRequired = InterventionValidator.RequiresApproval(engineerUsername, InterventionTypeID);
            
            // _intervention.AddNewIntervention(int InterventionTypeID, int cost, int hours, int clientID, string engineerUsername, approvalRequired);            
        }

    }
}
