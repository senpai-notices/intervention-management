namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class District
    {
        public int DistrictId { get; set; }

        public string Name { get; set; }
    }
}
