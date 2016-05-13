using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            SeedInterventionStates(context);
            SeedInterventionTemplates(context);
        }

        private void SeedInterventionStates(MainContext context)
        {
            var interventionStates = new List<InterventionState>
            {
                new InterventionState{ Name="Proposed" },
                new InterventionState{ Name="Approved" },
                new InterventionState{ Name="Cancelled" },
                new InterventionState{ Name="Completed" }
            };
            interventionStates.ForEach(s => context.InterventionState.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionTemplates(MainContext context)
        {
            var interventionTemplates = new List<InterventionTemplate>
            {
                new InterventionTemplate{ Name="Supply Mosquito Net", Hours=1, Cost=60.00M },
                new InterventionTemplate{ Name="Supply and Install Storm-proof Home Kit", Hours=40, Cost=1000.00M },
                new InterventionTemplate{ Name="Supply and Install Portable Toilet", Hours=4, Cost=150.00M },
                new InterventionTemplate{ Name="Hepatitis Avoidance Training", Hours=3, Cost=80.00M }
            };
            interventionTemplates.ForEach(s => context.InterventionTemplate.Add(s));
            context.SaveChanges();
        }
    }
}
