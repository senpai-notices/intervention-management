using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            SeedInterventionState(context);
        }

        private void SeedInterventionState(MainContext context)
        {
            var interventionStates = new List<InterventionState>
            {
                new InterventionState{ Name="Proposed"},
                new InterventionState{ Name="Approved"},
                new InterventionState{ Name="Cancelled"},
                new InterventionState{ Name="Completed"}
            };
            interventionStates.ForEach(s => context.InterventionState.Add(s));
            context.SaveChanges();
        }
    }
}
