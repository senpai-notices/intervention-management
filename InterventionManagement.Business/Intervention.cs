using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateOfLastVisit { get; set; }
        public InterventionState InterventionState { get; set; }
        public int ClientId { get; set; }
        // TODO: add template FK and remove name?

        public int ProposerId { get; set; }
        public int ApproverId { get; set; }

        public virtual Client Client { get; set; }

        // Because Proposer and Approver are from the same table (User), we need to disambiguiate it.
        // http://stackoverflow.com/questions/28570916/defining-multiple-foreign-key-for-the-same-table-in-entity-framework-code-first

        [ForeignKey("ProposerId")]
        [InverseProperty("ProposedInterventions")]
        public virtual DraftAppUser Proposer { get; set; }
        [ForeignKey("ApproverId")]
        [InverseProperty("ApprovedInterventions")]
        public virtual DraftAppUser Approver { get; set; }
    }
}
