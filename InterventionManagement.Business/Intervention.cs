using System;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public InterventionState InterventionState { get; set; }
        public int ClientId { get; set; }

        public int ProposerId { get; set; }
        public int ApproverId { get; set; }

        public virtual Client Client { get; set; }
        // Because Proposer and Approver would be from the same table, we need to do something to disambiguiate it.
        // http://stackoverflow.com/questions/28570916/defining-multiple-foreign-key-for-the-same-table-in-entity-framework-code-first

        // [ForeignKey("ProposerId")]
        // [InverseProperty("ProposedInterventions")]
        // public virtual AppUser Proposer { get; set; }
        // [ForeignKey("ApproverId")]
        // [InverseProperty("ApprovedInterventions")]
        // public virtual AppUser Approver { get; set; }
    }
}
