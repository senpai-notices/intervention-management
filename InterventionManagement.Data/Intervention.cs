namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Intervention
    {
        public int InterventionId { get; set; }

        public DateTime DatePerformed { get; set; }

        public int Hours { get; set; }

        public decimal Cost { get; set; }

        public string Notes { get; set; }

        public int RemainingLife { get; set; }

        public DateTime DateOfLastVisit { get; set; }

        public int InterventionTemplateId { get; set; }

        public int InterventionStateId { get; set; }

        public int ClientId { get; set; }

        public int EngineerId { get; set; }

        public int ManagerId { get; set; }
    }
}
