using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class InterventionViewModel
    {
    }

    public class InterventionsListViewModel:InterventionDetailsViewModel
    {

        
        public IEnumerable<Intervention> Interventions { get; set; }

    }

    public class InterventionDetailsViewModel
    {      
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        /*Quality management*/
        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        [DisplayName("Date of Last Visit")]
        public DateTime DateOfLastVisit { get; set; }

        // foreign keys
        [DisplayName("Intervention type")]
        public string InterventionTemplate { get; set; }

        [DisplayName("Current State")]
        public string InterventionState { get; set; }

        [DisplayName("Proposer")]
        public string ProposerId { get; set; }

        [DisplayName("Approver")]
        public string ApproverId { get; set; }

    }

    public class CreateInterventionViewModel :InterventionDetailsViewModel
    {
       public IEnumerable<InterventionTemplate> TemplateList { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DisplayName("Current State")]
        public new string InterventionState { get; set; }
    }



}