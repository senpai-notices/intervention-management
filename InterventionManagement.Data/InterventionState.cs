namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InterventionState
    {
        public int InterventionStateId { get; set; }

        public string Name { get; set; }
    }
}
