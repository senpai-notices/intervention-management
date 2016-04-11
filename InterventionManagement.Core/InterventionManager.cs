using System.Collections.Generic;
using System.Linq;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    // Should this be static?
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
