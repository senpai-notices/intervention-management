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

        internal static bool ValidStateChange(Intervention intervention, ApplicationUser user, InterventionState newInterventionState)
        {

            int currentState = intervention.InterventionState.InterventionStateId;
            int newState = newInterventionState.InterventionStateId;

            if (currentState == 1) //Pending
            {
                if (newState == 2) //Approved
                {
                    return CanUserApprove(intervention, user);
                }

                if (newState == 4) //Canceled
                {
                    return CanUserCancelPending(intervention, user);
                }
            }
            else if (currentState == 2) //Approved
            {
                if (newState == 3) //Completed
                {
                    return CanUserCancelOrComplete(intervention, user);
                }

                if (newState == 4) //Canceled
                {
                    return CanUserCancelOrComplete(intervention, user);
                }
            }
            else return false;

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

        internal static bool CanUserApproveCost(Intervention intervention, ApplicationUser user)
        {
            decimal interventionCost = Math.Max(intervention.InterventionTemplate.Cost, intervention.Cost);

            if (user.Cost >= interventionCost) return true;
            return false;
        }

        internal static bool CanUserApproveHours(Intervention intervention, ApplicationUser user)
        {
            int interventionHours = Math.Max(intervention.InterventionTemplate.Hours, intervention.Hours);

            if (user.Hours >= interventionHours) return true;
            return false;
        }

        internal static bool CanUserApprove(Intervention intervention, ApplicationUser user)
        {
            //Proposer, Manager
            if (intervention.Proposer == user || user.Roles.Contains)) return true;
            return false;
        }

        internal static bool CanUserCancelPending(Intervention intervention, ApplicationUser user)
        {
            //Proposer, Manager
            if (intervention.Proposer == user || user.Roles.Contains)) return true;
            return false;
        }

        internal static bool CanUserCancelOrComplete(Intervention intervention, ApplicationUser user)
        {
            if (intervention.Proposer == user) return true;
           return false;
        }

    }

}
