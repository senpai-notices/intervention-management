using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models2
{
    public class Intervention2
    {
        public int InterventionId { get; private set; }
        public DateTime DatePerformed { get; private set; }
        public InterventionState2 State { get; private set; }

        public string Name { get; private set; }
        public int Hours { get; private set; }
        public int Cost { get; private set; }

        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }

        public Intervention2(int interventionId, DateTime datePerformed, InterventionTemplate2 template, int proposerId, int approverId, int clientId)
        {
            InterventionId = interventionId;
            DatePerformed = datePerformed;
            State = InterventionState2.Proposed;
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
            State = InterventionState2.Approved;
        }
        public void CancelIntervention()
        {
            State = InterventionState2.Cancelled;
        }

        public void CompleteIntervention()
        {
            State = InterventionState2.Completed;
        }
    }
}
