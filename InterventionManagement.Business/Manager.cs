using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Manager : AppUser
    {
        public virtual ICollection<Intervention> ApprovedInterventions { get; set; }
    }
}