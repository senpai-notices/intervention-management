using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Validators
{
    
    public static class InterventionValidator
    {

        internal static bool ValidIntervention(Intervention intervention)
        {
            ValidNote(intervention.Notes);
            ValidLife(intervention.RemainingLife);
            ValidHours(intervention.Hours);
            ValidCost(intervention.Cost);

            return true;
        }

        internal static bool ValidStateChange(Intervention intervention)
        {
            // If Pending -> Approved.
            // IF manager or Proposer
            // If valid hours/cost approval limit.

            // if Pending -> Canceled
            // If manager or Proposer

            // If approved -> Completed/Canceled
            // If Proposer
            return true;
        }

        internal static bool ValidNote(string notes)
        {
            //TODO: Refactor Note length into variables file
            if (notes.Length > 2000) throw new ArgumentException("Notes must contain less that 2000 characters");

            return true;
        }

        internal static bool ValidLife(int remainingLife)
        {
            //0-100% life remaining
            if (remainingLife < 0 || remainingLife > 100) throw new ArgumentException("Remaining estimated lifetime of product must be between 0-100");

            return true;
        }

        internal static bool ValidHours(int hours)
        {
            //TODO: Exract max limit and place within config file
            if (hours < 0)          throw new ArgumentException("Hours must be not be a negative number");
            if (hours > 1000000)    throw new ArgumentException("Hours must be below 1,000,000");

            return true;
        }

        internal static bool ValidCost(decimal cost)
        {
            //TODO: Exract max limit and place within config file
            if (cost < 0) throw new ArgumentException("Cost must be not be a negative number");
            if (cost > 1000000) throw new ArgumentException("Cost must be below $1,000,000");
            
            return true;
        }

        public static bool CanUserComplete(int interventionID, string username)
        {
            return VerifyProposerUsername(interventionID, username);
        }


        private static bool validUserHourCost(int userHours, int userCost, int interventionHours, int interventionCost)
        {
            if (userHours > interventionHours || userCost > interventionCost) return false;

            return true;
        }


        private static bool VerifyProposerUsername(int interventionID, string username)
        {
            //TODO: Uncomment When Intervention Wrapper is done.
            var interventionRepo = new interventionRepository();
            var intervention = interventionWrapper.GetInterventionById(interventionID);

            string proposer = (string)intervention[0]["ProposerUsername"];

            if (!username.Equals(proposer)) throw new ArgumentException("Insufficient Permissions to perform this action");
            return true;
        }


        private static bool VerifyManagerApprovalLimit(int interventionID, string username)
        {
            ManagerTableWrapper tableWrapper = new ManagerTableWrapper();
            InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();

            var managers = tableWrapper.GetManagerByManagerUsername(username);
            var intervention = interventionWrapper.GetInterventionById(interventionID);

            int userHours = (int)managers[0]["HoursApprovalLimit"];
            int userCost = (int)managers[0]["CostApprovalLimit"];
            int intHours = (int)intervention[0]["EstimatedHours"];
            int intCost = (int)intervention[0]["EstimatedCost"];

            return validUserHourCost(userHours, userCost, intHours, intCost);
        }


        public static bool CanManagerApprove(int interventionID, string username)
        {
            if (VerifyManagerApprovalLimit(interventionID, username))
            {
                return true;
            }

            return false; //inuficcient permissions (not enough cost/hours)
        }
        internal static bool CanManagerCancel(int interventionID, string username)
        {
            InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();
            var intervention = interventionWrapper.GetInterventionById(interventionID);

            int stateID = (int)intervention[0]["InterventionStateId"];

            //Proposed
            if (stateID == 1 && CanManagerApprove(interventionID, username))
            {
                return true;
            }
            if (stateID == 2 && CanUserComplete(interventionID, username))
            {
                return true;
            }

            return false;
        }
    }

}
