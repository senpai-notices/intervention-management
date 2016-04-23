using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models
{
    public class QualityReport
    {
        public int QualityReportId { get; private set; }
        public DateTime DateAdded { get; private set; }
        public string Notes { get; private set; }
        public int EffectiveLife { get; private set; }

        // FK
        public int InterventionId { get; private set; }

        public QualityReport(int qualityReportId, DateTime dateAdded, string notes, int effectiveLife, int interventionId)
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

        public void EditEffectiveLife(int newEffectiveLife)
        {
            EffectiveLife = newEffectiveLife;
        }
    }
}
