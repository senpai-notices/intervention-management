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

        internal static bool ValidHoursAndCost(int hours, int cost)
        {
            if (hours < 0) throw new ArgumentException("Hours must be not be a negative number");
            if (cost < 0)  throw new ArgumentException("Cost must be not be a negative number");

            return true;
        }

        public static bool VerifyProposerUsername(int interventionID, string username)
        {
            //TODO: Uncomment When Intervention Wrapper is done.
            // InterventionTableWrapper interventionWrapper = new InterventionTableWrapper();
            // var intervention = interventionWrapper.GetInterventionByID(interventionID);

            //string proposer = (string)intervention[0]["ProposerUsername"];

            // if (username.Equals(proposer)) return true;

            return false;
        }

        internal static bool CanApprove(int interventionID, string username, string userRole)
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
