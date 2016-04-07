using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
