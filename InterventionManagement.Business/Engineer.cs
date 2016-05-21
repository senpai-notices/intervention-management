using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Engineer : AppUser
    {
        public virtual ICollection<Intervention> ProposedInterventions { get; set; }

    }
}