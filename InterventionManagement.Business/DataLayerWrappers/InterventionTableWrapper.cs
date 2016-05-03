using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

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
    }
}
