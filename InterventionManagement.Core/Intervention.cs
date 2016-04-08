using System;
using System.Collections.Generic;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Intervention
    {
        public int InterventionId { get; private set; }
        public DateTime DatePerformed { get; private set; }
        public InterventionState State { get; private set; }

        public List<QualityReport> QualityReport { get; private set; }
        
        //public int InterventionTypeId { get; private set; }
        public string InterventionName { get; set; }
        public decimal InterventionHours { get; set; }
        public decimal InterventionCost { get; set; }

        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }
    }
}
