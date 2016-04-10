using System.Collections.Generic;

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
    }
}
