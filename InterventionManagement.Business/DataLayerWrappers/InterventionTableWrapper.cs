using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class InterventionTableWrapper
    {
#region deprecated
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
        #endregion

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
            new InterventionTableAdapter().InsertIntervention(templateId, datePerformed, stateId, hours, 
                cost, proposerUsername, approverUsername, clientId, notes, remainingLife, dateOfLastVisit);
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
    }
}
