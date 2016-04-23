using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models
{
    public class Intervention
    {
        public int InterventionId { get; private set; }
        public DateTime DatePerformed { get; private set; }
        public InterventionState State { get; private set; }

        public string Name { get; private set; }
        public int Hours { get; private set; }
        public int Cost { get; private set; }

        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }

        public Intervention(int interventionId, DateTime datePerformed, InterventionTemplate template, int proposerId, int approverId, int clientId)
        {
            InterventionId = interventionId;
            DatePerformed = datePerformed;
            State = InterventionState.Proposed;
            Name = template.Name;
            Hours = template.Hours;
            Cost = template.Cost;
            ProposerId = proposerId;
            ApproverId = approverId;
            ClientId = clientId;
        }

        public void ApproveIntervention(int approverId)
        {
            ApproverId = approverId;
            State = InterventionState.Approved;
        }
        public void CancelIntervention()
        {
            State = InterventionState.Cancelled;
        }

        public void CompleteIntervention()
        {
            State = InterventionState.Completed;
        }
    }
}
