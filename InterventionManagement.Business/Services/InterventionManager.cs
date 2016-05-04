using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;
using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services
{
    public static class InterventionManager
    {
        private static InterventionTableWrapper _intervention = new InterventionTableWrapper();


        public static void AddNewIntervention(int InterventionTypeID, int cost, int hours, int clientID, string username)
        {
            //TODO: Finish AddNewIntervention.

            if (cost >= 0 && hours >= 0)
            {
                // TODO: Add State to new Intervention
                DateTime date = DateTime.Today;

                _intervention.addIntervention(InterventionTypeID, date, 1, hours, cost, username, null, clientID, "", 100, date);
            }

        }

        public static bool UpdateInterventionLife(int InterventionID, int remainingLife, string notes)
        {
            // return False if invalid inputs

            if (remainingLife > 100 || remainingLife < 0) return false;
            if (notes.Length > 2000) return false;
    
            DateTime today = DateTime.Today;

            _intervention.UpdateIntervention(InterventionID, remainingLife, notes, today);

            return true;
        }

        public static void ApproveIntervention(int InterventionID, string username, string userRole)
        {
            // Users from same district can interact with an Interventions. (Webforms ensures this)
            // 
            if (userRole.Equals("Manager") || InterventionValidator.VerifyProposerUsername(InterventionID, username))
            {
                if (InterventionValidator.CanApprove(InterventionID, username, userRole))
                {

                }
                // _intervention.ApproveInterventionByID(InterventionID, DateTime.Today);
            }

        }

    }
}
