using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;

namespace ASDF.ENETCare.InterventionManagement.Business.Validators
{
    
    public static class InterventionValidator
    {

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

        internal static bool ValidHoursAndCost(int hours, int cost)
        {
            //TODO: Exract max limit and place within config file
            if (hours < 0 || hours > 1000000) throw new ArgumentException("Hours must be not be a negative number");
            if (cost < 0 || cost > 1000000) throw new ArgumentException("Cost must be not be a negative number");

            return true;
        }

        public static bool CanUserComplete(int interventionID, string username)
        {
            return VerifyProposerUsername(interventionID, username);
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


        


        private static bool VerifyEngineerApprovalLimit(int interventionID, string username)
        {
            EngineerTableWrapper engineerWrapper = new EngineerTableWrapper();
            InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();

            var engineers = engineerWrapper.GetEngineerByEngineerUsername(username);
            var intervention = interventionWrapper.GetInterventionById(interventionID);

            int userHours = (int)engineers[0]["HoursApprovalLimit"];
            int userCost = (int)engineers[0]["CostApprovalLimit"];
            int intHours = (int)intervention[0]["EstimatedHours"];
            int intCost = (int)intervention[0]["EstimatedCost"];

            return validUserHourCost(userHours, userCost, intHours, intCost);
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


        private static bool validUserHourCost(int userHours, int userCost, int interventionHours, int interventionCost)
        {
            if (userHours > interventionHours || userCost > interventionCost) return false;

            return true;
        }


        public static bool CanEngineerApprove(int interventionID, string username)
        {
            if (VerifyProposerUsername(interventionID, username))
            {
                if (VerifyEngineerApprovalLimit(interventionID, username))
                {
                    return true;
                }
            }

            return false; // Insufficient permissions
        }

        public static bool CanManagerApprove(int interventionID, string username)
        {
            if (VerifyManagerApprovalLimit(interventionID, username))
            {
                return true;
            }

            return false; //inuficcient permissions (not enough cost/hours)
        }

        internal static bool CanEngineerCancel(int interventionID, string username)
        {
            //If Intervention state = Pending 
            //    User that can Aprove can cancel
            //    User that proposed can cancel
            //If Intervention state =  Approved
            //    User that proposed can cancel
            

            InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();
            var intervention = interventionWrapper.GetInterventionById(interventionID);

            int stateID = (int)intervention[0]["InterventionStateId"];

            //Proposed
            if (stateID == 1 && CanEngineerApprove(interventionID, username))
            {
                return true;
            }
            // Approved
            if (stateID == 2 && CanUserComplete(interventionID, username))
            {
                return true;
            }

            return false;
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
