using System;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Intervention
    {
        public int InterventionID { get; set; }

        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }

        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        public DateTime DateOfLastVisit { get; set; }

        public int InterventionTemplateID { get; set; }
        public int InterventionStateID { get; set; }
        public int ClientID { get; set; }
        public int EngineerID { get; set; }
        public int ManagerID { get; set; }
    }
}
