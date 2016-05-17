using System.ComponentModel;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int DistrictId { get; set; }
    }
}
