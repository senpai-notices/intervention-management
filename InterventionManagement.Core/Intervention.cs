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
        
        // Unsure whether to represent FKs as IDs or instances
        public int InterventionTypeId { get; private set; }
        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }

        public Intervention(int interventionId, DateTime datePerformed, InterventionState state, 
            List<QualityReport> qualityReport, int interventionTypeId, int proposerId, 
            int approverId, int clientId)
        {
            InterventionId = interventionId;
            DatePerformed = datePerformed;
            State = state;
            QualityReport = qualityReport;
            InterventionTypeId = interventionTypeId;
            ProposerId = proposerId;
            ApproverId = approverId;
            ClientId = clientId;
        }
    }
}
