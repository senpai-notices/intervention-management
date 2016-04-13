using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataClasses;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services
{
    public static class InterventionManager
    {
        private static readonly List<Intervention> _interventions = new List<Intervention>();

        public static List<Intervention> Interventions => _interventions;

        public static void Add(Intervention intervention)
        {
            _interventions.Add(intervention);
        }

        public static Intervention GetInterventionById(int interventionId)
        {
            return _interventions.FirstOrDefault(i => i.InterventionId == interventionId);
        }
    }
}
