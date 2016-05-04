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

            try
            {
                if (InterventionValidator.ValidHoursAndCost(hours, cost))
                {
                    // TODO: Refactor Add New Intervention
                    DateTime date = DateTime.Today;

                    _intervention.addIntervention(InterventionTypeID, date, 1, hours, cost, username, null, clientID, "", 100, date);
                }
            }
            catch (ArgumentException e)
            {

                throw;
            }

        }

        public static void UpdateInterventionLife(int InterventionID, int remainingLife, string notes)
        {
            try {
                if (InterventionValidator.ValidLife(remainingLife) && InterventionValidator.ValidNote(notes))
                {
                    DateTime today = DateTime.Today;
                    _intervention.UpdateQualityManagement(InterventionID, notes, remainingLife);
                }
            }
            catch (ArgumentException e)
            {
                throw;
            }
        }

        public static void UpdateInterventionState(int interventionID, int newState, string username, string userRole)
        {
            try {
                if (userRole.Equals("Manager")) managerUpdateInterventionState(interventionID, newState, username);
                if (userRole.Equals("Engineer")) engineerUpdateInterventionState(interventionID, newState, username);
            }
            catch (ArgumentException e)
            {
                throw;
            }
            
        }

        private static void managerUpdateInterventionState(int interventionID, int newState, string username)
        { 
            if (newState == 2 && InterventionValidator.CanManagerApprove(interventionID, username))
            {
                //Approve
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }
            if (newState == 3 && InterventionValidator.CanUserComplete(interventionID, username))
            {
                // Complete
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }
            if (newState == 4 && InterventionValidator.CanManagerCancel(interventionID, username))
            {
                // Cancell
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }


        }

        private static void engineerUpdateInterventionState(int interventionID, int newState, string username)
        {
            
            if (newState == 2 && InterventionValidator.CanEngineerApprove(interventionID, username))
            {
                //Approve
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }
            if (newState == 3 && InterventionValidator.CanUserComplete(interventionID, username))
            {
                // Complete
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }
            if (newState == 4 && InterventionValidator.CanEngineerCancel(interventionID, username))
            {
                // Cancell
                _intervention.UpdateInterventionManagementState(interventionID, newState);
            }
        }

    }
}
