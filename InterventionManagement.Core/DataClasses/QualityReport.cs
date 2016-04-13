using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataClasses
{
    public class QualityReport
    {
        public int QualityReportId { get; private set; }
        public DateTime DateAdded { get; private set; }
        public string Notes { get; private set; }
        public decimal EffectiveLife { get; private set; }

        // FK
        public int InterventionId { get; private set; }

        public QualityReport(int qualityReportId, DateTime dateAdded, string notes, decimal effectiveLife, int interventionId)
        {
            QualityReportId = qualityReportId;
            DateAdded = dateAdded;
            Notes = notes;
            EffectiveLife = effectiveLife;
            InterventionId = interventionId;
        }

        public void EditNotes(string newNotes)
        {
            Notes = newNotes;
        }

        public void EditEffectiveLife(decimal newEffectiveLife)
        {
            EffectiveLife = newEffectiveLife;
        }
    }
}
