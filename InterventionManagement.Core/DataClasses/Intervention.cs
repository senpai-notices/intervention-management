using System;
using System.Collections.Generic;
using System.Linq;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.DataClasses
{
    public class Intervention
    {
        public int InterventionId { get; private set; }
        public DateTime DatePerformed { get; private set; }
        public InterventionState State { get; private set; }

        public string Name { get; private set; }
        public decimal Hours { get; private set; }
        public decimal Cost { get; private set; }

        private readonly List<QualityReport> _qualityReports = new List<QualityReport>(); 
        public List<QualityReport> QualityReports => _qualityReports; 

        public int ProposerId { get; private set; }
        public int ApproverId { get; private set; }
        public int ClientId { get; private set; }

        public Intervention(int interventionId, DateTime datePerformed, InterventionTemplate template, int proposerId, int approverId, int clientId)
        {
            InterventionId = interventionId;
            DatePerformed = datePerformed;
            State = InterventionState.Proposed;
            Name = template.Name;
            Hours = template.Hours;
            Cost = template.Cost;
            ProposerId = proposerId;
            ApproverId = approverId;
            ClientId = clientId;
        }

        public void ApproveIntervention(int approverId)
        {
            ApproverId = approverId;
            State = InterventionState.Approved;
        }
        public void CancelIntervention()
        {
            State = InterventionState.Cancelled;
        }

        public void CompleteIntervention()
        {
            State = InterventionState.Completed;
        }

        public List<QualityReport> ViewQualityReports()
        {
            return QualityReports;
        }

        public void AddQualityReport(QualityReport qualityReport)
        {
            _qualityReports.Add(qualityReport);
        }

        public void EditQualityReport(QualityReport qualityReport, string newNotes, 
            decimal newEffectiveLife)
        {
            var qualityReportId = qualityReport.QualityReportId;
            var qualityReportDateAdded = qualityReport.DateAdded;
            var qualityReportInterventionId = qualityReport.InterventionId;

            RemoveQualityReport(qualityReport);
            AddQualityReport(new QualityReport(qualityReportId, qualityReportDateAdded, newNotes, 
                newEffectiveLife, qualityReportInterventionId));
        }

        public void RemoveQualityReport(QualityReport qualityReport)
        {
            _qualityReports.Remove(qualityReport);
        }

        public QualityReport GetQualityReportById(int qualityReportId)
        {
            return _qualityReports.Single(q => q.QualityReportId == qualityReportId);
        }

    }
}
