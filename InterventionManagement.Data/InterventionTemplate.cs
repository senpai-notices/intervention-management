namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InterventionTemplate
    {
        public int InterventionTemplateId { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public decimal Cost { get; set; }
    }
}
