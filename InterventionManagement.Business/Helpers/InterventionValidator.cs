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

        internal static bool ValidNote(string notes)
        {
            //TODO: Refactor Note length into variables file
            if (notes.Length > 2000) throw new ArgumentException("Notes must contain less that 2000 characters");

            return true;
        }

        internal static bool ValidLife(int remainingLife)
        {
            //0-100% life remaining
            if(remainingLife < 0 || remainingLife > 100) throw new ArgumentException("Remaining estimated lifetime of product must be between 0-100");

            return true;
        }

        internal static bool ValidHoursAndCost(int hours, int cost)
        {
            if (hours < 0) throw new ArgumentException("Hours must be not be a negative number");
            if (cost < 0)  throw new ArgumentException("Cost must be not be a negative number");

            return true;
        }

        public static bool VerifyProposerUsername(int interventionID, string username)
        {
            throw new NotImplementedException();
            //TODO: Uncomment When Intervention Wrapper is done.
            //InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();
            //var intervention = interventionWrapper.GetInterventionByID(interventionID);

            //string proposer = (string)intervention[0]["ProposerUsername"];

            //if (!username.Equals(proposer)) throw new ArgumentException("Insufficient Permissions to perform this action");

            return true;
        }

        internal static bool CanUserApprove(int interventionID, string username, string userRole)
        {
            throw new NotImplementedException();

            //TODO: Finish Approval. (Finish spliting Engineer/Manager)
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
