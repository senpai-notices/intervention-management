using System;
using System.Collections.Generic;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Intervention
    {
        public int InterventionId { get; private set; }
        public DateTime DatePerformed { get; private set; }
        public InterventionState State { get; private set; }

        public List<QualityReport> QualityReport { get; private set; }
        
        //public int InterventionTypeId { get; private set; }
        public string InterventionName { get; private set; }
        public decimal InterventionHours { get; private set; }
        public decimal InterventionCost { get; private set; }

        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }

        public Intervention(int interventionId, DateTime datePerformed, InterventionState state, 
            List<QualityReport> qualityReport, string interventionName, decimal interventionHours, 
            decimal interventionCost, int proposerId, int approverId, int clientId)
        {
            InterventionId = interventionId;
            DatePerformed = datePerformed;
            State = state;
            QualityReport = qualityReport;
            InterventionName = interventionName;
            InterventionHours = interventionHours;
            InterventionCost = interventionCost;
            ProposerId = proposerId;
            ApproverId = approverId;
            ClientId = clientId;
        }
    }
}
