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

        public void addInterventionWithNoDateOfLastVisit
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
           int remainingLife
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

            interventions.Rows.Add(newIntervention);

            // update the database
            new InterventionTableAdapter().Update(interventions);
        }

        public MainDataSet.InterventionDataTable GetInterventions()
        {
            return new InterventionTableAdapter().GetData();
        }

        public MainDataSet.InterventionDataTable GetInterventionById(int id)
        {
            return new InterventionTableAdapter().GetDataBy_InterventionId(id);
        }

        public void InsertIntervention(int templateId, DateTime datePerformed, int stateId, int hours, int cost, 
            string proposerUsername, string approverUsername, int clientId, string notes, int remainingLife, 
            DateTime dateOfLastVisit)
        {
            new InterventionTableAdapter().InsertIntervention(templateId, datePerformed.Date, stateId, hours, 
                cost, proposerUsername, approverUsername, clientId, notes, remainingLife, dateOfLastVisit.Date);
        }

        public void DeleteIntervention(int id)
        {
            new InterventionTableAdapter().DeleteIntervention(id);
        }

        public MainDataSet.InterventionDataTable GetInterventionByClientId(int id)
        {
            return new InterventionTableAdapter().GetDataBy_ClientId(id);
        }

        public MainDataSet.InterventionDataTable GetInterventionByProposerUser(string proposer)
        {
            return new InterventionTableAdapter().GetDataBy_ProposerUser(proposer);
        }

        public MainDataSet.InterventionDataTable GetInterventionByApproverUser(string approver)
        {
            return new InterventionTableAdapter().GetDataBy_ApproverUser(approver);
        }

        public MainDataSet.InterventionDataTable GetInterventionByProposed()
        {
            return new InterventionTableAdapter().GetDataBy_Proposed();
        }

        public void UpdateQualityManagement(int id, string notes, int remainingLife)
        {
            new InterventionTableAdapter().UpdateQualityManagement(id, notes, remainingLife);
        }

        public void UpdateInterventionManagementState(int id, int targetState)
        {
            new InterventionTableAdapter().UpdateInterventionState(id, targetState);
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
