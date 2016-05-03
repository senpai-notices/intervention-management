using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;
using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services
{
    public static class InterventionManager
    {
        //private static InterventionTableWrapper _intervention = new InterventionTableWrapper();

        
        public static void AddNewIntervention(int InterventionTypeID, int cost, int hours, int clientID, string username)
        {
            //TODO: Finish AddNewIntervention (Uncomment Code when Methods are implemented).
           // bool approvalRequired = InterventionValidator.RequiresApproval(username, InterventionTypeID);
            
            // _intervention.AddNewIntervention(int InterventionTypeID, int cost, int hours, int clientID, string engineerUsername, approvalRequired);            
        }

        public static bool UpdateInterventionLife(int InterventionID, int remainingLife, string notes)
        {
            // return False if invalid inputs

            if (remainingLife > 100 || remainingLife < 0) return false;
            if (notes.Length > 2000) return false;

            DateTime today = DateTime.Today;

           // _intervention.UpdateIntervention(InterventionID, remainingLife, notes, today);

            return true;
        }

        public static void ApproveIntervention(int InterventionID, string username)
        {
            InterventionValidator.RequiresApproval(username, InterventionID);
        } 

    }
}
