using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class InterventionViewModel
    {
    }

    public class InterventionsListViewModel:InterventionDetailsViewModel
    {

        public string InterventionState { get; set; }
        public IEnumerable<Intervention> Interventions { get; set; }

    }

    public class InterventionDetailsViewModel
    {
        public InterventionDetailsViewModel()
        {
            RemainingLife = 100;
        }
        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePerformed { get; set; }

        [Required]
        [Range(0, 9999)]
        public int Hours { get; set; }

        [Required]
        [Range(0, 99999999)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        /*Quality management*/
        /*public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [DisplayName("Date of Last Visit")]
        public DateTime DateOfLastVisit { get; set; }*/

        // foreign keys
        [DisplayName("Type")]
        [Required]
        public string InterventionTemplate { get; set; }

        [DisplayName("Proposer")]
        public string ProposerId { get; set; }

        [DisplayName("Approver")]
        public string ApproverId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DisplayName("Client")]
        public int ClientId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int StateId { get; set; }
        public string State { get; set; }

        [DisplayName("Client")]
        public string ClientName { get; set; }

        public string Notes { get; set; }

        [DisplayName("Remaining Life")]
        [Required]
        [Range(0,100)]
        public int RemainingLife { get; set; }

        [DisplayName("Last Visit")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLastVisit { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("ProposerNum")]
        public int ProposerNum { get; set; }

        [DisplayName("ApproverNum")]
        public int? ApproverNum { get; set; }

        [DisplayName("Proposer")]
        public string ProposerNameEmail { get; set; }

        [DisplayName("Approver")]
        public string ApproverNameEmail { get; set; }
    }

    public class CreateInterventionViewModel :InterventionDetailsViewModel
    {
        /*Hide base class members*/
        [HiddenInput(DisplayValue = false)]
        public new string ProposerId { get; set; } 

        [HiddenInput(DisplayValue = false)]
        public new string ApproverId { get; set; }

        public IEnumerable<InterventionTemplate> TemplateList { get; set; }
    }

    public class EditInterventionViewModel: InterventionDetailsViewModel
    {
        [Required]
        public new string Notes { get; set; }

        [DisplayName("Remaining Life")]
        [Required]
        [Range(0, 100)]
        public new int RemainingLife { get; set; }

        [Required]
        [DisplayName("Last Visit")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public new DateTime? DateOfLastVisit { get; set; }
    }

    public class ChangeStateViewModel
    {
        [DisplayName("Current Intervention State")]
        public string CurrentInterventionState { get; set; }

        [DisplayName("Select action")]
        public string NextInterventionState { get; set; }
        public IEnumerable<InterventionState> StateList { get; set; }
    }

    public class EditQualityInfo
    {
        [Required]
        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Invalid length.")]
        public string Notes { get; set; }

        [DisplayName("Remaining Life")]
        [Required]
        [Range(0, 100)]
        public int RemainingLife { get; set; }

        [Required]
        [DisplayName("Last Visit")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLastVisit { get; set; }
        public int Id { get; set; }
    }

}