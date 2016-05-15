using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            SeedClients(context);
            SeedDistricts(context);
            SeedInterventionTemplates(context);
            SeedInterventionStates(context);
        }

        private void SeedClients(MainContext context)
        {
            var clients = new List<Client>
            {
                new Client{ ClientID=1, Name="Family of Josiah and Ruth", Location="Blue tin shack, underneath wooden bridge", DistrictID=6 },
                new Client{ ClientID=2, Name="Bambang Bima", Location="1 Agung Road", DistrictID=1 },
                new Client{ ClientID=3, Name="Susilo Sinta", Location="25 Wira Street", DistrictID=1 },
                new Client{ ClientID=4, Name="Rodney McDonald", Location="100 Nelson Highway, Wagga Wagga", DistrictID=6 }
            };
            clients.ForEach(s => context.Client.Add(s));
            context.SaveChanges();
        }

        private void SeedDistricts(MainContext context)
        {
            var districts = new List<District>
            {
                new District{ DistrictID=1, Name="Urban Indonesia" },
                new District{ DistrictID=2, Name="Rural Indonesia" },
                new District{ DistrictID=3, Name="Urban Papua New Guinea" },
                new District{ DistrictID=4, Name="Rural Papua New Guinea" },
                new District{ DistrictID=5, Name="Sydney" },
                new District{ DistrictID=6, Name="Rural New South Wales" }
            };
            districts.ForEach(s => context.District.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionStates(MainContext context)
        {
            var interventionStates = new List<InterventionState>
            {
                new InterventionState{ InterventionStateID=1, Name="Proposed" },
                new InterventionState{ InterventionStateID=2, Name="Approved" },
                new InterventionState{ InterventionStateID=3, Name="Cancelled" },
                new InterventionState{ InterventionStateID=4, Name="Completed" }
            };
            interventionStates.ForEach(s => context.InterventionState.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionTemplates(MainContext context)
        {
            var interventionTemplates = new List<InterventionTemplate>
            {
                new InterventionTemplate{ InterventionTemplateID=1, Name="Supply Mosquito Net", Hours=1, Cost=60.00M },
                new InterventionTemplate{ InterventionTemplateID=1, Name="Supply and Install Storm-proof Home Kit", Hours=40, Cost=1000.00M },
                new InterventionTemplate{ InterventionTemplateID=1, Name="Supply and Install Portable Toilet", Hours=4, Cost=150.00M },
                new InterventionTemplate{ InterventionTemplateID=1, Name="Hepatitis Avoidance Training", Hours=3, Cost=80.00M }
            };
            interventionTemplates.ForEach(s => context.InterventionTemplate.Add(s));
            context.SaveChanges();
        }
    }
}
