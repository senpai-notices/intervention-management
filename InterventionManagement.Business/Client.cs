using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int DistrictId { get; set; }

        // foreign keys
        public virtual District District { get; set; }

        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
