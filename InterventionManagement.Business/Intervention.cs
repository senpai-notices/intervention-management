using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLastVisit { get; set; }

        // foreign keys
        public int InterventionTemplateId { get; set; }
        public int InterventionStateId { get; set; }
        public int ClientId { get; set; }
        public int ProposerId { get; set; }
        public int? ApproverId { get; set; }

        public virtual ApplicationUser Proposer { get; set; }
        public virtual ApplicationUser Approver { get; set; } 
        public virtual InterventionTemplate InterventionTemplate { get; set; }
        public virtual InterventionState InterventionState { get; set; }
        public virtual Client Client { get; set; }
    }
}
