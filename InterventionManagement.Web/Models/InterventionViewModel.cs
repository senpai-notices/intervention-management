using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        /*Quality management*/
        /*public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [DisplayName("Date of Last Visit")]
        public DateTime DateOfLastVisit { get; set; }*/

        // foreign keys
        [DisplayName("Intervention type")]
        public string InterventionTemplate { get; set; }

        [DisplayName("Proposer")]
        public string ProposerId { get; set; }

        [DisplayName("Approver")]
        public string ApproverId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DisplayName("Client")]
        public int ClientId { get; set; }

        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [DisplayName("Date of Last Visit")]
        public DateTime DateOfLastVisit { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int InterventionId { get; set; }

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

    }

    public class ChangeStateViewModel
    {
        [DisplayName("Current Intervention State")]
        public string CurrentInterventionState { get; set; }

        [DisplayName("Select action")]
        public string NextInterventionState { get; set; }
        public IEnumerable<InterventionState> StateList { get; set; }
    }

}