using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Linq;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class InterventionTableWrapper
    {
        public void addIntervention
            (
            int interventionTemplateId,
            DateTime datePerformed,
            int interventionStateId,
            int hours,
            int cost,
            string proposerUsername,
            string approverUsername,
            int clientId,
            string notes,
            int remainingLife,
            DateTime dateOfLastVisit
            )
        {
            MainDataSet.InterventionDataTable interventions = new InterventionTableAdapter().GetData();
            MainDataSet.InterventionRow newIntervention = interventions.NewInterventionRow();

            newIntervention.InterventionTemplateId = interventionTemplateId;
            newIntervention.DatePerformed = datePerformed;
            newIntervention.InterventionStateId = interventionStateId;
            newIntervention.Hours = hours;
            newIntervention.Cost = cost;
            newIntervention.ProposerUsername = proposerUsername;
            newIntervention.ApproverUsername = approverUsername;
            newIntervention.ClientId = clientId;
            newIntervention.Notes = notes;
            newIntervention.RemainingLife = remainingLife;
            newIntervention.DateOfLastVisit = dateOfLastVisit;

            interventions.Rows.Add(newIntervention);

            // update the database
            new InterventionTableAdapter().Update(interventions);
        }

        /// <summary>
        /// This method will return the interventions that needed to be approved by the manager
        /// It will put the data of the intervention into a dictionary which takes 3 values and return it.   
        /// </summary>
        /// <param name="username">Username of the manager</param>
        /// <returns>Dictionary that contains intervention data</returns>
        public Dictionary<int, KeyValuePair<string, string>> getInterventionsByManager(string username)
        {

            Dictionary<int, KeyValuePair<string, string>> details = new Dictionary<int, KeyValuePair<string, string>>();
            var interventionTemplate = new InterventionTemplateTableAdapter().GetData();
            var interventions = new InterventionTableAdapter().GetDataBy_GetInterventionsByManager(username);

            var Interventiondetails = from intervention in interventions
                                      join template in interventionTemplate on
                                      intervention.InterventionTemplateId equals template.InterventionTemplateId
                                      select template.Name;

            foreach (var interventionName in Interventiondetails)
            {
                foreach (var interventionInfo in interventions)
                {
                    string interventionData = "Cost: " + interventionInfo.Cost.ToString()
                        + "<br>" + "Hours: " + interventionInfo.Hours.ToString() + "<br>" +
                        "Note: " + interventionInfo.Notes;
                    details.Add(interventionInfo.InterventionId, new KeyValuePair<string, string>(interventionName.ToString(), interventionData));
                }
            }

            return details;
        }
    }
}
