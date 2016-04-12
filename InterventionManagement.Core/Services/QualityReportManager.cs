using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.DataClasses;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Services
{
    public class QualityReportManager
    {
        private static readonly List<QualityReport> _qualityReports = new List<QualityReport>();

        public static List<QualityReport> QualityReports => _qualityReports;

        public static void Add(QualityReport qualityReport)
        {
            _qualityReports.Add(qualityReport);
        }

        public static QualityReport GetQualityReportById(int qualityReportId)
        {
            return _qualityReports.FirstOrDefault(i => i.QualityReportId == qualityReportId);
        }
    }
}
