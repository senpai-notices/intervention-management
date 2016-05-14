using System;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        public DateTime DatePerformed { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public int RemainingLife { get; set; }
        public DateTime DateOfLastVisit { get; set; }
        public InterventionState InterventionState { get; set; }
        
        // foreign keys
        public int ClientId { get; set; }
        public int EngineerId { get; set; }
        public int ManagerId { get; set; }
    }
}
