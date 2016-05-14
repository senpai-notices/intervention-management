using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class DraftAppUser
    {
        public int DraftAppUserId { get; set; }
        public string Username { get; set; }
        public DraftAppUserRole AppUserRole { get; set; }

        public virtual ICollection<Intervention> ProposedInterventions { get; set; }
        public virtual ICollection<Intervention> ApprovedInterventions { get; set; }
    }

    public enum DraftAppUserRole
    {
        Accountant = 1,
        Manager,
        Engineer
    }
}
